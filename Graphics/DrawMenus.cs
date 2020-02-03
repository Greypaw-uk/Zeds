using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;

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
                Engine.Engine.SpriteBatch.Draw(icon.Texture, icon.Position, Color.AliceBlue);
            }
        }

        public static void DrawBuildMenuIcons()
        {
            foreach (var icon in EntityLists.BuildIconList)
            {
                Engine.Engine.SpriteBatch.Draw(icon.Texture, icon.Position, Color.AliceBlue);
            }
        }
    }
}