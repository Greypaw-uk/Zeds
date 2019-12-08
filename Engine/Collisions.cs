using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Zeds.Engine;

namespace Zeds
{
    public static class Collisions
    {
        public static Rectangle CreateBoundingBox(Vector2 position, Texture2D texture)
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
                if (zed.BRec.Intersects(otherZed.BRec) && !zed.ID.Equals(otherZed.ID))
                    if (zed.Position.X >= otherZed.Position.X)
                        zed.Position.X -= ZedTexture.Width;
                    else if (zed.Position.X <= otherZed.Position.X)
                        zed.Position.X += ZedTexture.Width;
                    else if (zed.Position.Y >= otherZed.Position.Y)
                        zed.Position.Y += ZedTexture.Height;
                    else if (zed.Position.Y <= otherZed.Position.Y)
                        zed.Position.Y -= ZedTexture.Height;
        }

        public static void CheckZedBuildingCollision(Zed zed)
        {
            foreach (var building in BuildingList)
                if (zed.BRec.Intersects(building.BRec))
                {
                    Console.WriteLine("Bump");

                    if (zed.Position.X >= building.Position.X)
                        zed.Position.X += 1;
                    if (zed.Position.X <= building.Position.X)
                        zed.Position.X -= 1;
                    else if (zed.Position.Y >= building.Position.Y)
                        zed.Position.Y += 1;
                    if (zed.Position.Y <= building.Position.Y)
                        zed.Position.Y -= 1;
                }
        }
    }
}