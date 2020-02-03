using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class BuildMenuPane
    {
        private static MoveablePane buildMenuWindow = new MoveablePane
        {
            Location = Engine.Engine.MouseCoordinates,
            Rectangle = new Rectangle((int)Engine.Engine.MouseCoordinates.X,
                (int)Engine.Engine.MouseCoordinates.Y, 200, 100),
            Texture = Textures.BuildMenuPane
        };

        public static bool IsBuildMenuWindowVisible;

        //ToDo 1 Update BuildMenuIcons relevant to Location
        public static void UpdateBuildMenuWindowLocation()
        {
            if (Cursor.CursorRectangle.Intersects(buildMenuWindow.Rectangle) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                buildMenuWindow.Location = Engine.Engine.MouseCoordinates;
        }

        public static void DrawBuildMenuPane()
        {
            Engine.Engine.SpriteBatch.Draw(buildMenuWindow.Texture, buildMenuWindow.Location, Color.White);
        }
    }
}
