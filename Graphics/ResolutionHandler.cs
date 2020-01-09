using System;
using Zeds.Engine;
using static Zeds.Engine.DefaultSettings;

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

            Console.WriteLine("Resolution changed to " + resolution);

            PreferredBackBufferWidth = ScreenWidth;
            PreferredBackBufferHeight = ScreenHeight;

            DefaultSettings.Graphics.ApplyChanges();
        }
    }
}