using System;
using Zeds.Engine;
using static Zeds.Collisions.BoundingBoxes;
using static Zeds.ZedLogic.ZedSpawner;
using static Zeds.Engine.EntityLists;

namespace Zeds.ZedLogic
{
    public static class ZedController
    {
        public static void PopulateZedList()
        {
            for (var i = 0; i < ZedQuantity; i++)
            {
                var zed = new Zed
                {
                    Position = ZedSpawnPoint(),
                    IsSpawned = true,
                    IsAlive = true,
                    Health = 1,
                    Speed = 0.25f,
                    Texture = Textures.ZedTexture,
                    ID = Guid.NewGuid().ToString()
                };

                zed.BRec = BoundingBox(zed.Position, zed.Texture);

                StopZedsBunching();

                ZedList.Add(zed);
            }
        }

        public static void IncreaseZeds()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            if (ZedQuantity < 100)
            {
                var increaseRoll = random.Next(1, 1000);

                if (increaseRoll > 998) ZedQuantity++;
            }
        }
    }
}