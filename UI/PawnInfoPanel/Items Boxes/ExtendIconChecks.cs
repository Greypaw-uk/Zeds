using Zeds.Engine;

namespace Zeds.UI.PawnInfoPanel.Items_Boxes
{
    class ExtendIconChecks
    {
        public static bool IsWeaponIconListVisible;

        public static void CheckExtendHandClicked()
        {
            if (Cursor.CursorRectangle.Intersects(PawnInfo.ExpandHandBox) && CheckMouseStateChange.IsMouseClicked())
            {
                IsWeaponIconListVisible = true;
            }
        }
    }
}
