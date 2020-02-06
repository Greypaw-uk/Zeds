using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;
using Zeds.UI;

namespace Zeds.Graphics
{
    public static class DrawMenus
    {
        public class MainMenuIcon
        {
            public Vector2 Position;
            public Rectangle BRec;
            public Texture2D Texture;
            public string MouseOverText;
            public int XOffset;
            public int YOffset;
        }

        public class BuildMenuIcon
        {
            public Vector2 Position;
            public Rectangle BRec;
            public Texture2D Texture;
            public string MouseOverText;
        }

        public static void DrawMainMenuIcons()
        {
            foreach (var icon in EntityLists.MainIconList)
            {
                Engine.Engine.SpriteBatch.Draw(icon.Texture, icon.Position, Color.White);
            }
        }

        public static void DrawBuildMenuIcons()
        {
            foreach (var icon in EntityLists.BuildIconList)
            {
                Engine.Engine.SpriteBatch.Draw(icon.Texture, icon.Position, Color.White);
            }
        }

        public static void DrawBuildMenuPane()
        {
            Engine.Engine.SpriteBatch.Draw(Textures.BuildMenuPane, BuildMenuPane.BuildMenuWindow.Location, Color.White);
        }
    }
}