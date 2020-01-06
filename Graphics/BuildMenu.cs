using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using static Zeds.DefaultSettings;

namespace Zeds
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
                Texture = BuildMenuIconTexture,
                ID = Guid.NewGuid().ToString()
            };

            MainIconList.Add(buildMenu);
        }
    }
}
