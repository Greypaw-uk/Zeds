using System;
using Microsoft.Xna.Framework;
using Zeds.BuildingLogic;
using Zeds.Engine;
using Zeds.Graphics;

namespace Zeds.UI
{
    public static class RollOverText
    {
        public static string RollOverTxt;
        public static bool IsRollOverTextVisible;
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
            IsRollOverTextVisible = false;

            if (!BuildMenuPane.IsBuildMenuWindowVisible)
            {
                if (!BuildingPlacementHandler.IsPlacingBuilding)
                {
                    foreach (var menuIcon in EntityLists.MainIconList)
                    {
                        if (Cursor.CursorRectangle.Intersects(menuIcon.BRec))
                        {
                            RollOverTxt = menuIcon.MouseOverText;
                            IsRollOverTextVisible = true;
                            break;
                        }
                    }

                    if (MenuInteraction.IsBuildMenuOpen)
                    {
                        foreach (var menuIcon in EntityLists.BuildIconList)
                        {
                            if (Cursor.CursorRectangle.Intersects(menuIcon.BRec))
                            {
                                RollOverTxt = menuIcon.MouseOverText;
                                IsRollOverTextVisible = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}