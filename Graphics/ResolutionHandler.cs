using System;

namespace Zeds.Graphics
{
    static class ResolutionHandler
    {
        public enum Resolution
        {
            One, //800 x 600
            Two, //1600 x 900,
            Three //1920 x 1080
        }

        public static Resolution resolution;

        //TODO 2 add texture scaling 
        public static void SetResolution()
        {
            switch (resolution)
            {
                case Resolution.One:
                    {
                        Engine.Engine.ScreenWidth = 800;
                        Engine.Engine.ScreenHeight = 600;
                    }
                    break;
                case Resolution.Two:
                    {
                        Engine.Engine.ScreenWidth = 1600;
                        Engine.Engine.ScreenHeight = 900;
                    }
                    break;
                case Resolution.Three:
                    {
                        Engine.Engine.ScreenWidth = 1920;
                        Engine.Engine.ScreenHeight = 1080;
                    }
                    break;
            }

            Console.WriteLine("Resolution changed to " + resolution);

            Engine.Engine.PreferredBackBufferWidth = Engine.Engine.ScreenWidth;
            Engine.Engine.PreferredBackBufferHeight = Engine.Engine.ScreenHeight;

            Engine.Engine.Graphics.ApplyChanges();
        }
    }
}