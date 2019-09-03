using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Zeds.Variables;

namespace Zeds
{
    public struct Zed
    {
        public int health;
        public Vector2 position;
        public bool isAlive;
        public bool hasSpawned;
        public float speed;
        public float angle;
    }

    public static class ZedController
    {
        private static Vector2 zone1;
        private static Vector2 zone2;
        private static Vector2 zone3;
        private static Vector2 zone4;

        public static Zed[] zed = new Zed[100];
        public static List<Zed> ZedList = new List<Zed>();

        public static void PopulateZedList()
        {
            for(var i = 0; i < zedQuantity; i++)
            {
                zed[i].position = ZedSpawnPoint();
                zed[i].hasSpawned = true;
                zed[i].isAlive = true;
                zed[i].health = 1;
                zed[i].speed = 0.25f;

                ZedList.Add(zed[i]);
            }

            SpawnZeds();
        }

        public static void SpawnZeds()
        {
            if (ZedList.Count != 0)
            { 
                for (var i = 0; i < ZedList.Count; i++)
                {
                    if (zed[i].hasSpawned) continue;
                    zed[i].position = ZedSpawnPoint();
                    zed[i].hasSpawned = true;
                    zed[i].isAlive = true;
                    zed[i].health = 1;
                    zed[i].speed = 0.25f;
                }
            }
        }

        public static void ZedMovement()
        {
            if (ZedList.Count != 0)
            {
                for (var i = 0; i < ZedList.Count; i++)
                {
                    // Orientate Zed with map's centre
                    Vector2 dir = mapCentre() - zed[i].position;
                    dir.Normalize();

                    // Rotate to face movement direction
                    float rotation = (float)Math.Atan2(dir.Y, dir.X);
                    zed[i].angle = rotation;

                    // Move zed towards map centre
                    zed[i].position += dir * zed[i].speed;
                }
            }
        }

        public static void IncreaseZeds()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var increaseRoll = random.Next(1, 1000);

            if (increaseRoll > 998)
            {
                zedQuantity++;
            }
        }

        public static Vector2 ZedSpawnPoint()
        {
            zone1.X = 0 - zedTexture.Width;
            zone1.Y = 0 - zedTexture.Height;

            zone2.X = 800 + zedTexture.Width;
            zone2.Y = 0 + zedTexture.Height;

            zone3.X = 0 - zedTexture.Width;
            zone3.Y = 600 - zedTexture.Height;

            zone4.X = 800 + zedTexture.Width;
            zone4.Y = 600 - zedTexture.Height;

            Random random = new Random(Guid.NewGuid().GetHashCode());
            var randomZone = random.Next(0, 3);

            Vector2 zedSpawnPoint = new Vector2();

            switch (randomZone)
            {
                case 0:
                    zedSpawnPoint.X = zone1.X;
                    zedSpawnPoint.Y = zone1.Y;
                    break;

                case 1:
                    zedSpawnPoint.X = zone2.X;
                    zedSpawnPoint.Y = zone2.Y;
                    break;

                case 2:
                    zedSpawnPoint.X = zone3.X;
                    zedSpawnPoint.Y = zone3.Y;
                    break;

                case 3:
                    zedSpawnPoint.X = zone4.X;
                    zedSpawnPoint.Y = zone4.Y;
                    break;
            }
            return zedSpawnPoint;
        }
    }
}
