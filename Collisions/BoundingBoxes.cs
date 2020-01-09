using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds.Collisions
{
    public static class BoundingBoxes
    {
        public static Rectangle BoundingBox(Vector2 position, Texture2D texture)
        {
            return new Rectangle(
                (int) position.X,
                (int) position.Y,
                texture.Width,
                texture.Height);
        }
    }
}