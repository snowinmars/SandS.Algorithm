using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.Graph;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;


namespace SandS.Algorithm.Library.Menu
{
    public enum MenuNodeType
    {
        Head = 0,
        Node = 1,
    }

    public class MenuNode<T> : OnedirectionalGraphNode<T>, ICloneable
        where T : MenuNodeBody
    {
        public MenuNode(T body,
            IEnumerable<MenuNode<T>> connections = null,
            GraphNodeColor color = GraphNodeColor.White) : base(body, connections, color)
        {
        }
    }
}