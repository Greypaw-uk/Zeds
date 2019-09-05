using Microsoft.Xna.Framework;
using static Zeds.Variables;
namespace Zeds
{
    public struct Human
    {
        public int health;
        public Vector2 position;
        public bool isAlive;
        public bool hasSpawned;
        public float angle;
    }

    public static class HumanController
    {
        public static Human[] human;

        public static void SpawnHumans()
        {
            human = new Human[survivorQuantity];
            for (int i = 0; i < survivorQuantity; i++)
            {
                human[i].hasSpawned = true;
                human[i].isAlive = true;
                human[i].health = 1;
                human[i].position.X = (float)screenWidth / 2;
                human[i].position.Y = (float)screenHeight / 2;
                human[i].angle = 0;
            }
        }
    }
}
