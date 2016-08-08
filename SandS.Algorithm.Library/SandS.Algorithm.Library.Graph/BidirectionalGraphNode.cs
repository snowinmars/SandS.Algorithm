using System;
using System.Collections.Generic;
using System.Linq;

namespace SandS.Algorithm.Library.Graph
{
    public class BidirectionalGraphNode<T> : ICloneable
    {
        #region Public Constructors

        public BidirectionalGraphNode(T body, IEnumerable<BidirectionalGraphNode<T>> connections = null, GraphNodeColor color = GraphNodeColor.White)
        {
            this.Color = color;

            if (connections == null)
            {
                connections = new List<BidirectionalGraphNode<T>>();
            }

            this.Children = connections.ToList();

            this.Body = body;
        }

        #endregion Public Constructors

        #region Public Properties

        public GraphNodeColor Color { get; set; }

        public IList<BidirectionalGraphNode<T>> Children { get; }

        public T Body { get; set; }

        #endregion Public Properties

        #region Clone

        public virtual object Clone()
        {
            return (object)this.CloneShallow();
        }

        /// <summary>
        /// Overload of this.Clone() by return value
        /// </summary>
        /// <returns></returns>
        public virtual BidirectionalGraphNode<T> CloneShallow()
        {
            return new BidirectionalGraphNode<T>(this.Body, this.Children, this.Color);
        }

        #endregion Clone

        #region Public Methods

        /// <summary>
        /// This method add connection to this. In result nodes appears in Connections property of each other.
        /// </summary>
        /// <param name="node"></param>
        internal void Connect(BidirectionalGraphNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            this.Children.Add(node);
            node.Children.Add(this);
        }

        internal void Disconnect(BidirectionalGraphNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            this.Children.Remove(node);
            node.Children.Remove(this);
        }

        #endregion Public Methods
    }
}