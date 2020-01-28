using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Comora;
using Zeds.BuildingLogic;
using Zeds.ZedLogic;
using Zeds.Graphics;

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


        // Screen setup
        public static bool ResolutionChanged;
        public static int PreferredBackBufferWidth { get; set; }
        public static int PreferredBackBufferHeight { get; set; }

        public Engine()
        {
            Graphics = new GraphicsDeviceManager(this);
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

            //Set game play area to screen size
            //PreferredBackBufferWidth = MapSizeX;
            //PreferredBackBufferHeight = MapSizeY;

            //Graphics.IsFullScreen = true;
            Graphics.IsFullScreen = false;

            //Handle manual screen resizing
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;

            void Window_ClientSizeChanged(object sender, EventArgs e)
            {
                PreferredBackBufferWidth = Window.ClientBounds.Width;
                PreferredBackBufferHeight = Window.ClientBounds.Height;
            }

            Window.Title = "Engine";

            IsMouseVisible = true;

            base.Initialize();

            ZedController.PopulateZedList();

            KeyBindings.PreviousScrollValue = KeyBindings.CurrentMouseState.ScrollWheelValue;
        }

        protected override void LoadContent()
        {
            //Screen setup
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            device = GraphicsDevice;


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
            Camera.Update(gameTime);
            
            //ToDo Find how to move this into KeyBindings
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyBindings.CheckKeyBindings();
            KeyBindings.CheckMouseBindings();

            if (ResolutionChanged)
            {
                ResolutionHandler.SetResolution();
                Graphics.ApplyChanges();
            }

            Camera.Position = CameraPosition;
            Console.WriteLine("Zoom = " + Camera.Zoom);

            ZedController.IncreaseZeds();
            ZedMovement.CalculateZedMovement();

            HumanMovement.RunFromZeds();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(Camera, SpriteSortMode.Immediate);
                GraphicsDevice.SamplerStates[0].AddressU = TextureAddressMode.Wrap;
                GraphicsDevice.SamplerStates[0].AddressV = TextureAddressMode.Wrap;

                RenderBackground.DrawBackground();
            SpriteBatch.End();

            //TODO Adjust scaling to screenResolution
            SpriteBatch.Begin(Camera);
                DrawMenus.DrawBuildMenu();
                DrawStructures.DrawBuildings();
                DrawHumanPawns.DrawHumans();
                DrawZedPawns.DrawZeds();
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}