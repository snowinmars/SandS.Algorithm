using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.Graph;

namespace SandS.Algorithm.Library.Menu
{
    public class Menu<TMenunode, TBody> : ICloneable
        where TMenunode : MenuNode<TBody>
    {
        #region Protected Fields

        protected readonly GraphTree<TMenunode, TBody> graph;

        #endregion Protected Fields

        #region Public Constructors

        public Menu() : this(new GraphTree<TMenunode, TBody>())
        {
        }

        public Menu(IEnumerable<TMenunode> nodes) : this(new GraphTree<TMenunode, TBody>(nodes))
        {
        }

        #endregion Public Constructors

        #region Protected Internal Constructors

        protected internal Menu(GraphTree<TMenunode, TBody> graph)
        {
            this.graph = graph;
            this.graph.State = GraphState.Default;
        }

        #endregion Protected Internal Constructors

        #region Public Properties

        public IList<TMenunode> Nodes => this.graph.Nodes;

        public GraphState State
        {
            get
            {
                return this.graph.State;
            }
            set
            {
                this.graph.State = value;
            }
        }

        #endregion Public Properties

        #region Clone

        public object Clone()
        {
            return this.ShallowClone();
        }

        /// <summary>
        /// Overload of this.Clone() by return value
        /// </summary>
        /// <returns></returns>
        public GraphTree<TMenunode, TBody> ShallowClone()
        {
            return new GraphTree<TMenunode, TBody>(this.Nodes);
        }

        public GraphTree<TMenunode, TBody> DeepClone()
        {
            IList<TMenunode> newNodes = this.Nodes.ToList();

            return new GraphTree<TMenunode, TBody>(newNodes)
            {
                State = this.State,
            };
        }

        #endregion Clone
    }
}
