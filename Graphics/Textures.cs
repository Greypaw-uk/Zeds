﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds.Engine
{
    public static class Textures
    {
        public static Texture2D BackgroundTexture;
        public static Texture2D GrassTuftTexture;
        public static Texture2D GrassTuft2Texture;
        public static Texture2D GrassTuft3Texture;
        public static Texture2D GrassTuft4Texture;

        public static Texture2D HumanTexture;
        public static Texture2D ZedTexture;

        public static Texture2D CursorTexture;
        public static Texture2D DozerTexture;

        public static Texture2D HqTexture;
        public static Texture2D SmallTentTexture;
        public static Texture2D LargeTentTexture;

        public static Texture2D BlankWindowPane;
        public static Texture2D BuildMenuPane;
        public static Texture2D BuildMenuIcon;
        public static Texture2D DemolishIcon;
        public static Texture2D TempMenuIcon;
        public static Texture2D SmallTentBuildIcon;
        public static Texture2D LargeTentBuildIcon;

        public static Texture2D DebugSquare;

        public static void LoadTextures(ContentManager Content)
        {
            //Maps
            BackgroundTexture = Content.Load<Texture2D>("background");
            GrassTuftTexture = Content.Load<Texture2D>("grasstuft");
            GrassTuft2Texture = Content.Load<Texture2D>("grasstufttwo");
            GrassTuft3Texture = Content.Load<Texture2D>("grasstuftthree");
            GrassTuft4Texture = Content.Load<Texture2D>("grasstuftfour");

            //Pawns
            HumanTexture = Content.Load<Texture2D>("Human1");
            ZedTexture = Content.Load<Texture2D>("BasicZed");

            //Structures
            HqTexture = Content.Load<Texture2D>("HQ");
            SmallTentTexture = Content.Load<Texture2D>("SmallTent");
            LargeTentTexture = Content.Load<Texture2D>("LargeTent");

            //Cursors
            CursorTexture = Content.Load<Texture2D>("cursor");
            DozerTexture = Content.Load<Texture2D>("DozerIcon");

            //Menu Panes
            BlankWindowPane = Content.Load<Texture2D>("BlankWindowPane");
            BuildMenuPane = Content.Load<Texture2D>("BuildMenuPane");

            //Menu Icons
            BuildMenuIcon = Content.Load<Texture2D>("BuildMenuIcon");
            DemolishIcon = Content.Load<Texture2D>("Bulldozer");
            TempMenuIcon = Content.Load<Texture2D>("tempIcon");
            SmallTentBuildIcon = Content.Load<Texture2D>("SmallTentBuildIcon");
            LargeTentBuildIcon = Content.Load<Texture2D>("LargeTentBuildIcon");

            DebugSquare = Content.Load<Texture2D>("DebugSquare");
        }
    }
}