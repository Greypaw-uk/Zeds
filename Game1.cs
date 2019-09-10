using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using static Zeds.ZedController;
using static Zeds.HumanController;

using static Zeds.Graphics;
using static Zeds.Engine;
using static Zeds.Buildings;

namespace Zeds
{
    public class Game1 : Game
    {
        public static SpriteBatch SpriteBatch;

        public Game1()
        {
            Engine.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Screen Setup
            resolution = Resolution.Three;
                //Set game play area to screen size
                PreferredBackBufferWidth = ScreenWidth;
                PreferredBackBufferHeight = ScreenHeight;
            //Engine.Graphics.IsFullScreen = true;
            Engine.Graphics.IsFullScreen = false;

                //Handle manual screen resizing
                Window.AllowUserResizing = true;
                Window.ClientSizeChanged += (Window_ClientSizeChanged);

                void Window_ClientSizeChanged(object sender, EventArgs e)
                {
                    Engine.Graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                    Engine.Graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
                    Engine.Graphics.ApplyChanges();

                    MapCentre();

                    //TODO Re-align assets with new window size
            }
            Engine.Graphics.ApplyChanges();

            Window.Title = "Zeds";

            IsMouseVisible = true;

            base.Initialize();

            PopulateZedList();
        }

        protected override void LoadContent()
        {
            //Screen setup
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Device = GraphicsDevice;

            ScreenWidth = Device.PresentationParameters.BackBufferWidth;
            ScreenHeight = Device.PresentationParameters.BackBufferHeight;

            BackgroundTexture = Content.Load<Texture2D>("background");
            HumanTexture = Content.Load<Texture2D>("Human1");
            ZedTexture = Content.Load<Texture2D>("BasicZed");

            HqTexture = Content.Load<Texture2D>("HQ");
            SmallTentTexture = Content.Load<Texture2D>("SmallTent");

            HQSetup();
            SmallTent();
            SpawnHumans();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            IncreaseZeds();
            CalculateZedMovement();

            RunFromZeds();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //TODO Adjust scaling to screenResolution
            SpriteBatch.Begin();
                SpriteBatch.Draw(BackgroundTexture, Vector2.Zero);
                DrawBuildings();
                DrawHumans();
                DrawZeds();
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
