using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Graphics.Background;

namespace Zeds.Engine
{
    public static class Textures
    {
        #region Terrain
        //Terrain
        public static Texture2D BackgroundTexture;
        public static Texture2D GrassTuftTexture;
        public static Texture2D GrassTuft2Texture;
        public static Texture2D GrassTuft3Texture;
        public static Texture2D GrassTuft4Texture;

        public static Texture2D Bush1Texture;
        public static Texture2D Bush2Texture;
        public static Texture2D Bush3Texture;
        public static Texture2D Bush4Texture;

        public static Texture2D Tree1Texture;
        public static Texture2D Tree2Texture;
        public static Texture2D Tree3Texture;
        public static Texture2D Tree4Texture;

        public static Texture2D TreeFoliage1;
        #endregion

        #region Pawns
        //Pawns
        public static Texture2D HumanMale1Texture;
        public static Texture2D HumanFemale1Texture;
        public static Texture2D ZedTexture;
        #endregion

        #region Structures
        //Structures
        public static Texture2D HqTexture;
        public static Texture2D SmallTentTexture;
        public static Texture2D LargeTentTexture;
        public static Texture2D CabinTexture;

        //Ruined Structures
        public static Texture2D RuinedSmallTent;
        public static Texture2D RuinedLargeTent;
        public static Texture2D RuinedCabin;
        public static Texture2D RuinedHQ;
        #endregion

        #region Interface

        public static Texture2D CloseMenu;

        //Build Menus
        public static Texture2D BlankWindowPane;

        public static Texture2D BuildMenuPane;
        public static Texture2D BuildMenuIcon;
        public static Texture2D DemolishIcon;
        public static Texture2D TempMenuIcon;
        public static Texture2D SmallTentBuildIcon;
        public static Texture2D LargeTentBuildIcon;

        //Debug
        public static Texture2D DebugSquareSmall;
        public static Texture2D DebugSquareLarge;
        public static Texture2D OnePixel;

        //DetailsPane
        public static Texture2D DetailsWindowPane;
        public static Texture2D HealthBarOuter;
        public static Texture2D HealthBarInner;

        //InfoPane
        public static Texture2D PawnInfoPane;
        public static Texture2D InfoPawnOutline;
        public static Texture2D SelectedEntity;
        public static Texture2D InfoHead;
        public static Texture2D InfoChest;
        public static Texture2D InfoHand;
        public static Texture2D InfoMisc;

        //Cursors
        public static Texture2D CursorTexture;
        public static Texture2D DozerTexture;
        public static Texture2D DozerDeniedTexture;

        //Misc
        public static Texture2D ExtendArrow;
        #endregion

        #region Items
        // Weapons
        public static Texture2D KitchenKnife;
        public static Texture2D CombatKnife;
        #endregion


