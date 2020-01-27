using Microsoft.Xna.Framework;

namespace Zeds.Graphics
{
    public static class RenderBackground
    {
        public static void DrawBackground()
        {
            //Vector2 position = new Vector2();

            /*
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture,
                new Rectangle((int) position.X, (int) position.Y, Engine.Engine.PreferredBackBufferWidth, Engine.Engine.PreferredBackBufferHeight),
                new Rectangle(0, 0, Engine.Engine.PreferredBackBufferWidth, Engine.Engine.PreferredBackBufferHeight), Color.White);
            */

            /*
            //ToDo Check sizing of background compared to RenderTarget
            Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture,
                new Rectangle(0, 0, Engine.Engine.MapSizeX, Engine.Engine.MapSizeY),
                new Rectangle(0, 0, Engine.Engine.MapSizeX, Engine.Engine.MapSizeY), Color.White);
            */
            
            
            Engine.Engine.SpriteBatch.Draw(Engine.Engine.RenderTarget, new Rectangle(0, 0, 
                Engine.Engine.MapSizeX, Engine.Engine.MapSizeY), Color.White);

            //Engine.Engine.SpriteBatch.Draw(Textures.BackgroundTexture, Vector2.Zero, Color.White);
        }
    }
}
