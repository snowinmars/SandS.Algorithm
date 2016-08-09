using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
