using System;
using Microsoft.Xna.Framework;
using static Zeds.Engine;

namespace Zeds
{
    public class Human
    {
        public float Angle;
        public BoundingBox BoundingBox;
        public bool HasSpawned;
        public int Health;
        public string ID;
        public bool IsAlive;
        public Vector2 Position;
        public float Speed;
    }

    public static class HumanController
    {
        public static int SurvivorQuantity = 1;
        private static readonly float PanicDistance = 100f;
        public static Human[] human;

        public static void SpawnHumans()
        {
            for (var i = 0; i < SurvivorQuantity; i++)
            {
                var human = new Human
                {
                    HasSpawned = true,
                    IsAlive = true,
                    Health = 1,
                    Position = MapCentre(),
                    Angle = 0,
                    Speed = 0.3f,
                    ID = Guid.NewGuid().ToString()
                };

                HumanList.Add(human);
            }
        }

        public static void RunFromZeds()
        {
            foreach (var human in HumanList)
            foreach (var zed in ZedList)
            {
                var distance = (human.Position.Y - zed.Position.Y) * (human.Position.Y - zed.Position.Y) +
                               (human.Position.X - zed.Position.X) * (human.Position.X - zed.Position.X);

                distance = (float) Math.Sqrt(distance);

                if (distance != 0)
                    if (distance <= PanicDistance)
                    {
                        var dir = human.Position - zed.Position;
                        dir.Normalize();

                        // Rotate to face movement direction
                        var rotation = (float) Math.Atan2(dir.Y, dir.X);

                        UpdateHumanPosition(human, rotation, dir);
                    }
            }
        }

        public static void UpdateHumanPosition(Human human, float rotation, Vector2 dir)
        {
            human.Angle = rotation;
            human.Position += dir * human.Speed;
        }
    }
}