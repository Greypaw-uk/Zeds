using System;
using Microsoft.Xna.Framework;
using System.Text;
using Zeds.Engine;
using Zeds.Graphics;

namespace Zeds.UI
{
    public static class DetailsPane
    {
        private class DetailsWindowPane: MoveablePane
        {
            public string Description;
        }

        public static bool isDetailPaneVisible;
        private static DetailsWindowPane detailsPane;
        private static readonly StringBuilder descriptionBuilder = new StringBuilder();

        public static void CreateDetailsPane(Vector2 location, string description)
        {
            detailsPane = new DetailsWindowPane

            {
                Location =  location,
                Description = description,
                Texture = Textures.BlankWindowPane
            };

            detailsPane.Rectangle.X = (int)detailsPane.Location.X;
            detailsPane.Rectangle.Y = (int)detailsPane.Location.Y;

            detailsPane.TextCoordinates.X = detailsPane.Location.X + 20;
            detailsPane.TextCoordinates.Y = detailsPane.Location.Y + 20;
        }

        public static void DrawDetailsPane()
        {
            Engine.Engine.SpriteBatch.Draw(detailsPane.Texture, detailsPane.Location, Color.AliceBlue);
            Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, descriptionBuilder, detailsPane.TextCoordinates, Color.White);
        }

        public static void DetailsPaneInteraction()
        {
            CheckHumanInteraction();
            CheckBuildingInteraction();
            CheckZedInteraction();

            CheckForDetailsPaneMovement();

            Console.WriteLine(descriptionBuilder);
        }

        private static void CheckForDetailsPaneMovement()
        {
            if (Cursor.CursorRectangle.Intersects(detailsPane.Rectangle) && CheckMouseStateChange.IsMouseClicked())
            {
                detailsPane.Location.X =
                    (int)Engine.Engine.MouseCoordinates.X - (detailsPane.Texture.Width / 2);
                detailsPane.Location.Y =
                    (int)Engine.Engine.MouseCoordinates.Y - (detailsPane.Texture.Height / 2);

                detailsPane.Rectangle.X = (int)detailsPane.Location.X;
                detailsPane.Rectangle.Y = (int)detailsPane.Location.Y;

                detailsPane.TextCoordinates.X = detailsPane.Location.X + 20;
                detailsPane.TextCoordinates.Y = detailsPane.Location.Y + 20;
            }
        }

        private static void CheckHumanInteraction()
        {
            descriptionBuilder.Clear();

            foreach (var person in EntityLists.HumanList)
                if (Cursor.CursorRectangle.Intersects(person.BRec))
                {
                    descriptionBuilder.Append(person.Name);
                    descriptionBuilder.Append(", ");
                    descriptionBuilder.Append(person.Age);
                    descriptionBuilder.Append(" year-old ");
                    descriptionBuilder.Append(person.Occupation);

                    isDetailPaneVisible = true;
                    break;
                }
        }

        private static void CheckBuildingInteraction()
        {
            descriptionBuilder.Clear();

            foreach (var building in EntityLists.BuildingList)
            {
                if (Cursor.CursorRectangle.Intersects(building.BRec))
                {
                    descriptionBuilder.Append(building.Description);

                    isDetailPaneVisible = true;
                    break;
                }
            }
        }

        private static void CheckZedInteraction()
        {
            descriptionBuilder.Clear();

            foreach (var zed in EntityLists.ZedList)
            {
                if (Cursor.CursorRectangle.Intersects(zed.BRec))
                    descriptionBuilder.Append("A zombie - grr, argh");

                isDetailPaneVisible = true;
                break;
            }
        }
    }
}