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

        //TODO add texture scaling 
        public static void SetResolution()
        {
            switch (resolution)
            {
                case Resolution.One:
                    {
                        Engine.Zeds.ScreenWidth = 800;
                        Engine.Zeds.ScreenHeight = 600;
                    }
                    break;
                case Resolution.Two:
                    {
                        Engine.Zeds.ScreenWidth = 1600;
                        Engine.Zeds.ScreenHeight = 900;
                    }
                    break;
                case Resolution.Three:
                    {
                        Engine.Zeds.ScreenWidth = 1920;
                        Engine.Zeds.ScreenHeight = 1080;
                    }
                    break;
            }

            Console.WriteLine("Resolution changed to " + resolution);

            Engine.Zeds.PreferredBackBufferWidth = Engine.Zeds.ScreenWidth;
            Engine.Zeds.PreferredBackBufferHeight = Engine.Zeds.ScreenHeight;

            Zeds.Engine.Zeds.Graphics.ApplyChanges();
        }
    }
}