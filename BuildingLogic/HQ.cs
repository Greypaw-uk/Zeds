using System;
using Zeds.Engine;
using Zeds.Graphics.Background;

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
                ID = Guid.NewGuid().ToString(),
                CurrentHealth = 200,
                MaxHealth = 200,
                Name = "Headquarters"
            };

            hq.BRec.X = (int) hq.Position.X;
            hq.BRec.Y = (int) hq.Position.Y;

            hq.BRec.Width = hq.Texture.Width;
            hq.BRec.Height = hq.Texture.Height;

            hq.Description = "Operations Base";

            EntityLists.BuildingList.Add(hq);
            PruneFoliage.CheckBushBuildingIntersection(hq);
        }
    }
}