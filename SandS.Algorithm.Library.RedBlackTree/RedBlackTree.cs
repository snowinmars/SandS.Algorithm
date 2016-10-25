using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.GraphNamespace;

namespace SandS.Algorithm.Library.RedBlackTree
{
    public class RedBlackTree<TMenunode, TBody> : ICloneable, IHasGraphTree<TMenunode, TBody>
        where TMenunode : RedBlackTreeNode<TBody>
        where TBody : RedBlackTreeNodeBody
    {
        protected readonly GraphTree<TMenunode, TBody> graph;

        public RedBlackTree() : this(new GraphTree<TMenunode, TBody>())
        {
        }

        public RedBlackTree(IEnumerable<TMenunode> nodes) : this(new GraphTree<TMenunode, TBody>(nodes))
        {
        }

        protected internal RedBlackTree(GraphTree<TMenunode, TBody> graph)
        {
            this.graph = graph;
            this.graph.State = GraphState.IsBinary;
        }

        public object Clone()
        {
            return new RedBlackTree<TMenunode, TBody>(this.graph.Nodes);
        }

        public void AddNode(TMenunode node)
        {
            this.graph.AddNode(node);
        }

        public void Connect(TMenunode lhs, TMenunode rhs)
        {
            this.graph.Connect(lhs,rhs);
        }

        public bool IsCycle(bool haveClearColor = true)
        {
            return this.graph.IsCycle(haveClearColor);
        }

        public bool IsLooped()
        {
            return this.graph.IsLooped();
        }

        public bool IsNonConnectivity()
        {
            return this.graph.IsNonConnectivity();
        }

        public bool IsRouteBetween(TMenunode startNode, TMenunode endNode)
        {
            return this.graph.IsRouteBetween(startNode, endNode);
        }

        public void RemoveNode(TMenunode node)
        {
            this.graph.RemoveNode(node);
        }
    }
}
