using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Zeds.BuildingLogic;
using Zeds.Graphics;
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
        public static bool IsDebugEnabled;
        public static Rectangle Blueprint;
        public static bool IsBuildWindowVisible;
        

        // Screen setup
        public static bool ResolutionChanged;
        public static int ScreenWidth = 800;
        public static int ScreenHeight = 600;
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
            ResolutionHandler.resolution = ResolutionHandler.Resolution.Three;

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


            //Build Menu
            BuildingPlacementHandler.SelectedStructure = BuildingSelected.None;

            PopulateMenus.PopulateMenuIconList();
            BuildMenuPane.InitialiseBuildMenuLocation();
            IsBuildWindowVisible = true;
            RollOverText.UpdateRollOverTextPosition();


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


            KeyBindings.CheckForKeyInput();
            KeyBindings.CheckForMouseInput();


            if (ResolutionChanged)
            {
                ResolutionHandler.SetResolution();
                Graphics.ApplyChanges();
            }


            Camera.Position = CameraPosition;
            Camera.Debug.IsVisible = IsDebugEnabled;


            RollOverText.GenerateRollOverText();


            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                BuildingPlacementHandler.CheckIfGroundClear(Blueprint);
                BuildingPlacementHandler.PlaceAStructure(BuildingPlacementHandler.SetBuildingTexture());
            }


            //Menu 
            MenuInteraction.CheckCursorMenuInteraction(Cursor.CursorRectangle);

            if (MenuInteraction.IsBuildMenuOpen)
                MenuInteraction.CheckBuildIconInteraction();

            BuildMenuPane.UpdateBuildMenuWindowLocation();

            ZedController.IncreaseZeds();


            //Movement
            ZedMovement.CalculateZedMovement();
            HumanMovement.RunFromZeds();

            Cursor.UpdateCursorRectangleLocation();

            CheckMouseState.UpdateMState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(Camera);

            RenderBackground.DrawBackground();

            DrawStructures.DrawBuildings();
            DrawHumanPawns.DrawHumans();
            DrawZedPawns.DrawZeds();


            if (RollOverText.IsRollOverTextVisible)
                RollOverText.DrawRolloverText(RollOverText.RollOverTxt);

            if (BuildMenuPane.IsBuildMenuWindowVisible)
            {
                DrawMenus.DrawBuildMenuPane();
                DrawMenus.DrawMainMenuIcons();
            }

            if (MenuInteraction.IsBuildMenuOpen)
                DrawMenus.DrawBuildMenuIcons();

            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                if (BuildingPlacementHandler.CheckIfGroundClear(Blueprint))
                    SpriteBatch.Draw(BuildingPlacementHandler.SetBuildingTexture(), MouseCoordinates, Color.Green);
                else
                    SpriteBatch.Draw(BuildingPlacementHandler.SetBuildingTexture(), MouseCoordinates, Color.Red);
            }

            Cursor.DrawCursor();

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}