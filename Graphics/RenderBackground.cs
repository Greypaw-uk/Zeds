using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Graphics
{
    static class RenderBackground
    {
        public static void DrawBackground()
        {
            /*
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture,
                new Rectangle(-(Engine.Engine.MapSizeX / 2), -(Engine.Engine.MapSizeY / 2), Engine.Engine.MapSizeX, Engine.Engine.MapSizeY),
                new Rectangle(0, 0, 2000, 2000), Color.White);
            */

            /*
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture,
                new Rectangle(-(Engine.Engine.MapSizeX / 2), -(Engine.Engine.MapSizeY / 2), Engine.Engine.MapSizeX, Engine.Engine.MapSizeY),
                new Rectangle(-(Engine.Engine.MapSizeX / 2), -(Engine.Engine.MapSizeY / 2), Engine.Engine.MapSizeX, Engine.Engine.MapSizeY), Color.White);
            */
            
            /*
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture,
                new Rectangle(-(Engine.Engine.MapSizeX / 2), -(Engine.Engine.MapSizeY / 2), Engine.Engine.MapSizeX, Engine.Engine.MapSizeY), Color.White);
            */

            //Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture, Vector2.Zero, Color.White);

            Rectangle source = new Rectangle(0, 0, 400, 200);
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture, Vector2.Zero, source, Color.White);
        }
    }
}