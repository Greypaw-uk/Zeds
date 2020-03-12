using System;
using Zeds.Engine;

namespace Zeds.Pawns.HumanLogic
{
    public static class HumanSpawner
    {
        private static readonly int SurvivorQuantity = 5;
        private static readonly Random random = new Random();

        public static void SpawnHumans()
        {
            for (var i = 0; i < SurvivorQuantity; i++)
            {
                var human = new Human
                {
                    IsSpawned = true,
                    IsAlive = true,
                    CurrentHealth = 100,
                    MaxHealth = 100,
                    Angle = 0,
                    Speed = 0.3f,
                    ID = Guid.NewGuid().ToString(),
                    IsMale = HumanAttributes.IsPawnMale(),
                    Age = HumanAttributes.GetHumansAge(),
                    Description = ""
                };

                if (human.IsMale)
                    human.Texture = Textures.HumanMale1Texture;
                else
                    human.Texture = Textures.HumanFemale1Texture;

                human.Position.X = Map.MapCentre().X + random.Next(-300, 300);
                human.Position.Y = Map.MapCentre().Y + random.Next(-300, 300);

                human.CurrentPoint.X = (int)human.Position.X / 15;
                human.CurrentPoint.Y = (int) human.Position.Y / 15;

                human.DestinationPoint = human.CurrentPoint;

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