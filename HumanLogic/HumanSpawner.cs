using System;
using Zeds.Engine;

namespace Zeds.HumanLogic
{
    public static class HumanSpawner
    {
        private static int SurvivorQuantity = 1;

        public static void SpawnHumans()
        {
            for (var i = 0; i < SurvivorQuantity; i++)
            {
                var human = new Human
                {
                    Texture = Textures.HumanTexture,
                    IsSpawned = true,
                    IsAlive = true,
                    Health = 1,
                    Position = Map.MapCentre(),
                    Angle = 0,
                    Speed = 0.3f,
                    ID = Guid.NewGuid().ToString(),
                    Name = "Bob",
                    Age = 25,
                    Occupation = "Nurse"
                };

                human.BRec.X = (int)human.Position.X;
                human.BRec.Y = (int)human.Position.Y;

                human.BRec.Width = human.Texture.Width;
                human.BRec.Height = human.Texture.Height;

                EntityLists.HumanList.Add(human); 
            }
        }
    }
}