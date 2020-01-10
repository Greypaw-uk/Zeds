using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;

using static Zeds.Engine.EntityLists;

namespace Zeds.Graphics
{
    public static class DrawMenus
    {
        public class BuildMenuIcon
        {
            public Vector2 Position;
            public Texture2D Texture;
            public string ID;
            public Rectangle IRec;
        }

        class BuildMenu
        {
            public static void BuildMenuIcon()
            {
                var buildMenuIconLocation = new Vector2
                {
                    X = 0,
                    Y = 0
                };

                var buildMenu = new BuildMenuIcon
                {
                    Position = buildMenuIconLocation,
                    Texture = Textures.BuildMenuIconTexture,
                    ID = Guid.NewGuid().ToString()
                };

                MainIconList.Add(buildMenu);
            }
        }

        public static void DrawBuildMenu()
        {
            foreach (var icon in EntityLists.MainIconList)
            {
                Engine.Zeds.SpriteBatch.Draw(icon.Texture, icon.Position, Color.AliceBlue);
            }

            foreach (var building in EntityLists.BuildingList) 
                Engine.Zeds.SpriteBatch.Draw(building.Texture, building.Position, Color.AliceBlue);
        }
    }
}