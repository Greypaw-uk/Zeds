using System;
using Zeds.Engine;

namespace Zeds
{
    public static class HumanSpawner
    {
        public static int SurvivorQuantity = 1;

        public static void SpawnHumans()
        {
            for (var i = 0; i < SurvivorQuantity; i++)
            {
                var human = new Human
                {
                    IsSpawned = true,
                    IsAlive = true,
                    Health = 1,
                    Position = Map.MapCentre(),
                    Angle = 0,
                    Speed = 0.3f,
                    ID = Guid.NewGuid().ToString()
                };

                DefaultSettings.HumanList.Add(human);
            }
        }
    }
}