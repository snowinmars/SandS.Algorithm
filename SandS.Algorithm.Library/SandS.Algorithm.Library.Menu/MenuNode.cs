using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.Graph;
using System;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.Menu
{
    public enum MenuNodeType
    {
        Head = 0,
        Node = 1,
    }

    public class MenuNode<T> : GraphNode<T>, ICloneable, IUpdateable, IDrawable
        where T : MenuNodeBody
    {
        public MenuNode(T body,
            IEnumerable<MenuNode<T>> connections = null,
            GraphNodeColor color = GraphNodeColor.White) : base(body, connections, color)
        {
        }


        #region IDrawable

        public int DrawOrder { get; set; }

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime)
        {
        }

        #endregion IDrawable

        #region IUpdateable

        public bool Enabled { get; set; }

        public int UpdateOrder { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public override string ToString()
        {
            return this.Body.Text;
        }

        public void Update(GameTime gameTime)
        {
        }

        #endregion IUpdateable
    }
}