using System;
using Zeds.Engine;

namespace Zeds.Pawns.HumanLogic
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
                    Occupation = "Nurse",
                    Description = ""
                };

                human.BRec.X = (int)human.Position.X - (human.Texture.Width / 2);
                human.BRec.Y = (int)human.Position.Y - human.Texture.Height / 2;

                human.BRec.Width = human.Texture.Width;
                human.BRec.Height = human.Texture.Height;

                EntityLists.HumanList.Add(human); 
            }
        }
    }
}