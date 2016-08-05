using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SandS.Algorithm.Library.Menu
{
    public interface ICanLoadContent
    {
        void LoadContent(ContentManager content, GraphicsDevice graphicsDevice);
    }
}