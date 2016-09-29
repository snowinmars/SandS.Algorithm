using System;
using System.Collections.Generic;
using System.Linq;

namespace SandS.Algorithm.Library.GraphNamespace
{
    public class GraphNode<T> : ICloneable
    {
        public GraphNode(T body, IEnumerable<GraphNode<T>> connections = null, GraphNodeColor color = GraphNodeColor.White)
        {
            this.Body = body;

            if (connections == null)
            {
                connections = new List<GraphNode<T>>();
            }

            this.Children = connections.ToList();
            this.Color = color;
        }

        public GraphNodeColor Color { get; set; }

        public IList<GraphNode<T>> Children { get; protected set; }

        public T Body { get; set; }

        #region Clone

        public virtual object Clone()
        {
            return (object)this.CloneShallow();
        }

        /// <summary>
        /// Overload of this.Clone() by return value
        /// </summary>
        /// <returns></returns>
        public virtual GraphNode<T> CloneShallow()
        {
            return new GraphNode<T>(this.Body, this.Children, this.Color);
        }

        #endregion Clone

        #region Public Methods

        /// <summary>
        /// This method add connection to this. In result nodes appears in Connections property of each other.
        /// </summary>
        /// <param name="node"></param>
        protected internal void Connect(GraphNode<T> node)
        {
            if (object.ReferenceEquals(node, null))
            {
                throw new ArgumentNullException();
            }

            this.Children.Add(node);
        }

        protected internal void Disconnect(GraphNode<T> node)
        {
            if (object.ReferenceEquals(node, null))
            {
                throw new ArgumentNullException();
            }

            this.Children.Remove(node);
        }

        #endregion Public Methods
    }
}