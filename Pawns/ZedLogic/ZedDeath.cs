using Zeds.Engine;

namespace Zeds.Pawns.ZedLogic
{
    class ZedDeath
    {
        public static void CheckZedsHealth()
        {
            foreach (var zed in EntityLists.ZedList)
                if (zed.CurrentHealth <= 0)
                {
                    //PlaceRuinedBuilding(building);
                    EntityLists.ZedList.Remove(zed);
                    break;
                }
        }
    }
}
