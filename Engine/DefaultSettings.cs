using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.ZedLogic;

namespace Zeds
{
    public static class DefaultSettings
    {
        public enum Resolution
        {
            One, //800 x 600
            Two, //1600 x 900,
            Three //1920 x 1080
        }

        public static Resolution resolution;


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
        public static int PreferredBackBufferWidth { get; set; }
        public static int PreferredBackBufferHeight { get; set; }
        public static bool IsFullScreen { get; set; }
        public static int ScreenWidth;
        public static int ScreenHeight;

        // Entity lists
        public static List<Zed> ZedList = new List<Zed>();

        public static List<Human> HumanList = new List<Human>();
        public static List<Building> BuildingList = new List<Building>();

        public static List<BuildMenuIcon> MainIconList = new List<BuildMenuIcon>();

        public static void SetResolution()
        {
            switch (resolution)
            {
                case Resolution.One:
                {
                    ScreenWidth = 800;
                    ScreenHeight = 600;
                }
                    break;
                case Resolution.Two:
                {
                    ScreenWidth = 1600;
                    ScreenHeight = 900;
                }
                    break;
                case Resolution.Three:
                {
                    ScreenWidth = 1920;
                    ScreenHeight = 1080;
                }
                    break;
            }
        }
    }
}