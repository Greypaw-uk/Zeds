using System.Linq;
using Microsoft.Xna.Framework;
using Zeds.BuildingLogic;
using Zeds.Engine;
using Zeds.Graphics;

namespace Zeds.UI.Build_Menu
{
    public static class BuildMenuRollOverText
    {
        public static string RollOverTxt;
        public static bool IsBuildMenuRollOverTextVisible;
        private static Vector2 RollOverTextPosition;

        public static void DrawRolloverText(string text)
        {
            if (text != null)
                Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, text, RollOverTextPosition, Color.White);
        }

        public static void UpdateRollOverTextPosition()
        {
            RollOverTextPosition.X = BuildMenuPane.BuildMenuWindow.Location.X + 10;
            RollOverTextPosition.Y = BuildMenuPane.BuildMenuWindow.Location.Y + 10;
        }

        public static void GenerateRollOverText()
        {
            IsBuildMenuRollOverTextVisible = false;

            if (BuildMenuPane.IsBuildMenuWindowVisible)
            {
                if (!BuildingPlacementHandler.IsPlacingBuilding && !Bulldozer.IsBulldozerActive)
                {
                    foreach (var menuIcon in EntityLists.MainIconList.Where(menuIcon => Cursor.CursorRectangle.Intersects(menuIcon.BRec)))
                    {
                        RollOverTxt = menuIcon.MouseOverText;
                            IsBuildMenuRollOverTextVisible = true;
                            break;
                    }

                    if (BuildMenuInteraction.IsBuildMenuOpen)
                    {
                        foreach (var menuIcon in EntityLists.BuildIconList.Where(menuIcon => Cursor.CursorRectangle.Intersects(menuIcon.BRec)))
                        {
                            RollOverTxt = menuIcon.MouseOverText;
                                IsBuildMenuRollOverTextVisible = true;
                                break;
                        }
                    }
                }
            }
        }
    }
}