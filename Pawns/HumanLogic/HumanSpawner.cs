using System;
using Zeds.Engine;

namespace Zeds.Pawns.HumanLogic
{
    public static class HumanSpawner
    {
        private static int SurvivorQuantity = 5;
        private static Random random = new Random();

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
                    Angle = 0,
                    Speed = 0.3f,
                    ID = Guid.NewGuid().ToString(),
                    IsMale = HumanAttributes.IsPawnMale(),
                    Age = HumanAttributes.GetHumansAge(),
                    Description = ""
                };

                human.Position.X = Map.MapCentre().X + random.Next(-300, 300);
                human.Position.Y = Map.MapCentre().Y + random.Next(-300, 300);

                human.Name = HumanNames.GetHumanFullName(human.IsMale);
                human.Occupation = HumanOccupations.GetOccupation(human.Age);

                human.BRec.X = (int)human.Position.X - (human.Texture.Width / 2);
                human.BRec.Y = (int)human.Position.Y - human.Texture.Height / 2;

                human.BRec.Width = human.Texture.Width;
                human.BRec.Height = human.Texture.Height;

                EntityLists.HumanList.Add(human);
            }
        }
    }
}