using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.GraphNamespace;

namespace SandS.Algorithm.Library.RedBlackTree
{
    public class RedBlackTreeNode<T> : GraphNode<T>, ICloneable
        where T : RedBlackTreeNodeBody
    {
        public RedBlackTreeNode(T body,
            IEnumerable<GraphNode<T>> connections = null, 
            GraphNodeColor color = GraphNodeColor.White) : base(body, connections, color)
        {
        }
    }
}
