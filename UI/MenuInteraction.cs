using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.BuildingLogic;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class MenuInteraction
    {
        public static bool IsBuildMenuOpen;

        public static void CheckCursorMenuInteraction(Rectangle cursor)
        {
            foreach (var item in EntityLists.MainIconList)
            {
                if (cursor.Intersects(item.BRec))
                {
                    if (item.Texture == Textures.BuildMenuIcon &&
                        Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        IsBuildMenuOpen = true;
                    }
                }
            }
        }

        public static void CheckSmallTentIconInteraction()
        {
            //ToDo !Test
            if (Cursor.CursorRectangle.Intersects(Textures.TempMenuIcon.Bounds) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                BuildingPlacementHandler.IsPlacingBuilding = true;
                IsBuildMenuOpen = false;

                BuildingPlacementHandler.SelectedStructure = BuildingSelected.SmallTent;
            }
        }
    }
}