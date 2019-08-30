using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds
{
    public static class Variables
    {
        public static SpriteBatch spriteBatch;

        // Textures
        public static Texture2D backgroundTexture;
        public static Texture2D humanTexture;
        public static Texture2D zedTexture;

        // Screen setup
        public static GraphicsDeviceManager graphics;
        public static GraphicsDevice device;
        public static int PreferredBackBufferWidth { get; set; }
        public static int PreferredBackBufferHeight { get; set; }
        public static bool IsFullScreen { get; set; }
        public static int screenWidth;
        public static int screenHeight;

        public static int survivorQuantity = 1;
        public static int zedQuantity = 3;

        public static Vector2 mapCentre()
        {
            Vector2 mapCentre = new Vector2
            {
                X = screenWidth / 2,
                Y = screenHeight / 2
            };

            return mapCentre;
        }
    }
}
