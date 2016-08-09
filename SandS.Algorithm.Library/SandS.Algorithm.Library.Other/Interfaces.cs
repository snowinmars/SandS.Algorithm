using Microsoft.Xna.Framework;

namespace SandS.Algorithm.Library.Other
{
    public interface IUpdatable
    {
        void Update(GameTime gameTime);
    }

    public interface ICloneable<T>
    {
        T DeepClone();
        T ShallowClone();
    }
}