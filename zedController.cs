using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Zeds.Variables;
using static Zeds.Collisions;

namespace Zeds
{
    public class Zed
    {
        public int health;
        public Vector2 position;
        public bool isAlive;
        public bool hasSpawned;
        public float speed;
        public float angle;
        public BoundingBox BoundingBox;
        public string ID;
    }

    public static class ZedController
    {
        private static Vector2 zone1;
        private static Vector2 zone2;
        private static Vector2 zone3;
        private static Vector2 zone4;

        public static List<Zed> ZedList = new List<Zed>();

        public static void PopulateZedList()
        {
            for (var i = 0; i < zedQuantity; i++)
            {
                Zed zed = new Zed
                {
                    position = ZedSpawnPoint(),
                    hasSpawned = true,
                    isAlive = true,
                    health = 1,
                    speed = 0.5f,
                    ID = Guid.NewGuid().ToString()
            };

                ZedList.Add(zed);
            }
        }

        public static void CalculateZedMovement()
        {
            if (ZedList.Count != 0)
            {
                foreach(var zed in ZedList)
                {
                    // Move zed towards map centre
                    Vector2 dir = mapCentre() - zed.position;
                    dir.Normalize();

                    // Rotate to face movement direction
                    float rotation = (float)Math.Atan2(dir.Y, dir.X);

                    UpdateZedPosition(zed, rotation, dir);
                }
            }
        }

        public static void UpdateZedPosition(Zed zed, float rotation, Vector2 dir)
        {
            zed.angle = rotation;
            zed.position += dir * zed.speed;
        }

        public static void StopZedsBunching()
        {
            foreach(var zed in ZedList)
            {
                foreach (var otherZed in ZedList)
                {
                    if(zed.BoundingBox.Intersects(otherZed.BoundingBox) && zed.ID != otherZed.ID)
                    {
                        otherZed.position.X++;
                    }
                }
            }
        }

        public static void IncreaseZeds()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            if (zedQuantity < 100)
            {
                var increaseRoll = random.Next(1, 1000);

                if (increaseRoll > 998)
                {
                    zedQuantity++;
                }
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
