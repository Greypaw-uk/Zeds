using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;

namespace Zeds.BuildingLogic
{
    static class BuildingPlacementHandler
    {
        public static bool IsPlacingBuilding;
        private static Vector2 adjustedCoordinates;

        public static void PlaceAStructure(Texture2D texture)
        {
            adjustedCoordinates = new Vector2(Engine.Engine.MouseCoordinates.X, Engine.Engine.MouseCoordinates.Y);

            Engine.Engine.Blueprint = new Rectangle((int)adjustedCoordinates.X - (texture.Width / 2),
                (int)adjustedCoordinates.Y - (texture.Width / 2), texture.Width, texture.Height);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && CheckIfGroundClear(Engine.Engine.Blueprint))
            {
                Tent.CreateSmallTent(adjustedCoordinates, Engine.Engine.Blueprint);

                IsPlacingBuilding = false;
            }
        }

        public static bool CheckIfGroundClear(Rectangle blueprint)
        {
            foreach (var building in EntityLists.BuildingList)
            {
                if (blueprint.Intersects(building.BRec))
                    return false;
            }

            return true;
        }
    }
}