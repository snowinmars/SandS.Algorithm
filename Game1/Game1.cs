using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Poly2Tri;
using SandS.Algorithm.CommonNamespace;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game1
{
    public static class A
    {
        #region Public Methods

        public static Color NextColor(this Random rnd)
        {
            return new Color(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }

        #endregion Public Methods
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Private Fields

        private BasicEffect effect;
        private GraphicsDeviceManager graphics;
        private Matrix projectionMatrix;
        private SpriteBatch spriteBatch;
        private IList<VertexPositionColor> triangleVertices;
        private VertexBuffer vertexBuffer;
        private Matrix viewMatrix;
        private Matrix worldMatrix;

        #endregion Private Fields

        #region Public Constructors

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";

            this.IsMouseVisible = true;
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.GraphicsDevice.SetVertexBuffer(this.vertexBuffer); // due to buffer can change in Update()

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>
                    (PrimitiveType.TriangleList, this.triangleVertices.ToArray(), 0, this.triangleVertices.Count / 3);
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.triangleVertices = new List<VertexPositionColor>();

            this.InitializeMatrix();

            this.InitializeTriangles();

            this.InitializeVertexBuffer();

            this.InitializeEffect();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            this.vertexBuffer.SetData(this.triangleVertices.ToArray());

            base.Update(gameTime);
        }

        #endregion Protected Methods

        #region Private Methods

        private static PolygonPoint[] GetPoints()
        {
            return new[]
            {
                new PolygonPoint(0,0),
                new PolygonPoint(5,0),
                new PolygonPoint(5,-3),
                new PolygonPoint(1,-4),
                new PolygonPoint(1,-5),
                new PolygonPoint(5,-5),
                new PolygonPoint(5,-6),
                new PolygonPoint(-1,-6),
                new PolygonPoint(-1,-4),
                new PolygonPoint(-4,-4),
                new PolygonPoint(-4,-2),
                new PolygonPoint(0,-2),
            };
        }

        private void InitializeEffect()
        {
            this.effect = new BasicEffect(this.GraphicsDevice)
            {
                VertexColorEnabled = true,
                World = this.worldMatrix,
                View = this.viewMatrix,
                Projection = this.projectionMatrix
            };
        }

        private void InitializeMatrix()
        {
            this.viewMatrix = Matrix.CreateLookAt(cameraPosition: new Vector3(0, 0, 16),
                                                    cameraTarget: Vector3.Zero,
                                                    cameraUpVector: Vector3.Up);

            this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                    this.GraphicsDevice.DisplayMode.AspectRatio,
                                                    nearPlaneDistance: 1,
                                                    farPlaneDistance: 100);

            this.worldMatrix = Matrix.CreateWorld(position: new Vector3(0, 0, 0),
                                                    forward: Vector3.Forward,
                                                    up: Vector3.Up);
        }

        private void InitializeTriangles()
        {
            Polygon p = new Polygon(Game1.GetPoints());

            P2T.Triangulate(p);

            this.MapPolygonTrianglesToVertexPositions(p);
        }

        private void MapPolygonTrianglesToVertexPositions(Polygon p)
        {
            foreach (var tr in p.Triangles)
            {
                Vector3 v0 = new Vector3((float)tr.Points._0.X, (float)tr.Points._0.Y, 0);
                Vector3 v1 = new Vector3((float)tr.Points._1.X, (float)tr.Points._1.Y, 0);
                Vector3 v2 = new Vector3((float)tr.Points._2.X, (float)tr.Points._2.Y, 0);

                this.triangleVertices.Add(new VertexPositionColor(v2, CommonValues.Random.NextColor()));
                this.triangleVertices.Add(new VertexPositionColor(v1, CommonValues.Random.NextColor()));
                this.triangleVertices.Add(new VertexPositionColor(v0, CommonValues.Random.NextColor()));
            }
        }

        private void InitializeVertexBuffer()
        {
            this.vertexBuffer = new VertexBuffer(this.GraphicsDevice,
                                            typeof(VertexPositionColor), this.triangleVertices.Count,
                                            BufferUsage.None);
        }

        #endregion Private Methods
    }
}