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
                        //Engine.Engine.MapSizeX = 800;
                        //Engine.Engine.MapSizeY = 600;

                        Engine.Engine.PreferredBackBufferWidth = 800;
                        Engine.Engine.PreferredBackBufferHeight = 600;
                    }
                    break;
                case Resolution.Two:
                    {
                        //Engine.Engine.MapSizeX = 1600;
                        //Engine.Engine.MapSizeY = 900;

                        Engine.Engine.PreferredBackBufferWidth = 1600;
                        Engine.Engine.PreferredBackBufferHeight = 900;
                    }
                    break;
                case Resolution.Three:
                    {
                        //Engine.Engine.MapSizeX = 1920;
                        //Engine.Engine.MapSizeY = 1080;

                        Engine.Engine.PreferredBackBufferWidth = 1920;
                        Engine.Engine.PreferredBackBufferHeight = 1080;
                    }
                    break;
            }

            Console.WriteLine("Resolution changed to " + resolution);

            //Engine.Engine.PreferredBackBufferWidth = Engine.Engine.MapSizeX;
            //Engine.Engine.PreferredBackBufferHeight = Engine.Engine.MapSizeY;

            Zeds.Engine.Engine.Graphics.ApplyChanges();
        }
    }
}