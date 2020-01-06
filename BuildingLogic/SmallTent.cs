using System;
using Zeds.Engine;
using static Zeds.BoundingBoxes;
using static Zeds.Engine.DefaultSettings;

namespace Zeds
{
    public class Tent : Building
    {
        public static void SmallTent()
        {
            Building smallTent = new Building
            {
                Texture = DefaultSettings.SmallTentTexture,
                ID = Guid.NewGuid().ToString()
            };
            smallTent.BRec = BoundingBox(smallTent.Position, smallTent.Texture);

            smallTent.Position.X = ScreenWidth / 2 - smallTent.Texture.Width / 2;
            smallTent.Position.Y = ScreenHeight / 2 - 100 - smallTent.Texture.Height / 2;

            DefaultSettings.BuildingList.Add(smallTent);
        }
    }
}