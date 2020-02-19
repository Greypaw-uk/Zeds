using System;
using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Graphics
{
    static class RenderBackground
    {
        public static void DrawBackground()
        {
            var backgroundRec = new Rectangle(0, 0, Engine.Engine.MapSizeX, Engine.Engine.MapSizeY);
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture, backgroundRec, Color.White);

        }
    }
}