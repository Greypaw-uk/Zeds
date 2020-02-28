using Microsoft.Xna.Framework;
using Zeds.BuildingLogic;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class Cursor
    {
        public static Rectangle CursorRectangle = new Rectangle((int) Engine.Engine.MouseCoordinates.X - 5,
            (int) Engine.Engine.MouseCoordinates.Y - 5, 10, 10);


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
    }
}