using static Zeds.Engine.DefaultSettings;

namespace Zeds.Graphics
{
    class ResolutionHandler
    {
        public enum Resolution
        {
            One, //800 x 600
            Two, //1600 x 900,
            Three //1920 x 1080
        }

        public static Resolution resolution;

        public static void SetResolution()
        {
            switch (resolution)
            {
                case ResolutionHandler.Resolution.One:
                {
                    ScreenWidth = 800;
                    ScreenHeight = 600;

                    PreferredBackBufferWidth = 800;
                    PreferredBackBufferHeight = 600;
                }
                    break;
                case ResolutionHandler.Resolution.Two:
                {
                    ScreenWidth = 1600;
                    ScreenHeight = 900;

                    PreferredBackBufferWidth = 1600;
                    PreferredBackBufferHeight = 900;
                }
                    break;
                case ResolutionHandler.Resolution.Three:
                {
                    ScreenWidth = 1920;
                    ScreenHeight = 1080;

                    PreferredBackBufferWidth = 1920;
                    PreferredBackBufferHeight = 1080;
                }
                    break;
            }
        }
    }
}
