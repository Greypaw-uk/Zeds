using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.UI;
using Zeds.UI.Build_Menu;

namespace Zeds.BuildingLogic
{
    public enum BuildingSelected
    {
        None,
        SmallTent,
        LargeTent
    }

    static class BuildingPlacementHandler
    {
        public static bool IsPlacingBuilding;
        private static Vector2 adjustedCoordinates;
        public static BuildingSelected SelectedStructure;

        public static Texture2D SetBuildingTexture()
        {
            switch (SelectedStructure)
            {
                case BuildingSelected.None:
                    return null;

                case BuildingSelected.SmallTent:
                    return Textures.SmallTentTexture;

                case BuildingSelected.LargeTent:
                    return Textures.LargeTentTexture;
            }

            return null;
        }

        public static void PlaceAStructure(Texture2D texture)
        {
            //ToDo 3 Test necessity of adjustedCoordinates
            adjustedCoordinates = new Vector2(Engine.Engine.MouseCoordinates.X, Engine.Engine.MouseCoordinates.Y);

            Engine.Engine.Blueprint = new Rectangle((int)adjustedCoordinates.X - (texture.Width / 2),
                (int)adjustedCoordinates.Y - (texture.Width / 2), texture.Width, texture.Height);

            if (CheckMouseStateChange.IsMouseClicked() && CheckIfGroundClear(Engine.Engine.Blueprint))
            {
                switch (SelectedStructure)
                {
                    case BuildingSelected.SmallTent:
                        Tent.CreateSmallTent(adjustedCoordinates, Engine.Engine.Blueprint);
                        break;

                    case BuildingSelected.LargeTent:
                        Tent.CreateLargeTent(adjustedCoordinates, Engine.Engine.Blueprint);
                        break;
                }

                IsPlacingBuilding = false;
                BuildMenuInteraction.IsBuildMenuOpen = false;
                SelectedStructure = BuildingSelected.None;
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