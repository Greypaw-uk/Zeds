using System;
using static Zeds.BoundingBoxes;

namespace Zeds
{
    public static class HQ
    {
        public static void HQSetup()
        {
            Building hq = new Building
            {
                Position = Map.MapCentre(),
                Texture = DefaultSettings.HqTexture,
                ID = Guid.NewGuid().ToString()
            };

            hq.Position.X = hq.Position.X - hq.Texture.Width / 2;
            hq.Position.Y = hq.Position.Y - hq.Texture.Height / 2;

            hq.BRec = BoundingBox(hq.Position, hq.Texture);

            DefaultSettings.BuildingList.Add(hq);
        }
    }
}