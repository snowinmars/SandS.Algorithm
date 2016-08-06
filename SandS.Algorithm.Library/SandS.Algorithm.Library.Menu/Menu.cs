using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SandS.Algorithm.Library.Graph;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using SandS.Algorithm.Extensions.GraphicsDeviceExtension;

namespace SandS.Algorithm.Library.Menu
{
    public class Menu<TMenunode, TBody> : ICloneable, IHasGraphTree<TMenunode, TBody>, IUpdateable, IDrawable, ICanLoadContent, IInitializable
        where TMenunode : MenuNode<TBody>
        where TBody : MenuNodeBody
    {
        #region Protected Fields

        protected readonly GraphTree<TMenunode, TBody> graph;

        #endregion Protected Fields

        #region Public Constructors

        public Menu(Position.Position position) : this(position, new GraphTree<TMenunode, TBody>())
        {
        }

        public Menu(Position.Position position, IEnumerable<TMenunode> nodes) : this(position,new GraphTree<TMenunode, TBody>(nodes))
        {
        }

        #endregion Public Constructors

        #region Protected Internal Constructors

        protected internal Menu(Position.Position position, GraphTree<TMenunode, TBody> graph)
        {
            this.graph = graph;
            this.graph.State = GraphState.Default;
            this.Position = position;
        }

        #endregion Protected Internal Constructors

        #region Public Properties

        public IList<TMenunode> Nodes => this.graph.Nodes;

        public TMenunode DrawingNode { get; set; }

        public Position.Position Position { get; set; }

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

        #endregion Clone

        #region IHasGraphTree

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

        public Guid Id
        {
            get
            {
                return this.graph.Id;
            }
        }

        public void AddNode(TMenunode node)
            => this.graph.AddNode(node);

        public void Connect(TMenunode lhs, TMenunode rhs)
            => this.graph.Connect(lhs, rhs);

        public bool IsCycle(bool haveClearColor = true)
            => this.graph.IsCycle(haveClearColor);

        public bool IsLooped()
            => this.graph.IsLooped();

        public bool IsNonConnectivity()
            => this.graph.IsNonConnectivity();

        public bool IsRouteBetween(TMenunode startNode, TMenunode endNode)
            => this.IsRouteBetween(startNode, endNode);

        public void RemoveNode(TMenunode node)
            => this.RemoveNode(node);

        #endregion IHasGraphTree

        #region IUpdateable

        public bool Enabled { get; set; }

        public int UpdateOrder { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public void Update(GameTime gameTime)
        {
            this.DrawingNode.Body.Update(gameTime);

            foreach (var node in this.DrawingNode.Children)
            {
                node.Body.Update(gameTime);
            }
        }

        #endregion IUpdateable

        #region IDrawable

        public int DrawOrder { get; set; }

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            foreach (var node in this.DrawingNode.Children)
            {
                node.Body.Draw(gameTime, sb);
            }
        }

        

        #endregion IDrawable

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            if (this.graph.Nodes.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.DrawingNode = this.graph.Nodes[0];
        }
    }
}