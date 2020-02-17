using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Zeds.BuildingLogic;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class MenuInteraction
    {
        public static bool IsBuildMenuOpen;

        public static void CheckCursorMenuInteraction(Rectangle cursor)
        {
            if (!BuildingPlacementHandler.IsPlacingBuilding)
            {
                foreach (var item in EntityLists.MainIconList)
                {
                    if (cursor.Intersects(item.BRec))
                        if (item.Texture == Textures.BuildMenuIcon && Mouse.GetState().LeftButton == ButtonState.Pressed)
                            IsBuildMenuOpen = true;
                }
            }
        }


        public static void CheckBuildIconInteraction()
        {
            var intersecting = false;
            string buildingType = string.Empty;

            foreach (var icon in EntityLists.BuildIconList)
                if (Cursor.CursorRectangle.Intersects(icon.BRec) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    intersecting = true;
                    buildingType = icon.Name;
                }

            if (intersecting)
            {
                BuildingPlacementHandler.IsPlacingBuilding = true;
                IsBuildMenuOpen = false;

                switch (buildingType)
                {
                    case "Small Tent":
                    {
                        BuildingPlacementHandler.SelectedStructure = BuildingSelected.SmallTent;
                        break;
                    }
                    case "Large Tent":
                    {
                        BuildingPlacementHandler.SelectedStructure = BuildingSelected.LargeTent;
                        break;
                    }
                }
            }
        }
    }
}