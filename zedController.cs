using System;
using Microsoft.Xna.Framework;
using static Zeds.Engine;
using static Zeds.Collisions;

namespace Zeds
{
    public class Zed
    {
        public float AlertRange;
        public float Angle;
        public BoundingBox boundingBox;
        public bool HasSpawned;
        public int Health;
        public string ID;
        public bool IsAlive;
        public Vector2 Position;
        public float Speed;
    }

    public static class ZedController
    {
        public static int ZedQuantity = 3;

        private static Vector2 zone1;
        private static Vector2 zone2;
        private static Vector2 zone3;
        private static Vector2 zone4;
        private static Vector2 zone5;
        private static Vector2 zone6;
        private static Vector2 zone7;
        private static Vector2 zone8;

        public static void PopulateZedList()
        {
            for (var i = 0; i < ZedQuantity; i++)
            {
                var zed = new Zed
                {
                    Position = ZedSpawnPoint(),
                    HasSpawned = true,
                    IsAlive = true,
                    Health = 1,
                    Speed = 0.25f,
                    ID = Guid.NewGuid().ToString(),
                    boundingBox = new BoundingBox()
                };

                StopZedsBunching();

                ZedList.Add(zed);
            }
        }

        public static void CalculateZedMovement()
        {
            if (ZedList.Count != 0)
                foreach (var zed in ZedList)
                {
                    // Move zed towards closest target
                    var dir = FindClosestTarget(zed) - zed.Position;
                    dir.Normalize();

                    // Rotate to face movement direction
                    var rotation = (float) Math.Atan2(dir.Y, dir.X);

                    UpdateZedPosition(zed, rotation, dir);
                }
        }

        public static Vector2 FindClosestTarget(Zed zed)
        {
            var buildingLocation = new Vector2();
            var humanLocation = new Vector2();
            var target = new Vector2();

            float closestBuilding = 1000;
            float closestHuman = 1000;

            if (HumanList.Count != 0)
                foreach (var human in HumanList)
                {
                    var distance = Vector2.Distance(zed.Position, human.Position);

                    if (distance <= closestHuman)
                    {
                        closestHuman = distance;
                        humanLocation = human.Position;
                    }
                }
            else if (BuildingList.Count != 0)
                foreach (var building in BuildingList)
                {
                    var distance = Vector2.Distance(zed.Position, building.Position);
                    {
                        if (distance <= closestBuilding)
                        {
                            closestBuilding = distance;
                            buildingLocation = building.Position;
                        }
                    }
                }

            if (closestHuman < closestBuilding)
                target = humanLocation;
            else
                target = buildingLocation;

            return target;
        }

        public static void UpdateZedPosition(Zed zed, float rotation, Vector2 dir)
        {
            zed.Angle = rotation;
            zed.Position += dir * zed.Speed;
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

        public static Vector2 ZedSpawnPoint()
        {
            zone1.X = 0 - ZedTexture.Width;
            zone1.Y = 0 - ZedTexture.Height;

            zone2.X = ScreenWidth + ZedTexture.Width;
            zone2.Y = 0 + ZedTexture.Height;

            zone3.X = 0 - ZedTexture.Width;
            zone3.Y = ScreenHeight - ZedTexture.Height;

            zone4.X = ScreenWidth + ZedTexture.Width;
            zone4.Y = ScreenHeight + ZedTexture.Height;

            zone5.X = ScreenWidth / 2 - ZedTexture.Width;
            zone5.Y = 0 - ZedTexture.Height;

            zone6.X = ScreenWidth - ZedTexture.Width;
            zone6.Y = ScreenHeight / 2 - ZedTexture.Height;

            zone7.X = ScreenWidth / 2 - ZedTexture.Width;
            zone7.Y = ScreenHeight + ZedTexture.Height;

            zone8.X = 0 - ZedTexture.Width;
            zone8.Y = ScreenHeight / 2 + ZedTexture.Height;

            var random = new Random(Guid.NewGuid().GetHashCode());
            var randomZone = random.Next(0, 7);

            var zedSpawnPoint = new Vector2();

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

                case 4:
                    zedSpawnPoint.X = zone5.X;
                    zedSpawnPoint.Y = zone5.Y;
                    break;

                case 5:
                    zedSpawnPoint.X = zone6.X;
                    zedSpawnPoint.Y = zone6.Y;
                    break;

                case 6:
                    zedSpawnPoint.X = zone7.X;
                    zedSpawnPoint.Y = zone7.Y;
                    break;

                case 7:
                    zedSpawnPoint.X = zone8.X;
                    zedSpawnPoint.Y = zone8.Y;
                    break;
            }

            return zedSpawnPoint;
        }
    }
}