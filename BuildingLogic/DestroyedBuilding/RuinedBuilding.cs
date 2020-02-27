using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.BuildingLogic.DestroyedBuilding
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
                Position = previousBuilding.Position
            };

            switch (previousBuilding.Name)
            {
                case "Small Tent":
                    ruin.Texture = Textures.RuinedSmallTent;
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
