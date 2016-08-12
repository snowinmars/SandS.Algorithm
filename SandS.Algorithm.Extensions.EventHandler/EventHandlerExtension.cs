using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Extensions.EventHandlerNamespace
{
    public static class EventHandlerExtension
    {
        /// <summary>
        /// Returns copy of EventHandler using reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e">not using</param>
        /// <param name="value">This object contains EventHandler field</param>
        /// <param name="eventName">This is EventHandler field name, contains in the value. If there's no event with name like this, return null</param>
        /// <returns></returns>
        public static EventHandler Clone<T>(this EventHandler e, T value, string eventName)
        {
            Type type = value.GetType();
            EventInfo eventInfo = type.GetEvent(eventName);
            FieldInfo fieldInfo = type.GetField(eventInfo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);

            if (fieldInfo == null)
            {
                return null;
            }

            Delegate fieldDelegate = fieldInfo.GetValue(value) as Delegate;

            if (fieldDelegate == null)
            {
                return null;
            }

            EventHandler handler = fieldDelegate.GetInvocationList().FirstOrDefault() as EventHandler;

            return handler;
        }
    }
}
