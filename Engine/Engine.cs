using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        private SpriteFont font;

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
            CameraPosition.X = MapSizeX / 2;
            CameraPosition.Y = MapSizeY / 2;

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

            Window.Title = "Zeds - Alpha";

            KeyBindings.PreviousScrollValue = 0;
            IsMouseVisible = true;

            base.Initialize();

            ZedController.PopulateZedList();
        }

        protected override void LoadContent()
        {
            //Screen setup
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            device = GraphicsDevice;

            font = Content.Load<SpriteFont>("font");

            //Textures
            Textures.BackgroundTexture = Content.Load<Texture2D>("background");
            Textures.HumanTexture = Content.Load<Texture2D>("Human1");
            Textures.ZedTexture = Content.Load<Texture2D>("BasicZed");

            Textures.HqTexture = Content.Load<Texture2D>("HQ");
            Textures.SmallTentTexture = Content.Load<Texture2D>("SmallTent");

            Textures.BuildMenuIconTexture = Content.Load<Texture2D>("BuildMenuIcon");

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

            //ToDo Fix display of this text
            if (isDebugEnabled)
                SpriteBatch.DrawString(font, BuildingPlacementHandler.MouseCoordinates.X + "," + BuildingPlacementHandler.MouseCoordinates.Y,
                    new Vector2(BuildingPlacementHandler.MouseCoordinates.X + 10, BuildingPlacementHandler.MouseCoordinates.X - 10), Color.Red);

            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                SpriteBatch.Draw(BuildingPlacementHandler.BuildingTexture, BuildingPlacementHandler.MouseCoordinates,
                    BuildingPlacementHandler.Blueprint,
                    !BuildingPlacementHandler.IsGroundClear ? Color.Red : Color.Green);
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}