using System;
using Zeds.Engine;
using static Zeds.Collisions.BoundingBoxes;

namespace Zeds.BuildingLogic
{
    public class HQ : Building
    {
        public static void HQSetup()
        {
            HQ hq = new HQ
            {
                Position = Map.MapCentre(),
                Texture = DefaultSettings.HqTexture,
                ID = Guid.NewGuid().ToString()
            };

            hq.BRec = BoundingBox(hq.Position, hq.Texture);

            DefaultSettings.BuildingList.Add(hq);
        }
    }
}