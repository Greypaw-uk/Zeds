using Microsoft.Xna.Framework.Input;

namespace Zeds.UI.PawnInfoPanel.Items_Boxes
{
    public class PawnInfoMenuClose
    {
        public static void ClosePawnInfoMenu()
        {
            if (Cursor.CursorRectangle.Intersects(PawnInfo.MenuCloseRec) &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
                PawnInfo.IsPawnInfoVisible = false;
        }
    }
}
