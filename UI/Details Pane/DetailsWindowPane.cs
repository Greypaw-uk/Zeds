using Microsoft.Xna.Framework;
using System.Text;
using Zeds.Engine;

namespace Zeds.UI.Details_Pane
{
    public static class DetailsPane
    {
        public static bool isDetailPaneVisible;
        public static MoveablePane detailsPane;
        public static StringBuilder descriptionBuilder = new StringBuilder();

        public static void CreateDetailsPane(Vector2 location, string description)
        {
            detailsPane = new MoveablePane()

            {
                Location = location,
                Texture = Textures.BlankWindowPane,
                Description = "",
                Rectangle = new Rectangle(0,0,300,150)
            };

            detailsPane.TextCoordinates.X = detailsPane.Location.X + 20;
            detailsPane.TextCoordinates.Y = detailsPane.Location.Y + 20;
        }
    }
}