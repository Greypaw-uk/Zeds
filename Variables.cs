using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds
{
    public static class Variables
    {
        public static SpriteBatch SpriteBatch;

        // Textures
        public static Texture2D BackgroundTexture;
        public static Texture2D HumanTexture;
        public static Texture2D ZedTexture;

        public static Texture2D HqTexture;
        public static Texture2D SmallTentTexture;

        // Screen setup
        public static GraphicsDeviceManager Graphics;
        public static GraphicsDevice Device;
        public static int PreferredBackBufferWidth { get; set; }
        public static int PreferredBackBufferHeight { get; set; }
        public static bool IsFullScreen { get; set; }
        public static int ScreenWidth;
        public static int ScreenHeight;

        public static int SurvivorQuantity = 1;
        public static int ZedQuantity = 3;

        public static Vector2 MapCentre()
        {
            Vector2 mapCentre = new Vector2
            {
                X = ScreenWidth / 2 - HumanTexture.Width / 2,
                Y = ScreenHeight / 2 - HumanTexture.Height / 2
            };

            return mapCentre;
        }

        public static List<Zed> ZedList = new List<Zed>();
        public static List<Human> HumanList = new List<Human>();
        public static List<Building> BuildingList = new List<Building>();

        public static float PanicDistance = 100f;

    }
}
