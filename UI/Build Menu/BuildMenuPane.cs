using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.UI.Details_Pane;

namespace Zeds.UI.Build_Menu
{
    public static class BuildMenuPane
    {
        public static MoveablePane BuildMenuWindow;
        public static Rectangle CloseMenuRec;

        public static bool IsBuildMenuWindowVisible;

        public static bool IsBuildMenuMoving;


        public static void InitialiseBuildMenuLocation()
        {
            CreateBuildMenuWindow();
            UpdateMainMenuLocation();
            UpdateBuildMenuLocation();
        }

        private static void CreateBuildMenuWindow()
        {
            Vector2 paneStartingLocation = new Vector2
            {
                X = Engine.Engine.ScreenWidth - Textures.BuildMenuPane.Width - 10,
                Y = 10
            };

            BuildMenuWindow = new MoveablePane
            {
                Rectangle = new Rectangle((int) paneStartingLocation.X, (int) paneStartingLocation.Y, 200, 100),
                Texture = Textures.BuildMenuPane
            };

            CloseMenuRec = new Rectangle
            {
                X = BuildMenuWindow.Rectangle.X + BuildMenuWindow.Rectangle.Width - 30,
                Y = BuildMenuWindow.Rectangle.Y + 10,
                Width = 20,
                Height = 20
            };

            BuildMenuWindow.Location.X = paneStartingLocation.X;
            BuildMenuWindow.Location.Y = paneStartingLocation.Y;

            foreach (var icon in EntityLists.MainIconList)
            {
                icon.Position.X = (BuildMenuWindow.Location.X + icon.XOffset);
                icon.Position.Y = (BuildMenuWindow.Location.Y + icon.YOffset);

                icon.BRec.X = (int)BuildMenuWindow.Location.X + icon.XOffset;
                icon.BRec.Y = (int)BuildMenuWindow.Location.Y + icon.YOffset;
            }
        }

        public static void UpdateBuildMenuWindowLocation()
        {
            if (Cursor.CursorRectangle.Intersects(BuildMenuWindow.Rectangle) &&
                Mouse.GetState().LeftButton == ButtonState.Pressed && !DetailsPaneMovement.IsDetailsPaneMoving)
            {
                IsBuildMenuMoving = true;
            }
            else
            {
                IsBuildMenuMoving = false;
            }

            if (IsBuildMenuMoving )
            {
                bool isHovering = false;

                foreach (var icon in EntityLists.MainIconList)
                {
                    if (Cursor.CursorRectangle.Intersects(icon.BRec))
                        isHovering = true;
                }

                foreach (var icon in EntityLists.BuildIconList)
                {
                    if (Cursor.CursorRectangle.Intersects(icon.BRec))
                        isHovering = true;
                }

                if (!isHovering)
                {
                    CloseMenuRec.X = BuildMenuWindow.Rectangle.X + BuildMenuWindow.Rectangle.Width - 30;
                    CloseMenuRec.Y = BuildMenuWindow.Rectangle.Y + 10;

                    //ToDo 3 Improve movement of Window
                    BuildMenuWindow.Location.X =
                        (int) Engine.Engine.MouseCoordinates.X - (Textures.BuildMenuPane.Width / 2);
                    BuildMenuWindow.Location.Y =
                        (int) Engine.Engine.MouseCoordinates.Y - (Textures.BuildMenuPane.Height / 2);

                    BuildMenuWindow.Rectangle.X = (int) BuildMenuWindow.Location.X;
                    BuildMenuWindow.Rectangle.Y = (int) BuildMenuWindow.Location.Y;


                    UpdateMainMenuLocation();
                    UpdateBuildMenuLocation();
                    BuildMenuRollOverText.UpdateRollOverTextPosition();
                }
            }
        }

        private static void UpdateMainMenuLocation()
        {
            foreach (var icon in EntityLists.MainIconList)
            {
                icon.Position.X = (BuildMenuWindow.Location.X + icon.XOffset);
                icon.Position.Y = (BuildMenuWindow.Location.Y + icon.YOffset);

                icon.BRec.X = ((int)BuildMenuWindow.Location.X + icon.XOffset);
                icon.BRec.Y = (int)(BuildMenuWindow.Location.Y + icon.YOffset);
            }
        }

        private static void UpdateBuildMenuLocation()
        {
            foreach (var icon in EntityLists.BuildIconList)
            {
                icon.Position.X = BuildMenuWindow.Location.X + icon.XOffset;
                icon.Position.Y = BuildMenuWindow.Location.Y + icon.YOffset;

                icon.BRec.X = (int)BuildMenuWindow.Location.X + icon.XOffset;
                icon.BRec.Y = (int)BuildMenuWindow.Location.Y + icon.YOffset;
            }
        }

        public static void CloseBuildMenu()
        {
            if (Cursor.CursorRectangle.Intersects(CloseMenuRec) &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
                BuildMenuPane.IsBuildMenuWindowVisible = false;
        }
    }
}