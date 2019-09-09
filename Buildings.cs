using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Zeds.Variables;

namespace Zeds
{
    public class Building
    {
        public Vector2 Position;
        public float Health;
        public Texture2D Texture;
        public string ID;
    }

    public static class Buildings
    {
        public static void HQSetup()
        {
            Building hq = new Building
            {
                Position = MapCentre(),
                Texture = HqTexture,
                ID = Guid.NewGuid().ToString()
            };

            BuildingList.Add(hq);
        }

        public static void SmallTent()
        {
            Vector2 position;

            position.X = ScreenWidth / 2;
            position.Y = ScreenHeight / 2 - 100;

            Building smallTent = new Building
            {
                Position =  position,
                Texture = SmallTentTexture,
                ID = Guid.NewGuid().ToString()
            };

            BuildingList.Add(smallTent);
        }
    }
}
