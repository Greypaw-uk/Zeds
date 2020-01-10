using Microsoft.Xna.Framework;
using Zeds.Engine;
using static Zeds.Engine.Zeds;

namespace Zeds.Graphics
{
    static class RenderBackground
    {
        public static void DrawBackground()
        {
            Vector2 position = new Vector2();

            SpriteBatch.Draw(Textures.BackgroundTexture,
                new Rectangle((int) position.X, (int) position.Y, PreferredBackBufferWidth, PreferredBackBufferHeight),
                new Rectangle(0, 0, PreferredBackBufferWidth, PreferredBackBufferHeight), Color.White);

            SpriteBatch.Draw(Textures.BackgroundTexture, Vector2.Zero, Color.White);
        }
    }
}
