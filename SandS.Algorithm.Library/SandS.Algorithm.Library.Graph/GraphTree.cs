using System;
using System.Collections.Generic;
using System.Linq;

namespace SandS.Algorithm.Library.GraphNamespace
{
    public class GraphTree<TGraphnode, TBody> : ICloneable, IHasGraphTree<TGraphnode, TBody>
        where TGraphnode : GraphNode<TBody>
    {
        #region Public Constructors

        public GraphTree() : this(null)
        {
        }

        public GraphTree(IEnumerable<TGraphnode> nodes)
        {
            if (nodes == null)
            {
                nodes = new List<TGraphnode>();
            }

            this.Nodes = nodes.ToList();
            this.State = GraphState.Default;
            this.Id = Guid.NewGuid();
        }

        #endregion Public Constructors

        #region Public Properties

        public Guid Id { get; }

        public IList<TGraphnode> Nodes { get; }

        public GraphState State { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void AddNode(TGraphnode node)
        {
            if (this.Nodes.Contains(node))
            {
                throw new ArgumentException($"Graph {this.Id} already contains node {node}");
            }

            this.Nodes.Add(node);

            foreach (var connection in node.Children
                                            .Select(graphNode => graphNode as TGraphnode))
            {
                if (connection == null)
                {
                    throw new InvalidCastException(nameof(connection));
                }

                if (!this.Nodes.Contains(connection))
                {
                    this.AddNode(connection);
                }
            }

            this.EnsureValid();
        }

        public void Connect(TGraphnode lhs, TGraphnode rhs)
        {
            if (lhs == null || rhs == null)
            {
                throw new ArgumentNullException();
            }

            lhs.Connect(rhs);
            rhs.Connect(lhs);

            this.EnsureValid();
        }

        /// <summary>
        /// Check. is graph cyclic.
        /// Based on deep-first.
        /// </summary>
        /// <param name="haveClearColor"></param>
        /// <returns></returns>
        public bool IsCycle(bool haveClearColor = true)
        {
            if (haveClearColor)
            {
                this.ClearColor();
            }

            try
            {
                return this.Nodes
                            .Where(item => item.Color == GraphNodeColor.White)
                            .Any(item => this.IsCycle(item, item));
            }
            finally
            {
                if (haveClearColor)
                {
                    this.ClearColor();
                }
            }
        }

        /// <summary>
        /// Check, is this graph looped.
        /// O(nodes * nodeConnections)
        /// </summary>
        /// <returns></returns>
        public bool IsLooped()
        {
            return (from node in this.Nodes
                    from connect in node.Children
                    where node == connect
                    select node).Any();
        }

        /// <summary>
        /// Check, is graph solid using DFS.
        /// </summary>
        /// <returns></returns>
        public bool IsNonConnectivity()
        {
            if (this.Nodes.Count == 0)
            {
                return this.State.HasFlag(GraphState.CanBeNonConnectivly);
            }

            try
            {
                TGraphnode root = this.Nodes[0];

                return this.Nodes.Any(node => !this.IsRouteBetween(root, node));
            }
            finally
            {
                this.ClearColor();
            }
        }

        /// <summary>
        /// Check, is there any route between two nodes.
        /// Based on deep-first.
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        /// <returns></returns>
        public bool IsRouteBetween(TGraphnode startNode, TGraphnode endNode)
        {
            if ((startNode == null) ||
                (endNode == null))
            {
                throw new ArgumentNullException("Node is null");
            }

            return this.IsRouteBetween(startNode, startNode, endNode);
        }

        public void RemoveNode(TGraphnode node)
        {
            if (!this.Nodes.Contains(node))
            {
                throw new ArgumentException($"Graph {this.Id} has no node {node}");
            }

            foreach (var item in this.Nodes)
            {
                item.Disconnect(node);
            }

            this.Nodes.Remove(node);

            this.EnsureValid();
        }

        /// <summary>
        /// Colories every node in graph.
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(GraphNodeColor color)
        {
            foreach (var item in this.Nodes)
            {
                item.Color = color;
            }
        }

        #endregion Public Methods

        #region Private Methods

        protected virtual void EnsureValid()
        {
            if (!this.State.HasFlag(GraphState.CanBeCycle))
            {
                if (this.IsCycle())
                {
                    throw new InvalidOperationException($"Graph {this.Id} state {this.State} is not allow to use this action: graph could became cycle");
                }
            }

            if (!this.State.HasFlag(GraphState.CanBeLooped))
            {
                if (this.IsLooped())
                {
                    throw new InvalidOperationException($"Graph {this.Id} state {this.State} is not allow to use this action: graph could became looped");
                }
            }

            if (!this.State.HasFlag(GraphState.CanBeNonConnectivly))
            {
                if (this.IsNonConnectivity())
                {
                    throw new InvalidOperationException($"Graph {this.Id} state {this.State} is not allow to use this action: graph could became non-connectivited");
                }
            }
        }

        /// <summary>
        /// Set color of all nodes of this graph to Color.White
        /// </summary>
        private void ClearColor()
        {
            foreach (var T in this.Nodes)
            {
                T.Color = GraphNodeColor.White;
            }
        }

        private bool IsCycle(TGraphnode node, TGraphnode lastNode)
        {
            node.Color = GraphNodeColor.Grey;

            foreach (TGraphnode item in node.Children
                                                .Select(graphNode => graphNode as TGraphnode))
            {
                if (item == null)
                {
                    throw new InvalidCastException(nameof(item));
                }

                if ((item == lastNode) ||
                    (item == node))
                {
                    continue;
                }

                if (item.Color == GraphNodeColor.Grey)
                {
                    return true;
                }

                if (item.Color != GraphNodeColor.Black)
                {
                    if (this.IsCycle(item, node))
                    {
                        return true;
                    }
                }
            }

            node.Color = GraphNodeColor.Black;

            return false;
        }

        private bool IsRouteBetween(TGraphnode nodeNumber, TGraphnode lastNode, TGraphnode wannaget, bool haveClearColor = true)
        {
            if (haveClearColor)
            {
                this.ClearColor();
            }
            try
            {
                nodeNumber.Color = GraphNodeColor.Black;

                if (nodeNumber == wannaget)
                {
                    return true;
                }

                foreach (var node in nodeNumber.Children
                                                .Select(graphNode => graphNode as TGraphnode))
                {
                    if (node == null)
                    {
                        throw new InvalidCastException(nameof(node));
                    }

                    if (node == lastNode)
                    {
                        continue;
                    }

                    if (node.Color != GraphNodeColor.Black)
                    {
                        if (this.IsRouteBetween(node, nodeNumber, wannaget))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            finally
            {
                if (haveClearColor)
                {
                    this.ClearColor();
                }
            }
        }

        #endregion Private Methods

        #region Clone

        public object Clone()
        {
            return this.ShallowClone();
        }

        /// <summary>
        /// Overload of this.Clone() by return value
        /// </summary>
        /// <returns></returns>
        public GraphTree<TGraphnode, TBody> ShallowClone()
        {
            return new GraphTree<TGraphnode, TBody>(this.Nodes);
        }

        #endregion Clone
    }
}