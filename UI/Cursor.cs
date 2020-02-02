using Microsoft.Xna.Framework;
using Zeds.BuildingLogic;

namespace Zeds.Engine
{
    public static class Cursor
    {
        public static Rectangle CursorRectangle = new Rectangle((int)CursorRectangleLocation.X, (int)CursorRectangleLocation.Y, 30, 30);
        public static Vector2 CursorRectangleLocation = Engine.MouseCoordinates;

        public static void UpdateCursorRectangleLocation()
        {
            CursorRectangle.X = (int)Engine.MouseCoordinates.X;
            CursorRectangle.Y = (int)Engine.MouseCoordinates.Y;
        }

        public static void DrawCursor()
        {
            if (!BuildingPlacementHandler.IsPlacingBuilding)
                Engine.SpriteBatch.Draw(Textures.CursorTexture, Engine.MouseCoordinates, Color.White);
            //ToDo 2 Add cursor for demolition mode
        }
    }
}