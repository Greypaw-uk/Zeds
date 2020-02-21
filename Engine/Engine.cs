﻿using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Zeds.BuildingLogic;
using Zeds.Graphics;
using Zeds.HumanLogic;
using Zeds.UI;
using Zeds.ZedLogic;

namespace Zeds.Engine
{
    public class Engine : Game
    {
        public static SpriteBatch SpriteBatch;

        public static GraphicsDeviceManager Graphics;

        public static Vector2 CameraPosition;
        public static Camera Camera;

        public static int MapSizeX;
        public static int MapSizeY;

        //ToDo 2 Align in-game coordinates with Windows coordinates 
        // see http://community.monogame.net/t/mouse-position-in-fullscreen-app/7263
        public static Vector2 MouseCoordinates;


        //UI
        public static Rectangle Blueprint;


        // Screen setup
        public static bool ResolutionChanged;
        //public static int ScreenWidth = 1600;
        //public static int ScreenHeight = 1200;

        public static int ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public static int PreferredBackBufferWidth { get; set; }
        public static int PreferredBackBufferHeight { get; set; }

        public Engine()
        {
            Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = ScreenWidth,
                PreferredBackBufferHeight = ScreenHeight,

                //HardwareModeSwitch = fullscreen if true, border-less fullscreen if false
                IsFullScreen = false,
                //HardwareModeSwitch = false
            };

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Textures.LoadTextures(this.Content);

            Camera = new Camera(Graphics.GraphicsDevice);
            CameraPosition = Map.MapCentre();

            // Screen Setup
            //ResolutionHandler.resolution = ResolutionHandler.Resolution.Three;

            MapSizeX = 1000;
            MapSizeY = 1000;

            //Handle manual screen resizing
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += WindowSizeChanged;

            //ToDo 3 Move to new class
            void WindowSizeChanged(object sender, EventArgs e)
            {
                ScreenWidth = Window.ClientBounds.Width;
                ScreenHeight = Window.ClientBounds.Height;

                PreferredBackBufferWidth = Window.ClientBounds.Width;
                PreferredBackBufferHeight = Window.ClientBounds.Height;
            }

            //Screen setup
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Window.Title = "Zeds - Alpha";

            //Mouse
            IsMouseVisible = false;
            MouseCoordinates.X = 0;
            MouseCoordinates.Y = 0;


            KeyBindings.PreviousScrollValue = 0;


            GrassTufts.CreateGrassTufts();

            //Build Menu
            BuildingPlacementHandler.SelectedStructure = BuildingSelected.None;

            PopulateMenus.PopulateMenuIconList();
            BuildMenuPane.InitialiseBuildMenuLocation();
            BuildMenuPane.IsBuildMenuWindowVisible = true;
            RollOverText.UpdateRollOverTextPosition();

            DetailsPane.CreateDetailsPane(new Vector2(0,0), "" );

            base.Initialize();

            ZedController.PopulateZedList();
        }

        protected override void LoadContent()
        {
            Fonts.DebugFont = Content.Load<SpriteFont>("DebugFont");


            //Initial set up
            HQ.HQSetup();
            HumanSpawner.SpawnHumans();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Camera.Update(gameTime);

            /*
            //ToDo 3 Move to new class
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            */

            //ToDo 1 Fix mouse getting 'stuck' in fullscreen mode
            // This is probably relevant to the position of the Windows mouse location vs Monogame's mouse location
            MouseCoordinates.X = Mouse.GetState().X;
            MouseCoordinates.Y = Mouse.GetState().Y;


            if (ResolutionChanged)
            {
                ResolutionHandler.SetResolution();
                Graphics.ApplyChanges();
            }


            Camera.Position = CameraPosition;


            RollOverText.GenerateRollOverText();


            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                BuildingPlacementHandler.CheckIfGroundClear(Blueprint);
                BuildingPlacementHandler.PlaceAStructure(BuildingPlacementHandler.SetBuildingTexture());
            }


            //Menu 
            if (!Bulldozer.IsBulldozerActive)
                MenuInteraction.CheckCursorMenuInteraction(Cursor.CursorRectangle);

            if (MenuInteraction.IsBuildMenuOpen && !Bulldozer.IsBulldozerActive)
                MenuInteraction.CheckBuildIconInteraction();

            if (BuildMenuPane.IsBuildMenuWindowVisible && !Bulldozer.IsBulldozerActive)
                BuildMenuPane.UpdateBuildMenuWindowLocation();


            //DetailsPane.CheckForDetailsPaneMovement();
            DetailsPane.DetailsPaneInteraction();
            

            ZedController.IncreaseZeds();


            //Building Removal
            if (Bulldozer.IsBulldozerActive)
                Bulldozer.DemolishStructure();

            //Movement
            ZedMovement.CalculateZedMovement();
            HumanMovement.RunFromZeds();

            Cursor.UpdateCursorRectangleLocation();

            CheckMouseStateChange.UpdateMouseState();
            KeyBindings.CheckForKeyInput();
            KeyBindings.CheckForMouseInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(Camera);

            RenderBackground.DrawBackground();
            GrassTufts.DrawGrassTufts();


            DrawStructures.DrawBuildings();
            DrawHumanPawns.DrawHumans();
            DrawZedPawns.DrawZeds();


            if (BuildMenuPane.IsBuildMenuWindowVisible)
            {
                DrawMenus.DrawBuildMenuPane();
                DrawMenus.DrawMainMenuIcons();
            }

            if (BuildMenuPane.IsBuildMenuWindowVisible && MenuInteraction.IsBuildMenuOpen)
                DrawMenus.DrawBuildMenuIcons();

            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                if (BuildingPlacementHandler.CheckIfGroundClear(Blueprint))
                    SpriteBatch.Draw(BuildingPlacementHandler.SetBuildingTexture(), MouseCoordinates, Color.Green);
                else
                    SpriteBatch.Draw(BuildingPlacementHandler.SetBuildingTexture(), MouseCoordinates, Color.Red);
            }

            if (RollOverText.IsRollOverTextVisible)
                RollOverText.DrawRolloverText(RollOverText.RollOverTxt);


            DetailsPane.DrawDetailsPane();

            if (!Bulldozer.IsBulldozerActive)
                Cursor.DrawCursor();
            else
                Cursor.DrawDozerCursor();


            if (Debug.IsDebugEnabled)
                Debug.DrawDebugInfo();

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}