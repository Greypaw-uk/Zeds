using Zeds.UI;

namespace Zeds.Engine
{
    class Bulldozer
    {
        public static bool IsBulldozerActive;

        public static void DemolishStructure()
        {
            // ToDo 2 Exclude HQ from demolition
            foreach (var building in EntityLists.BuildingList)
                if (Cursor.CursorRectangle.Intersects(building.BRec) && CheckMouseStateChange.IsMouseClicked())
                {
                    EntityLists.BuildingList.Remove(building);
                    break;
                }
        }
    }
}