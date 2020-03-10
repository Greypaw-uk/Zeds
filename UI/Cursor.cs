using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.BuildingLogic;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class Cursor
    {
        private static Vector2 adjustedMouseCoordinates;

        public static Rectangle CursorRectangle = new Rectangle((int) Engine.Engine.MouseCoordinates.X - 5,
            (int)Engine.Engine.MouseCoordinates.Y - 5, 10, 10);


        public static void UpdateCursorRectangleLocation()
        {
            CursorRectangle.X = (int)Engine.Engine.MouseCoordinates.X - 5;
            CursorRectangle.Y = (int)Engine.Engine.MouseCoordinates.Y - 5;
        }

        public static void DrawCursor()
        {
            if (!BuildingPlacementHandler.IsPlacingBuilding)
                Engine.Engine.SpriteBatch.Draw(Textures.CursorTexture, Engine.Engine.MouseCoordinates, Color.White);
        }

        public static void DrawDozerCursor()
        {
            if (Bulldozer.IsDemolitionLegal)
                Engine.Engine.SpriteBatch.Draw(Textures.DozerTexture, Engine.Engine.MouseCoordinates, Color.White);
            else
                Engine.Engine.SpriteBatch.Draw(Textures.DozerDeniedTexture, Engine.Engine.MouseCoordinates, Color.White);
        }

        public static void GetMouseCoordinates()
        {
            //ToDo 2 Align in-game coordinates with Windows coordinates 
            // see http://community.monogame.net/t/mouse-position-in-fullscreen-app/7263

            Vector2 resolution = new Vector2
            {
                X = 1.0f,
                Y = 1.0f
                //X = (Engine.Engine.PreferredBackBufferWidth * 1.0f) / Engine.Engine.ScreenHeight,
                //Y = (Engine.Engine.PreferredBackBufferHeight * 1.0f) / Engine.Engine.ScreenHeight
            };

            adjustedMouseCoordinates = new Vector2
            {
                X = Mouse.GetState().X * resolution.X,
                Y = Mouse.GetState().Y * resolution.Y
            };

            Engine.Engine.MouseCoordinates = adjustedMouseCoordinates;
        }
    }
}