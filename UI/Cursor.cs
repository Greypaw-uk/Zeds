using Microsoft.Xna.Framework;
using Zeds.BuildingLogic;

namespace Zeds.Engine
{
    static class Cursor
    {
        public static Rectangle CursorRectangle;
        public static Vector2 CursorRectangleLocation;

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