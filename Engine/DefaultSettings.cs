using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zeds.BuildingLogic;
using Zeds.Graphics;
using Zeds.ZedLogic;

namespace Zeds.Engine
{
    public static class DefaultSettings
    {
        // Textures
        public static Texture2D BackgroundTexture;
        public static Texture2D HumanTexture;
        public static Texture2D ZedTexture;
        public static Texture2D HqTexture;
        public static Texture2D SmallTentTexture;
        public static Texture2D BuildMenuIconTexture;

        // Screen setup
        public static GraphicsDeviceManager Graphics;

        public static GraphicsDevice Device;
        public static int ScreenWidth;
        public static int ScreenHeight;

        public static int PreferredBackBufferWidth { get; set; }
        public static int PreferredBackBufferHeight { get; set; }
        public static bool IsFullScreen { get; set; }

        // Entity lists
        public static List<Zed> ZedList = new List<Zed>();
        public static List<Human> HumanList = new List<Human>();
        public static List<Building> BuildingList = new List<Building>();
        public static List<DrawMenus.BuildMenuIcon> MainIconList = new List<DrawMenus.BuildMenuIcon>();

        public static Vector2 MapCentre()
        {
            var mapCentre = new Vector2
            {
                X = ScreenWidth / 2 - HumanTexture.Width / 2,
                Y = ScreenHeight / 2 - HumanTexture.Height / 2
            };

            return mapCentre;
        }
    }
}