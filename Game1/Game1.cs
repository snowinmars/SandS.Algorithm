using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandS.Algorithm.Library.Generator;
using SandS.Algorithm.Library.MenuNamespace;
using SandS.Algorithm.Library.PositionNamespace;
using SandS.Algorithm.Library.StorageNamespace;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Labyrinth labyrinth;

        private Texture2D Up;
        private Texture2D Down;
        private Texture2D Left;
        private Texture2D Right;
        private Texture2D Free;


        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";

            int x = 15;
            int y = 15;

            labyrinth = LabyrinthGeneratorStrategies.DFS(new Position(x, y));

            Glade glade = new Glade
            {
                Form = Form.Circle,
                Size = 4,
            };

            LabyrinthGeneratorStrategies.MakeGlades(labyrinth, glade, 1);

            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Add your initialization logic here

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            Up = Content.Load<Texture2D>("Up");
            Down = Content.Load<Texture2D>("Down");
            Left = Content.Load<Texture2D>("Left");
            Right = Content.Load<Texture2D>("Right");
            Free = Content.Load<Texture2D>("Free");

            // use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            // Add your drawing code here

            this.spriteBatch.Begin();

            foreach (var cell in labyrinth.Cells)
            {
                if (cell.Type.HasFlag(LabyrinthCellType.BorderUp)) 
                {
                    spriteBatch.Draw(Up, new Vector2(cell.Position.X * 10, cell.Position.Y * 10), Color.White);
                }

                if (cell.Type.HasFlag(LabyrinthCellType.BorderDown))
                {
                    spriteBatch.Draw(Down, new Vector2(cell.Position.X * 10, cell.Position.Y * 10), Color.White);
                }

                if (cell.Type.HasFlag(LabyrinthCellType.BorderLeft))
                {
                    spriteBatch.Draw(Left, new Vector2(cell.Position.X * 10, cell.Position.Y * 10), Color.White);
                }

                if (cell.Type.HasFlag(LabyrinthCellType.BorderRight))
                {
                    spriteBatch.Draw(Right, new Vector2(cell.Position.X * 10, cell.Position.Y * 10), Color.White);
                }
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}