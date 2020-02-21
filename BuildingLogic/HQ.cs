using System;
using Zeds.Engine;

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

            hq.BRec.X = (int) hq.Position.X;
            hq.BRec.Y = (int) hq.Position.Y;

            hq.BRec.Width = hq.Texture.Width;
            hq.BRec.Height = hq.Texture.Height;

            EntityLists.BuildingList.Add(hq);
        }
    }
}