using System;
using Zeds.Engine;
using Zeds.Collisions;

namespace Zeds.BuildingLogic
{
    public class Tent : Building
    {
        public static void SmallTent()
        {
            Tent smallTent = new Tent
            {
                Texture = Textures.SmallTentTexture,
                ID = Guid.NewGuid().ToString()
            };
            
            //smallTent.Position.X = ScreenWidth / 2 - smallTent.Texture.Width / 2;
            //smallTent.Position.Y = ScreenHeight / 2 - 100 - smallTent.Texture.Height / 2;

            smallTent.BRec = BoundingBoxes.BoundingBox(smallTent.Position, smallTent.Texture);

            EntityLists.BuildingList.Add(smallTent);
        }
    }
}