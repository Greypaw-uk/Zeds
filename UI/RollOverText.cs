using System;
using Microsoft.Xna.Framework;
using Zeds.Graphics;

namespace Zeds.UI
{
    public static class RollOverText
    {
        public static string RollOverTxt;
        public static bool IsRollOverTextVisible;
        public static Vector2 RollOverTextPosition;

        public static void DrawUIText(String text)
        {
            Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, text, RollOverTextPosition, Color.White);
        }
    }
}
