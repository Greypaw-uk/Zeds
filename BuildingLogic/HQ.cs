using System;
using Zeds.Engine;
using static Zeds.BoundingBoxes;

namespace Zeds
{
    public class HQ : Building
    {
        public static void HQSetup()
        {
            Building hq = new Building
            {
                Position = Map.MapCentre(),
                Texture = DefaultSettings.HqTexture,
                ID = Guid.NewGuid().ToString()
            };

            hq.Position.X -= hq.Texture.Width / 2;
            hq.Position.Y -= hq.Texture.Height / 2;

            hq.BRec = BoundingBox(hq.Position, hq.Texture);

            DefaultSettings.BuildingList.Add(hq);
        }
    }
}