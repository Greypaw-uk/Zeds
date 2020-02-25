using Microsoft.Xna.Framework;
using System.Text;
using Zeds.Engine;

namespace Zeds.UI.Details_Pane
{
    public static class DetailsPane
    {
        public class DetailsWindowPane: MoveablePane
        {
            public string Description;
        }

        public static bool isDetailPaneVisible;
        public static DetailsWindowPane detailsPane;
        public static StringBuilder descriptionBuilder = new StringBuilder();

        public static void CreateDetailsPane(Vector2 location, string description)
        {
            detailsPane = new DetailsWindowPane

            {
                Location =  location,
                Texture = Textures.BlankWindowPane,
                Description = ""
            };
            
            detailsPane.Rectangle.X = (int)detailsPane.Location.X;
            detailsPane.Rectangle.Y = (int)detailsPane.Location.Y;

            detailsPane.TextCoordinates.X = detailsPane.Location.X + 20;
            detailsPane.TextCoordinates.Y = detailsPane.Location.Y + 20;
        }
    }
}