using System;
using Microsoft.Xna.Framework;
using static Zeds.Variables;

namespace Zeds
{
    public class Human
    {
        public int Health;
        public Vector2 Position;
        public bool IsAlive;
        public bool HasSpawned;
        public float Speed;
        public float Angle;
        public BoundingBox BoundingBox;
        public string ID;
    }

    public static class HumanController
    {
        public static Human[] human;
        
        public static void SpawnHumans()
        {
            for (int i = 0; i < SurvivorQuantity; i++)
            {
                Human human = new Human
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
            {
                foreach (var zed in ZedList)
                {
                    float distance = (human.Position.Y - zed.Position.Y) * (human.Position.Y - zed.Position.Y) +
                                   (human.Position.X - zed.Position.X) * (human.Position.X - zed.Position.X);

                    distance = (float)Math.Sqrt(distance);

                    if (distance !=0)
                    {
                        if (distance <= PanicDistance)
                        {
                            Vector2 dir = human.Position - zed.Position;
                            dir.Normalize();

                            // Rotate to face movement direction
                            float rotation = (float)Math.Atan2(dir.Y, dir.X);

                            UpdateHumanPosition(human, rotation, dir);
                        }
                    }
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
