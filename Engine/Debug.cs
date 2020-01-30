using Microsoft.Xna.Framework;

namespace Zeds.Engine
{
    class Debug
    {
        public static void DrawDebugInfo()
        {
            Engine.SpriteBatch.DrawString(Engine.Font, "Debug = " + Engine.isDebugEnabled, new Vector2(10, 10), Color.White);
            Engine.SpriteBatch.DrawString(Engine.Font,
                    Engine.MouseCoordinates.X + "," + Engine.MouseCoordinates.Y,
                    new Vector2(Engine.MouseCoordinates.X, Engine.MouseCoordinates.Y), Color.White);
        }
    }
}
