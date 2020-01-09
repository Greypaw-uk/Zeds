using Microsoft.Xna.Framework;
using static Zeds.Engine.Zeds;
using static Zeds.Engine.DefaultSettings;

namespace Zeds.Graphics
{
    static class RenderBackground
    {
        public static void DrawBackground()
        {
            Vector2 position = new Vector2();

            SpriteBatch.Draw(BackgroundTexture,
                new Rectangle((int) position.X, (int) position.Y, PreferredBackBufferWidth, PreferredBackBufferHeight),
                new Rectangle(0, 0, PreferredBackBufferWidth, PreferredBackBufferHeight), Color.White);

            SpriteBatch.Draw(BackgroundTexture, Vector2.Zero, Color.White);
        }
    }
}
