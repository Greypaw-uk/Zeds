using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Graphics
{
    static class RenderBackground
    {
        public static void DrawBackground()
        {
            Vector2 position = new Vector2();

            Engine.Zeds.SpriteBatch.Draw(Textures.BackgroundTexture,
                new Rectangle((int) position.X, (int) position.Y, Engine.Zeds.PreferredBackBufferWidth, Engine.Zeds.PreferredBackBufferHeight),
                new Rectangle(0, 0, Engine.Zeds.PreferredBackBufferWidth, Engine.Zeds.PreferredBackBufferHeight), Color.White);

            Engine.Zeds.SpriteBatch.Draw(Textures.BackgroundTexture, Vector2.Zero, Color.White);
        }
    }
}
