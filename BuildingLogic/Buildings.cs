using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using static Zeds.Engine;
using static Zeds.Collisions;

namespace Zeds
{
    public class Building
    {
        public Vector2 Position;
        public float Health;
        public Texture2D Texture;
        public string ID;
        public Rectangle BRec;
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

            hq.Position.X = hq.Position.X - hq.Texture.Width / 2;
            hq.Position.Y = hq.Position.Y - hq.Texture.Height / 2;

            hq.BRec = CreateBoundingBox(hq.Position, hq.Texture);

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
            smallTent.BRec = CreateBoundingBox(smallTent.Position, smallTent.Texture);

            smallTent.Position.X = position.X - smallTent.Texture.Width / 2;
            smallTent.Position.Y = position.Y - smallTent.Texture.Height / 2;

            BuildingList.Add(smallTent);
        }
    }
}
