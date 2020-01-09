using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Zeds.BuildingLogic;
using Zeds.ZedLogic;
using static Zeds.Engine.DefaultSettings;
using static Zeds.Graphics.ResolutionHandler;
using static Zeds.ZedLogic.ZedController;

using static Zeds.Graphics.DrawHumanPawns;
using static Zeds.Graphics.DrawZedPawns;
using static Zeds.Graphics.DrawMenus;
using static Zeds.Graphics.DrawStructures;
using static Zeds.Graphics.RenderBackground;

namespace Zeds.Engine
{
    public class Zeds : Game
    {
        public static SpriteBatch SpriteBatch;

        public Zeds()
        {
            DefaultSettings.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Screen Setup
            resolution = Resolution.Three;

            //Set game play area to screen size
            PreferredBackBufferWidth = ScreenWidth;
            PreferredBackBufferHeight = ScreenHeight;

            //DefaultSettings.Graphics.IsFullScreen = true;
            DefaultSettings.Graphics.IsFullScreen = false;

            IsFullScreen = false;

            //Handle manual screen resizing
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;

            void Window_ClientSizeChanged(object sender, EventArgs e)
            {
                PreferredBackBufferWidth = Window.ClientBounds.Width;
                PreferredBackBufferHeight = Window.ClientBounds.Height;
            }

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


            //Textures
            BackgroundTexture = Content.Load<Texture2D>("background");
            HumanTexture = Content.Load<Texture2D>("Human1");
            ZedTexture = Content.Load<Texture2D>("BasicZed");

            HqTexture = Content.Load<Texture2D>("HQ");
            SmallTentTexture = Content.Load<Texture2D>("SmallTent");

            BuildMenuIconTexture = Content.Load<Texture2D>("BuildMenuIcon");


            //Initial set up
            HQ.HQSetup();
            Tent.SmallTent();
            HumanSpawner.SpawnHumans();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                resolution = Resolution.One;
                SetResolution();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad2))
            {
                resolution = Resolution.Two;
                SetResolution();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad3))
            {
                resolution = Resolution.Three;
                SetResolution();
            }

            DefaultSettings.Graphics.ApplyChanges();

            IncreaseZeds();
            ZedMovement.CalculateZedMovement();

            HumanMovement.RunFromZeds();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //TODO Adjust scaling to screenResolution
            SpriteBatch.Begin();

            DrawBackground();

            DrawBuildMenu();

            DrawBuildings();
            DrawHumans();
            DrawZeds();
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}