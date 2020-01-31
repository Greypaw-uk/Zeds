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
        private GraphicsDevice device;

        public static Vector2 CameraPosition;
        public static Camera Camera;

        public static int MapSizeX;
        public static int MapSizeY;

        public static Vector2 MouseCoordinates;


        //UI
        public static bool IsDebugEnabled;
        public static Rectangle Blueprint;
        public static bool IsBuildMenuOpen;


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
            device = GraphicsDevice;

            Window.Title = "Zeds - Alpha";

            IsMouseVisible = false;

            KeyBindings.PreviousScrollValue = 0;

            RollOverText.RollOverTextPosition.X = 0;
            RollOverText.RollOverTextPosition.Y = 0;

            base.Initialize();

            ZedController.PopulateZedList();
            PopulateMenus.PopulateMenuIconList();
        }

        protected override void LoadContent()
        {
            Fonts.DebugFont = Content.Load<SpriteFont>("DebugFont");

            //Textures
            Textures.BackgroundTexture = Content.Load<Texture2D>("background");
            Textures.HumanTexture = Content.Load<Texture2D>("Human1");
            Textures.ZedTexture = Content.Load<Texture2D>("BasicZed");

            Textures.HqTexture = Content.Load<Texture2D>("HQ");
            Textures.SmallTentTexture = Content.Load<Texture2D>("SmallTent");

            Textures.BuildMenuIconTexture = Content.Load<Texture2D>("BuildMenuIcon");

            Textures.CursorTexture = Content.Load<Texture2D>("cursor");

            Textures.tempIcon = Content.Load<Texture2D>("tempIcon");

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


            if (BuildingPlacementHandler.IsPlacingBuilding)
                BuildingPlacementHandler.PlaceAStructure(Textures.SmallTentTexture);

            if (BuildingPlacementHandler.IsPlacingBuilding)
                BuildingPlacementHandler.CheckIfGroundClear(Blueprint);


            ZedController.IncreaseZeds();
            ZedMovement.CalculateZedMovement();

            HumanMovement.RunFromZeds();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(Camera);

            RenderBackground.DrawBackground();
            DrawMenus.DrawMainMenuIcons();
            DrawStructures.DrawBuildings();
            DrawHumanPawns.DrawHumans();
            DrawZedPawns.DrawZeds();

            Cursor.DrawCursor();

            if (IsBuildMenuOpen)
                DrawMenus.DrawBuildMenuIcons();

            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                if (BuildingPlacementHandler.CheckIfGroundClear(Blueprint))
                    SpriteBatch.Draw(Textures.SmallTentTexture, MouseCoordinates, Color.Green);
                else
                    SpriteBatch.Draw(Textures.SmallTentTexture, MouseCoordinates, Color.Red);
            }

            if (RollOverText.IsRollOverTextVisible)
                RollOverText.DrawUIText(RollOverText.RollOverTxt);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}