using System;
using static Zeds.DefaultSettings;

namespace Zeds
{
    public static class HumanController
    {
        public static int SurvivorQuantity = 1;
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
                    Position = Map.MapCentre(),
                    Angle = 0,
                    Speed = 0.3f,
                    ID = Guid.NewGuid().ToString()
                };

                HumanList.Add(human);
            }
        }
    }
}