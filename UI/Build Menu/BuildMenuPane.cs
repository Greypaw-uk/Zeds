using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;

namespace Zeds.UI.Build_Menu
{
    public static class BuildMenuPane
    {
        public static MoveablePane BuildMenuWindow;
        public static Rectangle CloseMenuRec;

        public static bool IsBuildMenuWindowVisible;


        public static void InitialiseBuildMenuLocation()
        {
            CreateBuildMenuWindow();
            UpdateMainMenuLocation();
            UpdateBuildMenuLocation();
        }

        private static void CreateBuildMenuWindow()
        {
            BuildMenuWindow = new MoveablePane
            {
                Rectangle = new Rectangle(400, 0, 200, 100), Texture = Textures.BuildMenuPane
            };

            CloseMenuRec = new Rectangle
            {
                X = BuildMenuWindow.Rectangle.X + BuildMenuWindow.Rectangle.Width - 30,
                Y = BuildMenuWindow.Rectangle.Y + 10,
                Width = 20,
                Height = 20
            };

            BuildMenuWindow.Location.X = 400;
            BuildMenuWindow.Location.Y = 0;

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
            if (Cursor.CursorRectangle.Intersects(BuildMenuWindow.Rectangle) && Mouse.GetState().LeftButton == ButtonState.Pressed)
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