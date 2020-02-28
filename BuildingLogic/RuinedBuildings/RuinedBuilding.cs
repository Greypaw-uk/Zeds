using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.BuildingLogic.RuinedBuildings
{
    class RuinedBuilding : Building
    {

        public static void CheckBuildingsHealth()
        {
            foreach (var building in EntityLists.BuildingList)
                if (building.CurrentHealth <= 0)
                {
                    PlaceRuinedBuilding(building);
                    EntityLists.BuildingList.Remove(building);
                    break;
                }
        }

        private static void PlaceRuinedBuilding(Building previousBuilding)
        {
            RuinedBuilding ruin = new RuinedBuilding
            {
                Position = previousBuilding.Position,
                BRec = previousBuilding.BRec
            };

            switch (previousBuilding.Name)
            {
                case "Small Tent":
                    ruin.Texture = Textures.RuinedSmallTent;
                    ruin.Description = "A small ruined tent";
                    break;

                case "Large Tent":
                    ruin.Texture = Textures.RuinedLargeTent;
                    ruin.Description = "A large ruined tent";
                    break;
                
                case "Headquarters":
                    ruin.Texture = Textures.RuinedHQ;
                    ruin.Description = "Ruined HQ";
                    break;

                case "Wooden Cabin":
                    ruin.Texture = Textures.RuinedCabin;
                    ruin.Description = "Ruined cabin";
                    break;
            }

            EntityLists.RuinedBuildingList.Add(ruin);
        }

        public static void DrawRuinedBuildings()
        {
            foreach(var ruin in EntityLists.RuinedBuildingList)
                Engine.Engine.SpriteBatch.Draw(ruin.Texture, ruin.Position, Color.White);
        }
    }
}
