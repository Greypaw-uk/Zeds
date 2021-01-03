using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.BuildingLogic;
using Zeds.BuildingLogic.RuinedBuildings;
using Zeds.Debug;
using Zeds.Graphics;
using Zeds.Graphics.Background;
using Zeds.Items;
using Zeds.Pathfinding;
using Zeds.Pawns.HumanLogic;
using Zeds.Pawns.ZedLogic;
using Zeds.Resources;
using Zeds.UI;
using Zeds.UI.Build_Menu;
using Zeds.UI.Details_Pane;
using Zeds.UI.HealthBar;
using Zeds.UI.PawnInfoPanel;
using Zeds.UI.PawnInfoPanel.Items_Boxes;
using Zeds.Resources;

namespace Zeds.Engine
{
    public class Engine : Game
    {
        private static readonly string versionNumber = "Alpha 1.3.7";

        public static SpriteBatch SpriteBatch;

        public static GraphicsDeviceManager Graphics;

        public static Vector2 CameraPosition;
        public static Camera Camera;

        public static int MapSizeX;
        public static int MapSizeY;

        readonly FPS fps = new FPS();

        public static Vector2 MouseCoordinates;

        //UI
        public static Rectangle Blueprint;


        // Screen setup
        public static bool ResolutionChanged;

        public static int ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

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

            #region Camera
            Camera = new Camera(Graphics.GraphicsDevice);
            CameraPosition.X = Graphics.PreferredBackBufferWidth * 1.0f / 2;
            CameraPosition.Y = Graphics.PreferredBackBufferHeight * 1.0f / 2;
            #endregion

            #region Screen Setup
            //ResolutionHandler.resolution = ResolutionHandler.Resolution.Three;

            //ToDo 3 Fix to draw background texture to fill all of the background
            MapSizeX = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            MapSizeY = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Window.Title = "Zeds - Alpha " + versionNumber;
            #endregion

            #region Mouse
            IsMouseVisible = false;
            MouseCoordinates.X = Graphics.PreferredBackBufferWidth * 1.0f / 2;
            MouseCoordinates.Y = Graphics.PreferredBackBufferWidth * 1.0f /2;
            KeyBindings.PreviousScrollValue = 0;
            #endregion

            //Initial set up
            HQ.HQSetup();
            HumanNames.PopulateNamesLists();

            HumanSpawner.SpawnHumans();
            GrantStartingItems.PopulateItemList();

            #region Terrain
            GrassTufts.CreateGrassTufts();
            Bushes.CreateBushes();
            Trees.CreateTrees();
            Trees.CreateTreeFoliage();
            #endregion

            #region Build Menu
            BuildingPlacementHandler.SelectedStructure = BuildingSelected.None;

            PopulateBuildMenus.PopulateMenuIconList();
            BuildMenuPane.InitialiseBuildMenuLocation();
            BuildMenuPane.IsBuildMenuWindowVisible = true;
            BuildMenuRollOverText.UpdateRollOverTextPosition();
            #endregion

            DetailsPane.CreateDetailsPane(new Vector2((ScreenWidth / 2) - (Textures.DetailsWindowPane.Width / 2),10), "" );

            base.Initialize();

            ZedController.PopulateZedList();

            Grid.SetUpGrid();
        }

        protected override void LoadContent()
        {
            Fonts.DebugFont = Content.Load<SpriteFont>("Interface/Font/Arial");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Camera.Update(gameTime);

            /*
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            */

            // Mouse
            //ToDo 1 Fix mouse getting 'stuck' in fullscreen mode
            MouseCoordinates = Cursor.GetMouseCoordinates();
            Cursor.GetMouseCoordinates();
            Cursor.UpdateCursorRectangleLocation();

            //Update Tree Foliage Transparency
            Trees.ChangeTreeFoliageTransparency();


            if ( Debug.Debug.IsDebugEnabled)
                fps.Update(gameTime);


            if (ResolutionChanged)
            {
                ResolutionHandler.SetResolution();
                Graphics.ApplyChanges();
            }


            Camera.Position = CameraPosition;


            #region User Interface

            if (BuildMenuPane.IsBuildMenuWindowVisible)
            {
                BuildMenuRollOverText.GenerateRollOverText();
                BuildMenuPane.CloseBuildMenu();
            }


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
            {
                SelectedPawn.UpdateIndicator(SelectedPawn.SelectedHuman);
                ExtendIconChecks.CheckExtendHandClicked();
                PawnInfo.UpdatePawnInfo();
            }
            #endregion

            #region PawnInfoSB
            PawnCursorInteraction.CheckForCursorPawnInteraction();

            if (PawnInfo.IsPawnInfoVisible)
                PawnInfo.ClosePawnInfo();

            if (ExtendIconChecks.IsWeaponIconListVisible)
            {
                EquipWeapon.CheckWeaponIconInteraction();
                CreateItemIcons.UpdateWeaponIconList();
            }

            #endregion

            ZedDeath.CheckZedsHealth();
            RuinedBuilding.CheckBuildingsHealth();
            HumanDeath.CheckHumansHealth();

            ZedController.IncreaseZeds();


            //Building Removal
            if (Bulldozer.IsBulldozerActive)
                Bulldozer.DemolishStructure();

            //Movement
            //HumanMovement.RunFromZeds();
            PathFind.MovePawns();


            CheckMouseStateChange.UpdateMouseState();
            KeyBindings.CheckForKeyInput();
            KeyBindings.CheckForMouseInput();

            Resource.SetResourcesForGathering();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(Camera);

            RenderBackground.DrawBackground();
            GrassTufts.DrawGrassTufts();
            Bushes.DrawBushes();

            DrawHumanPawns.DrawHumans();
            DrawZedPawns.DrawZeds();

            DrawStructures.DrawBuildings();
            RuinedBuilding.DrawRuinedBuildings();

            Trees.DrawTrees();
            Trees.DrawTreeFoliage();
            Resource.DrawGatherIcon();

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


            //Pawn PawnInfoSB
            if (PawnInfo.IsPawnInfoVisible)
            {
                //PawnInfoMenuClose.ClosePawnInfoMenu();
                DrawPawnsInfoPanel.DrawPawnInfoPanel();
                SelectedPawn.DrawSelectedPawnIndicator();
            }
            if (ExtendIconChecks.IsWeaponIconListVisible)
            {
                DrawPawnInfoIcons.DrawWeaponListIcons();
            }


            //Pawn rollover text
            DrawDetailPane.DrawDetailsPane();
            if (DetailsPane.isDetailPaneVisible)
                DrawDetailPane.DrawDetailsPaneText();

            if (!Bulldozer.IsBulldozerActive)
                Cursor.DrawCursor();
            else
                Cursor.DrawDozerCursor();


            if (Zeds.Debug.Debug.IsDebugEnabled)
            {
                Zeds.Debug.Debug.DrawDebugInfo();
                fps.DrawFps();
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}