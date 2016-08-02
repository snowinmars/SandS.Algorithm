using System;
using System.Reflection;
using System.Reflection.Emit;

namespace SandS.Algorithm.Library.FastObjectAllocator
{
    public class FastObjectAllocator<T>
        where T : class, new()
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object LockObj = new object();

        private static Func<T> objCreator;

        public static T New()
        {
            if (FastObjectAllocator<T>.objCreator != null)
            {
                return FastObjectAllocator<T>.objCreator.Invoke();
            }

            lock (FastObjectAllocator<T>.LockObj)
            {
                if (FastObjectAllocator<T>.objCreator != null)
                {
                    return FastObjectAllocator<T>.objCreator.Invoke();
                }

                Type objType = typeof(T);

                DynamicMethod meth = new DynamicMethod(name: Guid.NewGuid().ToString(),
                                                        returnType: objType,
                                                        parameterTypes: null);

                ConstructorInfo defaultCtor = objType.GetConstructor(new Type[] { });

                if (defaultCtor == null)
                {
                    throw new InvalidOperationException("Can't allocate object: ctor is null");
                }

                ILGenerator ilGen = meth.GetILGenerator();

                ilGen.Emit(OpCodes.Newobj, defaultCtor);
                ilGen.Emit(OpCodes.Ret);

                FastObjectAllocator<T>.objCreator = meth.CreateDelegate(typeof(Func<T>)) as Func<T>;
            }

            if (FastObjectAllocator<T>.objCreator != null)
            {
                return FastObjectAllocator<T>.objCreator.Invoke();
            }

            throw new InvalidOperationException("Can't allocate object");
        }
    }
}