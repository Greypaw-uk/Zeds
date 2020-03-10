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

        //ToDo 2 add texture scaling 
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

            Engine.Engine.Graphics.PreferredBackBufferWidth = Engine.Engine.ScreenWidth;
            Engine.Engine.Graphics.PreferredBackBufferHeight = Engine.Engine.ScreenHeight;

            Engine.Engine.Graphics.ApplyChanges();
        }


        /*
         Code used to update Resolution
         
        protected override void Update(GameTime gameTime)
        {
            if(userClickedTheResolutionChangeButton)
            {
                graphics.IsFullScreen = userRequestedFullScreen;
                graphics.PreferredBackBufferHeight = userRequestedHeight;
                graphics.PreferredBackBufferWidth = userRequestedWidth;
                graphics.ApplyChanges();
            }
        }
        */
    }
}