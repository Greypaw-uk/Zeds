using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Comora;
using Zeds.BuildingLogic;
using Zeds.ZedLogic;
using Zeds.Graphics;
using static Zeds.Graphics.RenderTargetHandler;

namespace Zeds.Engine
{
    public class Engine : Game
    {
        public static SpriteBatch SpriteBatch;

        public static GraphicsDeviceManager Graphics;
        public static GraphicsDevice Device;
        
        private Vector2 cameraPosition;

        public static int MapSizeX;
        public static int MapSizeY;

        private Camera camera;

        // Screen setup
        public static RenderTarget2D RenderTarget;
        public static int ScreenWidth;
        public static int ScreenHeight;
        //public static int PreferredBackBufferWidth { get; set; }
        //public static int PreferredBackBufferHeight { get; set; }

        public Engine()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            camera = new Camera(Graphics.GraphicsDevice);
            cameraPosition = Map.MapCentre();

            // Screen Setup
            ResolutionHandler.resolution = ResolutionHandler.Resolution.Three;

            Graphics.GraphicsProfile = GraphicsProfile.HiDef;

            MapSizeX = 1000;
            MapSizeY = 1000;

            RenderTarget = new RenderTarget2D(
                GraphicsDevice, 
                MapSizeX,
                MapSizeY,
                false,
                GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);

            /*Set game play area to screen size
            //ToDo Change from BackBuffer to RenderTarget   
            PreferredBackBufferWidth = 10000;
            PreferredBackBufferHeight = 10000;
            */

            //Graphics.IsFullScreen = true;
            Graphics.IsFullScreen = false;

            //Handle manual screen resizing
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;

            void Window_ClientSizeChanged(object sender, EventArgs e)
            {
                ScreenWidth = Window.ClientBounds.Width;
                ScreenHeight = Window.ClientBounds.Height;
            }

            Window.Title = "Engine";

            IsMouseVisible = true;

            base.Initialize();

            ZedController.PopulateZedList();
        }

        protected override void LoadContent()
        {
            //Screen setup
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Device = GraphicsDevice;

            ScreenWidth = Device.PresentationParameters.BackBufferWidth;
            ScreenHeight = Device.PresentationParameters.BackBufferHeight;


            //Textures
            Textures.BackgroundTexture = Content.Load<Texture2D>("background");
            Textures.HumanTexture = Content.Load<Texture2D>("Human1");
            Textures.ZedTexture = Content.Load<Texture2D>("BasicZed");

            Textures.HqTexture = Content.Load<Texture2D>("HQ");
            Textures.SmallTentTexture = Content.Load<Texture2D>("SmallTent");

            Textures.BuildMenuIconTexture = Content.Load<Texture2D>("BuildMenuIcon");


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
            camera.Update(gameTime);
            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Move Camera
            // ToDo Change from ScreenWidth to RenderTarget
            if (Keyboard.GetState().IsKeyDown(Keys.A) && cameraPosition.X >= 0)
                cameraPosition.X -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.D) && cameraPosition.X <= ScreenWidth)
                cameraPosition.X += 10;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && cameraPosition.Y >= 0)
                cameraPosition.Y -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.S) && cameraPosition.Y <= ScreenHeight)
                cameraPosition.Y += 10;

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad9))
                camera.Height -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad7))
                camera.Height += 10;

            camera.Position = cameraPosition;

            /*
            //Toggle Resolution Test
            var resolutionChanged = false;

            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                ResolutionHandler.resolution = ResolutionHandler.Resolution.One;
                resolutionChanged = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                ResolutionHandler.resolution = ResolutionHandler.Resolution.Two;
                resolutionChanged = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                ResolutionHandler.resolution = ResolutionHandler.Resolution.Three;
                resolutionChanged = true;
            }

            if(resolutionChanged)
            {
                ResolutionHandler.SetResolution();
                Graphics.ApplyChanges();
            }
            */

            ZedController.IncreaseZeds();
            ZedMovement.CalculateZedMovement();

            HumanMovement.RunFromZeds();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //DrawSceneToTexture(RenderTarget);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            //TODO Adjust scaling to screenResolution
            SpriteBatch.Begin(camera);

            RenderBackground.DrawBackground();

            DrawMenus.DrawBuildMenu();

            DrawStructures.DrawBuildings();
            DrawHumanPawns.DrawHumans();
            DrawZedPawns.DrawZeds();
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}