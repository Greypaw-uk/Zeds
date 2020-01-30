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
        private static Vector2 adjustedCoordinates;

        public static void PlaceAStructure(Texture2D texture)
        {
            //Adjust coordinates to ensure that texture is central to mouse cursor position
            adjustedCoordinates = new Vector2(Engine.Engine.MouseCoordinates.X - texture.Width, Engine.Engine.MouseCoordinates.Y - texture.Height);

            Engine.Engine.Blueprint = new Rectangle((int)adjustedCoordinates.X, (int)adjustedCoordinates.Y, texture.Width, texture.Height);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && IsGroundClear)
            {
                Tent.CreateSmallTent(adjustedCoordinates, Engine.Engine.Blueprint);

                IsGroundClear = false;
                IsPlacingBuilding = false;
            }
        }
        
        public static void CheckIfGroundClear(Rectangle blueprint)
        {
            foreach (var building in EntityLists.BuildingList)
            {
                IsGroundClear = !Engine.Engine.Blueprint.Intersects(building.BRec);
            }
        }
    }
}