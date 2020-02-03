using System;
using Microsoft.Xna.Framework;
using Zeds.Engine;
using Zeds.Graphics;

namespace Zeds.UI
{
    public static class RollOverText
    {
        public static string RollOverTxt;
        public static bool IsRollOverTextVisible;
        public static Vector2 RollOverTextPosition;

        //ToDo 2 Move Rollover text nearer to the icon
        public static void DrawRolloverText(String text)
        {
            Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, text, RollOverTextPosition, Color.White);
        }

        //ToDo !Test
        public static void GenerateRollOverText()
        {
            foreach (var menuIcon in EntityLists.MainIconList)
            {
                if (Cursor.CursorRectangle.Intersects(menuIcon.BRec))
                {
                    RollOverTxt = menuIcon.MouseOverText;
                    IsRollOverTextVisible = true;
                }
                else
                {
                    IsRollOverTextVisible = false;
                }
            }

            foreach (var menuIcon in EntityLists.BuildIconList)
            {
                if (Cursor.CursorRectangle.Intersects(menuIcon.BRec))
                {
                    RollOverTxt = menuIcon.MouseOverText;
                    IsRollOverTextVisible = true;
                }
                else
                {
                    IsRollOverTextVisible = false;
                }
            }
        }
    }
}