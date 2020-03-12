using System.Linq;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.UI.Details_Pane;
using Zeds.UI.PawnInfoPanel.Items_Boxes;

namespace Zeds.UI
{
    static class PawnCursorInteraction
    {
        public static void CheckForCursorPawnInteraction()
        {
            foreach (var person in EntityLists.HumanList.Where(person => Cursor.CursorRectangle.Intersects(person.BRec)))
            {
                DetailsPaneInteraction.HumanHoveredOver(person);

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && !Bulldozer.IsBulldozerActive)
                {
                    ExtendIconChecks.IsWeaponIconListVisible = false;

                    foreach (var human in EntityLists.HumanList)
                        human.IsSelected = false;

                    person.IsSelected = true;
                    PawnInfoPanel.PawnInfo.IsPawnInfoVisible = true;
                    PawnInfoPanel.PawnInfo.DisplayPawnInfo(person);
                    PawnInfoPanel.SelectedPawn.SetSelectedPawn(person);
                }
            }
        }
    }
}
