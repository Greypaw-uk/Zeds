using Microsoft.Xna.Framework;

namespace Zeds.Engine
{
    class Debug
    {
        public static void DrawDebugInfo()
        {
            Engine.SpriteBatch.DrawString(Graphics.Fonts.DebugFont, "Debug = " + Engine.IsDebugEnabled, new Vector2(10, 10), Color.White);
            Engine.SpriteBatch.DrawString(Graphics.Fonts.DebugFont,
                    Engine.MouseCoordinates.X + "," + Engine.MouseCoordinates.Y,
                    new Vector2(Engine.MouseCoordinates.X + 20, Engine.MouseCoordinates.Y), Color.White);
        }
    }
}