using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SandS.Algorithm.Library.Menu
{
    public class Drawable
    {
        public Drawable(Texture2D texture)
        {
            this.Texture = texture;
        }

        public Texture2D Texture { get; set; }
    }
}
