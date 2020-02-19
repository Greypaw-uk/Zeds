using Zeds.UI;

namespace Zeds.Engine
{
    class Bulldozer
    {
        public static bool IsBulldozerActive;

        public static void DemolishStructure()
        {
            // ToDo 2 Increase precision of the intersection event
            foreach (var building in EntityLists.BuildingList)
                if (Cursor.CursorRectangle.Intersects(building.BRec) && CheckMouseStateChange.IsMouseClicked())
                {
                    EntityLists.BuildingList.Remove(building);
                    break;
                }
        }
    }
}