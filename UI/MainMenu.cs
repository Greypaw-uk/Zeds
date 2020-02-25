using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;
using Zeds.UI.Build_Menu;

namespace Zeds.UI
{
    public static class MainMenu
    {
        public static void CreateMainMenuIcon(string name, Texture2D texture, Vector2 position, int xOffset, int yOffset, Rectangle bRec, string mouseOverText)
        {
            var menuIcon = new DrawBuildMenus.MainMenuIcon
            {
                Name = name,
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
