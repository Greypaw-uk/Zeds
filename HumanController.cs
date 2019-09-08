using System;
using Microsoft.Xna.Framework;
using static Zeds.Variables;

namespace Zeds
{
    public class Human
    {
        public int health;
        public Vector2 position;
        public bool isAlive;
        public bool hasSpawned;
        public float speed;
        public float angle;
        public BoundingBox BoundingBox;
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
                    hasSpawned = true,
                    isAlive = true,
                    health = 1,
                    position = MapCentre(),
                    angle = 0,
                    speed = 0.3f
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
                    float distance = (human.position.Y - zed.position.Y) * (human.position.Y - zed.position.Y) +
                                   (human.position.X - zed.position.X) * (human.position.X - zed.position.X);

                    distance = (float)Math.Sqrt(distance);

                    if (distance !=0)
                    {
                        Console.WriteLine("Zed distance = " + (int)distance + ".  Panic distance = " + (int)PanicDistance);
                        if (distance <= PanicDistance)
                        {
                            Vector2 dir = human.position - zed.position;
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
            human.angle = rotation;
            human.position += dir * human.speed;
        }
    }
}
