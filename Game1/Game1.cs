using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandS.Algorithm.Extensions.GraphicsDeviceExtension;
using SandS.Algorithm.Library.Menu;
using SandS.Algorithm.Library.Position;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private readonly Menu<MenuNode<MenuNodeBody>, MenuNodeBody> Menu;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.Menu = new Menu<MenuNode<MenuNodeBody>, MenuNodeBody>(new Position(0,0));
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

            this.Menu.Initialize();
            
            MenuNode<MenuNodeBody> head = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head,
                                                                    "HEAD", 
                                                                    new Drawable(GraphicsDevice.Generate(10,10,Color.AliceBlue)),
                                                                    new Rectangle(10,10,10,10) ));

            var start = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node,
                                                                    "Start",
                                                                    new Drawable(GraphicsDevice.Generate(10, 10, Color.AliceBlue)),
                                                                    new Rectangle(10, 10, 10, 10)));

            var settings = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node,
                                                                    "Settings",
                                                                    new Drawable(GraphicsDevice.Generate(10, 10, Color.AliceBlue)),
                                                                    new Rectangle(10, 10, 10, 10)));

            var audio = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node,
                                                                    "Audio",
                                                                    new Drawable(GraphicsDevice.Generate(10, 10, Color.AliceBlue)),
                                                                    new Rectangle(10, 10, 10, 10)));

            var video = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node,
                                                                    "Video",
                                                                    new Drawable(GraphicsDevice.Generate(10, 10, Color.AliceBlue)),
                                                                    new Rectangle(10, 10, 10, 10)));

            var exit = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node,
                                                                    "Exit",
                                                                    new Drawable(GraphicsDevice.Generate(10, 10, Color.AliceBlue)),
                                                                    new Rectangle(10, 10, 10, 10)));

            this.Menu.Connect(head, start);
            this.Menu.Connect(head, settings);
            this.Menu.Connect(head, exit);
            this.Menu.Connect(settings, audio);
            this.Menu.Connect(settings, video);

            this.Menu.AddNode(head);

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

            this.Menu.LoadContent(this.Content, this.GraphicsDevice);
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

            this.Menu.Update(gameTime);

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

            this.Menu.Draw(gameTime, this.spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}