using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SandS.Algorithm.Library.Menu
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
