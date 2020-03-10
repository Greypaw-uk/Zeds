using System.Linq;
using Zeds.Engine;
using Zeds.Pawns.HumanLogic;

namespace Zeds.UI.Details_Pane
{
    public static class DetailsPaneInteraction
    {
        public static void CheckForDetailsPaneInteraction()
        {
            DetailsPane.isDetailPaneVisible = false;
            DetailsPane.descriptionBuilder.Clear();
            DetailsPane.detailsPane.Description = "";

            CheckBuildingInteraction();
            CheckZedInteraction();
            CheckRuinedBuildingInteraction();
        }

        public static void HumanHoveredOver(Human person)
        {

            DetailsPane.descriptionBuilder.Append(person.Name);
            DetailsPane.descriptionBuilder.Append(", \n");
            DetailsPane.descriptionBuilder.Append(person.Age);
            DetailsPane.descriptionBuilder.Append(", ");
            DetailsPane.descriptionBuilder.Append(person.Occupation);

            DetailsPane.detailsPane.Description = DetailsPane.descriptionBuilder.ToString();

            DetailsPane.isDetailPaneVisible = true;

        }

        private static void CheckBuildingInteraction()
        {
            if (!DetailsPane.isDetailPaneVisible)
            {
                foreach (var building in EntityLists.BuildingList.Where(building =>
                    Cursor.CursorRectangle.Intersects(building.BRec)))
                {
                    DetailsPane.descriptionBuilder.Append(building.Description);

                    DetailsPane.detailsPane.Description = DetailsPane.descriptionBuilder.ToString();

                    DetailsPane.isDetailPaneVisible = true;
                    break;
                }
            }
        }

        private static void CheckZedInteraction()
        {
            if (!DetailsPane.isDetailPaneVisible)
            {
                foreach (var zed in EntityLists.ZedList.Where(zed => Cursor.CursorRectangle.Intersects(zed.BRec)))
                {
                    DetailsPane.descriptionBuilder.Append(zed.Description);

                    DetailsPane.detailsPane.Description = DetailsPane.descriptionBuilder.ToString();

                    DetailsPane.isDetailPaneVisible = true;
                    break;
                }
            }
        }

        private static void CheckRuinedBuildingInteraction()
        {
            if (!DetailsPane.isDetailPaneVisible)
            {
                foreach (var ruin in EntityLists.RuinedBuildingList.Where(ruin => Cursor.CursorRectangle.Intersects(ruin.BRec)))
                {
                    DetailsPane.descriptionBuilder.Append(ruin.Description);

                    DetailsPane.detailsPane.Description = DetailsPane.descriptionBuilder.ToString();

                    DetailsPane.isDetailPaneVisible = true;
                    break;
                }
            }
        }
    }
}