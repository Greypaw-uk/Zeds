using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;
using Zeds.Graphics;

namespace Zeds.UI
{
    public static class MainMenu
    {
        public static void CreateMainMenuIcon(Texture2D texture, Vector2 position, int xOffset, int yOffset, Rectangle bRec, String mouseOverText)
        {
            var menuIcon = new DrawMenus.MainMenuIcon
            {
                Texture = texture,
                Position = new Vector2(position.X, position.Y),
                BRec = bRec,
                MouseOverText = mouseOverText,
                XOffset = xOffset,
                YOffset = yOffset
            };

            EntityLists.MainIconList.Add(menuIcon);
        }
    }
}
