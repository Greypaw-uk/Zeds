using System;
using static Zeds.Engine.DefaultSettings;
using static Zeds.BoundingBoxes;
using static Zeds.ZedLogic.ZedSpawner;

namespace Zeds.ZedLogic
{
    public static class ZedController
    {
        public static void PopulateZedList()
        {
            for (var i = 0; i < ZedSpawner.ZedQuantity; i++)
            {
                var zed = new Zed
                {
                    Position = ZedSpawner.ZedSpawnPoint(),
                    IsSpawned = true,
                    IsAlive = true,
                    Health = 1,
                    Speed = 0.25f,
                    Texture = ZedTexture,
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
            if (ZedSpawner.ZedQuantity < 100)
            {
                var increaseRoll = random.Next(1, 1000);

                if (increaseRoll > 998) ZedSpawner.ZedQuantity++;
            }
        }
    }
}