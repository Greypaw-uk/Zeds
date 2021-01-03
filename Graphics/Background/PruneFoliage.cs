using Zeds.Engine;

namespace Zeds.Graphics.Background
{
    class PruneFoliage
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

            for (int i = EntityLists.TreeList.Count - 1; i >= 0; i--)
            {
                if (EntityLists.TreeList[i].BRec.Intersects(building.BRec))
                {
                    EntityLists.TreeList.RemoveAt(i);
                }
            }
        }
    }
}