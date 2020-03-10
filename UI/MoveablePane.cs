using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds.UI
{
    //ToDo 2 Stop different MoveablePanes interfering with each other
    public class MoveablePane
    {
        public Texture2D Texture;
        public Vector2 Location;
        public Rectangle Rectangle;
        public Vector2 TextCoordinates;
        public string Description;
    }
}
