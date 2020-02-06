using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zeds.Engine;
using Zeds.Graphics;

namespace Zeds.UI
{
    public static class BasicBuildMenu
    {
        public static void CreateBuildMenuIcon(Texture2D texture, Vector2 position, Rectangle bRec, String mouseOverText)
        {
            var menuIcon = new DrawMenus.BuildMenuIcon
            {
                Texture = texture,
                Position = new Vector2(position.X, position.Y),
                BRec = bRec,
                MouseOverText = mouseOverText
            };

            EntityLists.BuildIconList.Add(menuIcon);
        }
    }
}