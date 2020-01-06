using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Zeds.Engine;

namespace Zeds
{
    public static class Collisions
    {
        public static Rectangle BoundingRectangle(Vector2 position, Texture2D texture)
        {
            return new Rectangle(
                (int) position.X,
                (int) position.Y,
                texture.Width,
                texture.Height);
        }

        public static void StopZedsBunching()
        {
            foreach (var zed in ZedList)
            foreach (var otherZed in ZedList)
                if (zed.boundingBox.Intersects(otherZed.boundingBox) && !zed.ID.Equals(otherZed.ID))
                {
                    if (zed.Position.X >= otherZed.Position.X)
                        zed.Position.X -= ZedTexture.Width;
                    else if (zed.Position.X <= otherZed.Position.X)
                        zed.Position.X += ZedTexture.Width;
                    else if (zed.Position.Y >= otherZed.Position.Y)
                        zed.Position.Y += ZedTexture.Height;
                    else if (zed.Position.Y <= otherZed.Position.Y) zed.Position.Y -= ZedTexture.Height;
                }
        }

        public static void CheckBuildingCollision(BoundingBox box)
        {
            foreach (var building in BuildingList)
            {
                /*
                if(box.Intersects(building.boundingBox))
                {
                    Console.WriteLine("Bump");
                }
                */
            }
        }
    }
}