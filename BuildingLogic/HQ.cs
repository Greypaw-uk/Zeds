using System;
using Zeds.Engine;
using Zeds.Collisions;

namespace Zeds.BuildingLogic
{
    public class HQ : Building
    {
        public static void HQSetup()
        {
            HQ hq = new HQ
            {
                Position = Map.MapCentre(),
                Texture = Textures.HqTexture,
                ID = Guid.NewGuid().ToString()
            };

            hq.BRec = BoundingBoxes.BoundingBox(hq.Position, hq.Texture);

            EntityLists.BuildingList.Add(hq);
        }
    }
}