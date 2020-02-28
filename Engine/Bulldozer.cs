using Zeds.UI;

namespace Zeds.Engine
{
    class Bulldozer
    {
        public static bool IsBulldozerActive;
        public static bool IsDemolitionLegal;

        public static void DemolishStructure()
        {
            IsDemolitionLegal = true;

            foreach (var building in EntityLists.BuildingList)
                if (Cursor.CursorRectangle.Intersects(building.BRec) )
                {
                    if (building.Description == "Operations Base")
                        IsDemolitionLegal = false;
                    
                    if(IsDemolitionLegal && CheckMouseStateChange.IsMouseClicked())
                    {
                        EntityLists.BuildingList.Remove(building);
                        break;
                    }
                }
        }
    }
}