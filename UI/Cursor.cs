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
            CursorRectangle.X = (int)Engine.Engine.MouseCoordinates.X;
            CursorRectangle.Y = (int)Engine.Engine.MouseCoordinates.Y;
        }

        public static void DrawCursor()
        {
            if (!BuildingPlacementHandler.IsPlacingBuilding)
                Engine.Engine.SpriteBatch.Draw(Textures.CursorTexture, Engine.Engine.MouseCoordinates, Color.White);
            //ToDo 3 Add cursor for demolition mode
        }

        public static void DrawDozerCursor()
        {
            Engine.Engine.SpriteBatch.Draw(Textures.DozerTexture, Engine.Engine.MouseCoordinates, Color.White);
        }
    }
}