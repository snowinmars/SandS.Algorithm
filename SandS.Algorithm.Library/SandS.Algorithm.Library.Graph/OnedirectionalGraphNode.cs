using System;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.GraphNamespace
{
    public class OnedirectionalGraphNode<T> : AbstractGraphNode<T>, ICloneable
    {
        public OnedirectionalGraphNode(T body, IEnumerable<AbstractGraphNode<T>> connections = null, GraphNodeColor color = GraphNodeColor.White) : base(body, connections, color)
        {
        }

        public override GraphNodeColor Color { get; set; }

        public override IList<AbstractGraphNode<T>> Children { get; protected set; }

        public override T Body { get; set; }

        #region Clone

        public virtual object Clone()
        {
            return (object)this.CloneShallow();
        }

        /// <summary>
        /// Overload of this.Clone() by return value
        /// </summary>
        /// <returns></returns>
        public virtual OnedirectionalGraphNode<T> CloneShallow()
        {
            return new OnedirectionalGraphNode<T>(this.Body, this.Children, this.Color);
        }

        #endregion Clone

        #region Public Methods

        /// <summary>
        /// This method add connection to this. In result nodes appears in Connections property of each other.
        /// </summary>
        /// <param name="node"></param>
        internal override void Connect(AbstractGraphNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            this.Children.Add(node);
        }

        internal override void Disconnect(AbstractGraphNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            this.Children.Remove(node);
        }

        #endregion Public Methods
    }
}