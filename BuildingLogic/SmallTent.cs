using System;
using Zeds.Engine;
using static Zeds.Collisions.BoundingBoxes;

namespace Zeds.BuildingLogic
{
    public class Tent : Building
    {
        public static void SmallTent()
        {
            Tent smallTent = new Tent
            {
                Texture = DefaultSettings.SmallTentTexture,
                ID = Guid.NewGuid().ToString()
            };
            
            //smallTent.Position.X = ScreenWidth / 2 - smallTent.Texture.Width / 2;
            //smallTent.Position.Y = ScreenHeight / 2 - 100 - smallTent.Texture.Height / 2;

            smallTent.BRec = BoundingBox(smallTent.Position, smallTent.Texture);

            DefaultSettings.BuildingList.Add(smallTent);
        }
    }
}