        public static void LoadTextures(ContentManager Content)
        {
            #region Terrain 
            //Maps
            BackgroundTexture = Content.Load<Texture2D>("Terrain/background");

            GrassTuftTexture = Content.Load<Texture2D>("Terrain/Grass/grasstuft");
            GrassTuft2Texture = Content.Load<Texture2D>("Terrain/Grass/grasstufttwo");
            GrassTuft3Texture = Content.Load<Texture2D>("Terrain/Grass/grasstuftthree");
            GrassTuft4Texture = Content.Load<Texture2D>("Terrain/Grass/grasstuftfour");

            Bush1Texture = Content.Load<Texture2D>("Terrain/Bushes/bush1");
            Bush2Texture = Content.Load<Texture2D>("Terrain/Bushes/bush2");
            Bush3Texture = Content.Load<Texture2D>("Terrain/Bushes/bush3");
            Bush4Texture = Content.Load<Texture2D>("Terrain/Bushes/bush4");

            Tree1Texture = Content.Load<Texture2D>("Terrain/Tree/tree1");
            Tree2Texture = Content.Load<Texture2D>("Terrain/Tree/tree2");
            Tree3Texture = Content.Load<Texture2D>("Terrain/Tree/tree3");
            Tree4Texture = Content.Load<Texture2D>("Terrain/Tree/tree4");

            TreeFoliage1 = Content.Load<Texture2D>("Terrain/Tree/Tree1Folliage");
            #endregion

            #region Pawns
            //Pawns
            HumanMale1Texture = Content.Load<Texture2D>("Pawns/Human/HumanMale1");
            HumanFemale1Texture = Content.Load<Texture2D>("Pawns/Human/HumanFemale1");
            ZedTexture = Content.Load<Texture2D>("Pawns/Zed/BasicZed");
            #endregion

            #region Structures
            //Structures
            HqTexture = Content.Load<Texture2D>("Buildings/HQTexture");
            SmallTentTexture = Content.Load<Texture2D>("Buildings/SmallTent");
            LargeTentTexture = Content.Load<Texture2D>("Buildings/LargeTent");
            CabinTexture = Content.Load<Texture2D>("Buildings/CabinTexture");

            //Ruined Structures
            RuinedSmallTent = Content.Load<Texture2D>("Buildings/RuinedSmallTent");
            RuinedLargeTent = Content.Load<Texture2D>("Buildings/RuinedLargeTent");
            RuinedCabin = Content.Load<Texture2D>("Buildings/RuinedCabin");
            RuinedHQ = Content.Load<Texture2D>("Buildings/RuinedHQTexture");
            #endregion

            #region Interface

            CloseMenu = Content.Load<Texture2D>("Interface/CloseMenu");

            //Cursors
            CursorTexture = Content.Load<Texture2D>("Interface/Cursors/cursor");
            DozerTexture = Content.Load<Texture2D>("Interface/Cursors/DozerIcon");
            DozerDeniedTexture = Content.Load<Texture2D>("Interface/Cursors/DozerDeniedIcon");

            //Menu Panes
            BlankWindowPane = Content.Load<Texture2D>("Interface/Menus/BlankWindowPane");
            DetailsWindowPane = Content.Load<Texture2D>("Interface/Menus/DetailsWindowPane");
            BuildMenuPane = Content.Load<Texture2D>("Interface/Menus/BuildMenuPane");

            //Pawn Info Panel
            PawnInfoPane = Content.Load<Texture2D>("Interface/Menus/PawnInfoPane");
            InfoPawnOutline = Content.Load<Texture2D>("Interface/Menus/PawnOutline");
            SelectedEntity = Content.Load<Texture2D>("Interface/Menus/SelectedEntity");
            InfoHead = Content.Load<Texture2D>("Interface/Menus/InfoHead");
            InfoChest = Content.Load<Texture2D>("Interface/Menus/InfoChest");
            InfoHand = Content.Load<Texture2D>("Interface/Menus/InfoHand");
            InfoMisc = Content.Load<Texture2D>("Interface/Menus/InfoMisc");

            //Menu Icons
            BuildMenuIcon = Content.Load<Texture2D>("Interface/Menus/BuildMenuIcon");
            DemolishIcon = Content.Load<Texture2D>("Interface/Menus/Bulldozer");
            TempMenuIcon = Content.Load<Texture2D>("Interface/Menus/tempIcon");
            SmallTentBuildIcon = Content.Load<Texture2D>("Interface/Menus/SmallTentBuildIcon");
            LargeTentBuildIcon = Content.Load<Texture2D>("Interface/Menus/LargeTentBuildIcon");

            DebugSquareSmall = Content.Load<Texture2D>("Interface/Debug/DebugSquareSmall");
            DebugSquareLarge = Content.Load<Texture2D>("Interface/Debug/DebugSquareLarge");
            OnePixel = Content.Load<Texture2D>("Interface/Debug/1px");

            HealthBarOuter = Content.Load<Texture2D>("Interface/HealthBar");
            HealthBarInner = Content.Load<Texture2D>("Interface/HealthBarInner");

            //Misc
            ExtendArrow = Content.Load<Texture2D>("Interface/ExtendArrow");
            #endregion

            #region Items
            //Weapons
            KitchenKnife = Content.Load<Texture2D>("Item/Weapon/KitchenKnife");
            CombatKnife = Content.Load<Texture2D>("Item/Weapon/CombatKnife");

            #endregion
        }
    }
}