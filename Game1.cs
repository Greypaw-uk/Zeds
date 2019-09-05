using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using static Zeds.ZedController;
using static Zeds.HumanController;

using static Zeds.Graphics;
using static Zeds.Variables;


namespace Zeds
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Screen Setup
            PreferredBackBufferWidth = 800;
            PreferredBackBufferHeight = 600;
            IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Zeds";
            base.Initialize();

            mapCentre();
            PopulateZedList();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Screen setup
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = GraphicsDevice;

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            // TODO: use this.Content to load your game content here

            backgroundTexture = Content.Load<Texture2D>("background");
            humanTexture = Content.Load<Texture2D>("human");
            zedTexture = Content.Load<Texture2D>("zed");

            SpawnHumans();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            IncreaseZeds();
            StopZedsBunching();
            CalculateZedMovement();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
                spriteBatch.Draw(backgroundTexture, Vector2.Zero);
                DrawHumans();
                DrawZeds();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
