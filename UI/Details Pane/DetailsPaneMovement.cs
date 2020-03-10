using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.UI.Build_Menu;

namespace Zeds.UI.Details_Pane
{
    public static class DetailsPaneMovement
    {
        public static void UpdateDetailsPaneLocation()
        {
            if (!Cursor.CursorRectangle.Intersects(BuildMenuPane.BuildMenuWindow.Rectangle))
            {
                if (Cursor.CursorRectangle.Intersects(DetailsPane.detailsPane.Rectangle) &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    DetailsPane.detailsPane.Location.X =
                        (int) Engine.Engine.MouseCoordinates.X - (Textures.DetailsWindowPane.Width / 2);
                    DetailsPane.detailsPane.Location.Y =
                        (int) Engine.Engine.MouseCoordinates.Y - (Textures.DetailsWindowPane.Height / 2);

                    DetailsPane.detailsPane.Rectangle.X = (int) DetailsPane.detailsPane.Location.X;
                    DetailsPane.detailsPane.Rectangle.Y = (int) DetailsPane.detailsPane.Location.Y;

                    DetailsPane.detailsPane.TextCoordinates.X = DetailsPane.detailsPane.Location.X + 20;
                    DetailsPane.detailsPane.TextCoordinates.Y = DetailsPane.detailsPane.Location.Y + 20;
                }
            }
        }
    }
}