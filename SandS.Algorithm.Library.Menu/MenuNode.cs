using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.Graph;

namespace SandS.Algorithm.Library.Menu
{
    public class MenuNode<T> : GraphNode<T>, ICloneable
    {
        public string Text { get; set; }

        public MenuNode(T body) : this(string.Empty, body, null, GraphNodeColor.White)
        {

        }

        public MenuNode(string text, T body, IEnumerable<MenuNode<T>> connections = null, GraphNodeColor color = GraphNodeColor.White) : base(body, connections, color)
        {
            this.Text = text;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
