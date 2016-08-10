using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SandS.Algorithm.Library.StorageNamespace
{
    public interface ITextureStorage
    {
        void Initialize(ContentManager contentManager, GraphicsDevice graphicsDevice);

        Texture2D Get(TextureType textureType);
    }

    public enum TextureType
    {
        Default = 0,
    }
}