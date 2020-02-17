using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class BuildMenuPane
    {
        public static MoveablePane BuildMenuWindow;

        public static bool IsBuildMenuWindowVisible;

        public static void CreateBuildMenuWindow()
        {
            BuildMenuWindow = new MoveablePane
            {
                Location = Engine.Engine.MouseCoordinates,
                Rectangle = new Rectangle((int)Engine.Engine.MouseCoordinates.X,
                    (int)Engine.Engine.MouseCoordinates.Y, 200, 100),
                Texture = Textures.BuildMenuPane
            };

            BuildMenuWindow.Location = Engine.Engine.MouseCoordinates;

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
                //var clickLocation = new Vector2();
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
                    /*
                    clickLocation.X = Engine.Engine.MouseCoordinates.X - BuildMenuWindow.Location.X - 10;
                    clickLocation.Y = Engine.Engine.MouseCoordinates.Y - BuildMenuWindow.Location.Y - 10;


                    BuildMenuWindow.Location.X +=  clickLocation.X;
                    BuildMenuWindow.Location.Y += clickLocation.Y;

                    BuildMenuWindow.Rectangle.X = (int)BuildMenuWindow.Location.X;
                    BuildMenuWindow.Rectangle.Y = (int)BuildMenuWindow.Location.Y;
                    */

                    //ToDo 3 Improve movement of Window
                    BuildMenuWindow.Location.X =
                        (int) Engine.Engine.MouseCoordinates.X - (Textures.BuildMenuPane.Width / 2);
                    BuildMenuWindow.Location.Y =
                        (int) Engine.Engine.MouseCoordinates.Y - (Textures.BuildMenuPane.Height / 2);

                    BuildMenuWindow.Rectangle.X = (int) BuildMenuWindow.Location.X;
                    BuildMenuWindow.Rectangle.Y = (int) BuildMenuWindow.Location.Y;
                    

                    UpdateMainMenuLocation();
                    UpdateBuildMenuLocation();
                    RollOverText.UpdateRollOverTextPosition();
                }
            }
        }

        public static void InitialiseBuildMenuLocation()
        {
            CreateBuildMenuWindow();
            UpdateMainMenuLocation();
            UpdateBuildMenuLocation();
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
    }
}