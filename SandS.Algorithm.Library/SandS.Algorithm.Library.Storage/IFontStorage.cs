using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SandS.Algorithm.Library.StorageNamespace
{
    public interface IFontStorage
    {
        void Initialize(ContentManager contentManager);

        SpriteFont Get(FontType fontType);
    }

    public enum FontType
    {
        Default = 0,
    }
}