using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Zeds.BuildingLogic;
using Zeds.BuildingLogic.RuinedBuildings;
using Zeds.Engine.Debug;
using Zeds.Graphics;
using Zeds.Graphics.Background;
using Zeds.Pawns.HumanLogic;
using Zeds.Pawns.ZedLogic;
using Zeds.UI;
using Zeds.UI.Build_Menu;
using Zeds.UI.Details_Pane;
using Zeds.UI.HealthBar;
using Zeds.UI.PawnInfoPanel;

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

        readonly FPS fps = new FPS();

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


            HumanNames.PopulateNamesLists();


            KeyBindings.PreviousScrollValue = 0;


            GrassTufts.CreateGrassTufts();
            Bushes.CreateBushes();

            //Build Menu
            BuildingPlacementHandler.SelectedStructure = BuildingSelected.None;

            PopulateBuildMenus.PopulateMenuIconList();
            BuildMenuPane.InitialiseBuildMenuLocation();
            BuildMenuPane.IsBuildMenuWindowVisible = true;
            BuildMenuRollOverText.UpdateRollOverTextPosition();

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


            if( Debug.Debug.IsDebugEnabled)
                fps.Update(gameTime);


            if (ResolutionChanged)
            {
                ResolutionHandler.SetResolution();
                Graphics.ApplyChanges();
            }


            Camera.Position = CameraPosition;


            #region User Interface
            BuildMenuRollOverText.GenerateRollOverText();


            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                BuildingPlacementHandler.CheckIfGroundClear(Blueprint);
                BuildingPlacementHandler.PlaceAStructure(BuildingPlacementHandler.SetBuildingTexture());
            }


            //Menu 
            if (!Bulldozer.IsBulldozerActive)
                BuildMenuInteraction.CheckCursorMenuInteraction(Cursor.CursorRectangle);

            if (BuildMenuInteraction.IsBuildMenuOpen && !Bulldozer.IsBulldozerActive)
                BuildMenuInteraction.CheckBuildIconInteraction();

            if (BuildMenuPane.IsBuildMenuWindowVisible && !Bulldozer.IsBulldozerActive)
                BuildMenuPane.UpdateBuildMenuWindowLocation();


            // Details Pane
            DetailsPaneInteraction.CheckForDetailsPaneInteraction();
            DetailsPaneMovement.UpdateDetailsPaneLocation();

            // Selected Pawn
            if (SelectedPawn.SelectedHuman != null)
                SelectedPawn.UpdateIndicator(SelectedPawn.SelectedHuman);

            #endregion


            RuinedBuilding.CheckBuildingsHealth();


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
            RuinedBuilding.DrawRuinedBuildings();
            DrawHumanPawns.DrawHumans();
            DrawZedPawns.DrawZeds();

            Bushes.DrawBushes();


            HealthBar.DrawHealthBar();


            //Build Menus
            if (BuildMenuPane.IsBuildMenuWindowVisible)
            {
                DrawBuildMenus.DrawBuildMenuPane();
                DrawBuildMenus.DrawMainMenuIcons();
            }

            if (BuildMenuPane.IsBuildMenuWindowVisible && BuildMenuInteraction.IsBuildMenuOpen)
                DrawBuildMenus.DrawBuildMenuIcons();

            if (BuildMenuRollOverText.IsBuildMenuRollOverTextVisible)
                BuildMenuRollOverText.DrawRolloverText(BuildMenuRollOverText.RollOverTxt);


            //Building Placement
            if (BuildingPlacementHandler.IsPlacingBuilding)
            {
                if (BuildingPlacementHandler.CheckIfGroundClear(Blueprint))
                    SpriteBatch.Draw(BuildingPlacementHandler.SetBuildingTexture(), MouseCoordinates, Color.Green);
                else
                    SpriteBatch.Draw(BuildingPlacementHandler.SetBuildingTexture(), MouseCoordinates, Color.Red);
            }


            //Pawn info
            if (PawnInfo.IsPawnInfoVisible)
            {
                PawnInfo.DrawPawnInfoPanel();
                SelectedPawn.DrawSelectedPawnIndicator();
            }

            //Pawn rollover text
            DrawDetailPane.DrawDetailsPane();
            if (DetailsPane.isDetailPaneVisible)
                DrawDetailPane.DrawDetailsPaneText();

            if (!Bulldozer.IsBulldozerActive)
                Cursor.DrawCursor();
            else
                Cursor.DrawDozerCursor();


            if (Debug.Debug.IsDebugEnabled)
            {
                Debug.Debug.DrawDebugInfo();
                fps.DrawFps();
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}