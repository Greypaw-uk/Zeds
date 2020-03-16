using Zeds.Engine;

namespace Zeds.Pawns.HumanLogic
{
    class HumanDeath
    {
        public static void CheckHumansHealth()
        {
            foreach (var human in EntityLists.HumanList)
                if (human.CurrentHealth <= 0)
                {
                    //PlaceRuinedBuilding(building);
                    human.IsSelected = false;
                    EntityLists.HumanList.Remove(human);
                    break;
                }
        }
    }
}
