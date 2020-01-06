using System;
using Microsoft.Xna.Framework;
using static Zeds.BoundingBoxes;
using static Zeds.DefaultSettings;

namespace Zeds
{
    public static class Tent
    {
        public static void SmallTent()
        {
            Vector2 position;

            position.X = ScreenWidth / 2;
            position.Y = ScreenHeight / 2 - 100;

            Building smallTent = new Building
            {
                Position =  position,
                Texture = DefaultSettings.SmallTentTexture,
                ID = Guid.NewGuid().ToString()
            };
            smallTent.BRec = BoundingBox(smallTent.Position, smallTent.Texture);

            smallTent.Position.X = position.X - smallTent.Texture.Width / 2;
            smallTent.Position.Y = position.Y - smallTent.Texture.Height / 2;

            DefaultSettings.BuildingList.Add(smallTent);
        }
    }
}