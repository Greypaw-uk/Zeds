using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zeds.Engine;

namespace Zeds.UI.Build_Menu
{
    public static class BasicBuildMenu
    {
        public static void CreateBuildMenuIcon(string name, Texture2D texture, Vector2 position, Rectangle bRec, int xOffset, int yOffset, String mouseOverText)
        {
            var menuIcon = new DrawBuildMenus.BuildMenuIcon
            {
                Name = name,
                Texture = texture,
                Position = new Vector2(position.X, position.Y),
                BRec = bRec,
                MouseOverText = mouseOverText,
                XOffset = xOffset,
                YOffset = yOffset
            };

            EntityLists.BuildIconList.Add(menuIcon);
        }
    }
}