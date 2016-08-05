using Microsoft.Xna.Framework;

namespace SandS.Algorithm.Library.Menu
{
    public class MenuNodeBody
    {
        public MenuNodeBody(MenuNodeType nodeType, string text, Drawable drawable,  Rectangle rectangle)
        {
            this.NodeType = nodeType;
            this.Text = text;
            this.Drawable = drawable;
            this.Rectangle = rectangle;
        }

        public string Text { get; set; }

        public Drawable Drawable { get; set; }

        public MenuNodeType NodeType { get; set; }

        public Rectangle Rectangle { get; set; }
    }
}