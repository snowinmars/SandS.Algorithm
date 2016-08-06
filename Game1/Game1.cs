using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandS.Algorithm.Extensions.GraphicsDeviceExtension;
using SandS.Algorithm.Library.Menu;
using SandS.Algorithm.Library.Position;
using SandS.Algorithm.Library.Storage;

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

            FontStorage.Instance.Initialize(this.Content);
            TextureStorage.Instance.Initialize(this.Content, this.GraphicsDevice);

            this.Menu.Initialize();

            MenuNode<MenuNodeBody> head = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head,
                                                                    "HEAD",
                                                                    new Drawable(),
                                                                    this.Menu.Position,
                                                                    0));

            MenuNode<MenuNodeBody> start = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head,
                                                                    "Start",
                                                                    new Drawable(),
                                                                    this.Menu.Position,
                                                                    1));

            MenuNode<MenuNodeBody> settings = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head,
                                                                    "Settings",
                                                                    new Drawable(),
                                                                    this.Menu.Position,
                                                                    2));

            MenuNode<MenuNodeBody> exit = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head,
                                                                    "Exit",
                                                                    new Drawable(),
                                                                    this.Menu.Position,
                                                                    3));

            MenuNode<MenuNodeBody> audio = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head,
                                                                    "Audio",
                                                                    new Drawable(),
                                                                    this.Menu.Position,
                                                                    4));

            MenuNode<MenuNodeBody> video = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head,
                                                                    "Video",
                                                                    new Drawable(),
                                                                    this.Menu.Position,
                                                                    5));

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