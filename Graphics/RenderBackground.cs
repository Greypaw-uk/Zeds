using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Graphics
{
    static class RenderBackground
    {
        public static void DrawBackground()
        {
            var backgroundRec = new Rectangle(0, 0, Engine.Engine.ScreenWidth, Engine.Engine.ScreenHeight);
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture, backgroundRec, Color.White);

        }
    }
}