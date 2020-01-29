using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;

namespace Zeds.BuildingLogic
{
    static class BuildingPlacementHandler
    {
        public static bool IsPlacingBuilding;
        public static bool IsGroundClear;

        public static Vector2 MouseCoordinates;
        public static Texture2D BuildingTexture;

        public static Rectangle Blueprint;

        public static void PlaceAStructure(Texture2D texture)
        {
            BuildingTexture = texture;

            MouseCoordinates.X = Mouse.GetState().X;
            MouseCoordinates.Y = Mouse.GetState().Y;

            //Adjust position of mouse coordinates to ensure the building's centre is at the mouse pointer
            //TODo Change adjustment to place building upon Cursor
            Vector2 adjustedMouseCoordinates = new Vector2(MouseCoordinates.X - texture.Width, MouseCoordinates.Y);

            Blueprint = new Rectangle((int)adjustedMouseCoordinates.X, (int)adjustedMouseCoordinates.Y, texture.Width, texture.Height);

            foreach (var building in EntityLists.BuildingList)
            {
                IsGroundClear = !Blueprint.Intersects(building.BRec);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && IsGroundClear)
            {
                Tent.CreateSmallTent(adjustedMouseCoordinates, Blueprint);

                IsGroundClear = false;
                IsPlacingBuilding = false;
            }
        }
    }
}