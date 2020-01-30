using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Zeds.BuildingLogic;
using Zeds.Graphics;
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
        public static Rectangle Blueprint;

        public static SpriteFont Font;

        public static bool isDebugEnabled;

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

                //Graphics.IsFullScreen = true
                IsFullScreen = false
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

            KeyBindings.PreviousScrollValue = 0;
            //IsMouseVisible = true;

            base.Initialize();

            ZedController.PopulateZedList();
        }

        protected override void LoadContent()
        {
            Font = Content.Load<SpriteFont>("Font");

            //Textures
            Textures.BackgroundTexture = Content.Load<Texture2D>("background");
            Textures.HumanTexture = Content.Load<Texture2D>("Human1");
            Textures.ZedTexture = Content.Load<Texture2D>("BasicZed");

            Textures.HqTexture = Content.Load<Texture2D>("HQ");
            Textures.SmallTentTexture = Content.Load<Texture2D>("SmallTent");

            Textures.BuildMenuIconTexture = Content.Load<Texture2D>("BuildMenuIcon");

            Textures.CursorTexture = Content.Load<Texture2D>("cursor");

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
            //ToDo Find how to move this into KeyBindings
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            */

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

            //TODO Adjust scaling to screenResolution
            SpriteBatch.Begin(Camera);

            RenderBackground.DrawBackground();
            DrawMenus.DrawBuildMenu();
            DrawStructures.DrawBuildings();
            DrawHumanPawns.DrawHumans();
            DrawZedPawns.DrawZeds();


            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                if (!BuildingPlacementHandler.IsGroundClear)
                    SpriteBatch.Draw(Textures.SmallTentTexture, MouseCoordinates, Color.Red);
                else
                    SpriteBatch.Draw(Textures.SmallTentTexture, MouseCoordinates, Color.Green);
            }

            if (isDebugEnabled)
                Debug.DrawDebugInfo();

            if (!BuildingPlacementHandler.IsPlacingBuilding)
                SpriteBatch.Draw(Textures.CursorTexture, MouseCoordinates, Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}