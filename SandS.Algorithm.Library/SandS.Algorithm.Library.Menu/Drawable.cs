using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SandS.Algorithm.Library.Storage;

namespace SandS.Algorithm.Library.Menu
{
    public class Drawable
    {
        public Drawable(Texture2D texture)
        {
            if (texture == null)
            {
                texture = TextureStorage.Instance.Get(TextureType.Default);
            }

            this.Texture = texture;
        }

        public Texture2D Texture { get; set; }
    }
}
