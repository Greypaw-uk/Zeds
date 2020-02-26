using Microsoft.Xna.Framework;
using Zeds.Graphics;

namespace Zeds.UI.Details_Pane
{
    public static class DrawDetailPane
    {
        public static void DrawDetailsPane()
        {
            Engine.Engine.SpriteBatch.Draw(DetailsPane.detailsPane.Texture, DetailsPane.detailsPane.Location, Color.AliceBlue);
        }

        public static void DrawDetailsPaneText()
        {
            Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, DetailsPane.detailsPane.Description, DetailsPane.detailsPane.TextCoordinates, Color.White);
        }
    }
}