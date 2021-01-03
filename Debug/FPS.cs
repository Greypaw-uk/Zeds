using Microsoft.Xna.Framework;
using Zeds.Graphics;

namespace Zeds.Debug
{
    public class FPS
    {
        private double frames = 0;
        private double elapsed = 0;
        private double last = 0;
        private double now = 0;
        private readonly double msgFrequency = 1.0f;
        private string msg = "";
        private double updates = 0;

        public void Update(GameTime gameTime)
        {
            now = gameTime.TotalGameTime.TotalSeconds;
            elapsed = (now - last);
            if (elapsed > msgFrequency)
            {
                msg = "FPS: " + (int)(frames / elapsed) +
                      "\nUpdates: " + updates;

                elapsed = 0;
                frames = 0;
                updates = 0;
                last = now;
            }

            updates++;
        }

        public void DrawFps()
        {
            Vector2 fpsLocation = new Vector2 {X = 0, Y = 0};
            Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, msg, fpsLocation, Color.White);
            frames++;
        }
    }
}
