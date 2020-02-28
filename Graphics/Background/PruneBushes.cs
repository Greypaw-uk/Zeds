using Zeds.Engine;

namespace Zeds.Graphics.Background
{
    class PruneBushes
    {
        public static void CheckBushBuildingIntersection(BuildingLogic.Building building)
        {
            for (int i = EntityLists.BushList.Count - 1; i >= 0; i-- )
            {
                if (EntityLists.BushList[i].BRec.Intersects(building.BRec))
                {
                    EntityLists.BushList.RemoveAt(i);
                }
            }
        }
    }
}