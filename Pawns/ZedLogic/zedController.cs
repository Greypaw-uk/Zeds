using System;
using Zeds.Engine;

namespace Zeds.Pawns.ZedLogic
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
                    Texture = Textures.ZedTexture,
                    ID = Guid.NewGuid().ToString(),
                    Description = "A zombie.  Grr, argh"
                };

                zed.BRec.X = (int) zed.Position.X;
                zed.BRec.Y = (int)zed.Position.Y;

                zed.BRec.Width = Textures.ZedTexture.Width;
                zed.BRec.Height = Textures.ZedTexture.Height;

                ZedSpawner.StopZedsBunching();

                EntityLists.ZedList.Add(zed);
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