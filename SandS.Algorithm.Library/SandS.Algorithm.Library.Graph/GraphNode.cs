using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.Graph
{
    

    public class GraphNode<T> : ICloneable
    {
        #region Public Constructors

        public GraphNode(T body, IEnumerable<GraphNode<T>> connections = null, GraphNodeColor color = GraphNodeColor.White)
        {
            this.Color = color;

            if (connections == null)
            {
                connections = new List<GraphNode<T>>();
            }

            this.Children = connections.ToList();

            this.Body = body;
        }

        #endregion Public Constructors

        #region Public Properties

        public GraphNodeColor Color { get; set; }

        public IList<GraphNode<T>> Children { get; }

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
        internal void Connect(GraphNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            this.Children.Add(node);
            node.Children.Add(this);
        }

        internal void Disconnect(GraphNode<T> node)
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
