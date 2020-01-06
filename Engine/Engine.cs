﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Zeds.ZedLogic;
using static Zeds.DefaultSettings;
using static Zeds.HumanController;
using static Zeds.ZedLogic.ZedController;
using static Zeds.Graphics;

namespace Zeds
{
    public class Game1 : Game
    {
        public static SpriteBatch SpriteBatch;

        public Game1()
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

            //Handle manual screen resizing
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;

            void Window_ClientSizeChanged(object sender, EventArgs e)
            {
                DefaultSettings.Graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                DefaultSettings.Graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
                DefaultSettings.Graphics.ApplyChanges();

                Map.MapCentre();

                //TODO Re-align assets with new window size
            }

            DefaultSettings.Graphics.ApplyChanges();

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

            BuildMenuIconTexture = Content.Load<Texture2D>("BuildMenuIcon");

            HQ.HQSetup();
            Tent.SmallTent();
            SpawnHumans();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
            SpriteBatch.Draw(BackgroundTexture, Vector2.Zero, Color.White);
            DrawBuildMenu();
            DrawBuildings();
            DrawHumans();
            DrawZeds();
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}