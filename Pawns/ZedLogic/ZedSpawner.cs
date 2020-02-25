using System;
using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Pawns.ZedLogic
{
    public static class ZedSpawner
    {
        public static int ZedQuantity = 1;
        private static Vector2 zone1;
        private static Vector2 zone2;
        private static Vector2 zone3;
        private static Vector2 zone4;
        private static Vector2 zone5;
        private static Vector2 zone6;
        private static Vector2 zone7;
        private static Vector2 zone8;

        public static Vector2 ZedSpawnPoint()
        {
            zone1.X = 0 - Textures.ZedTexture.Width;
            zone1.Y = 0 - Textures.ZedTexture.Height;

            zone2.X = Engine.Engine.MapSizeX + Textures.ZedTexture.Width;
            zone2.Y = 0 + Textures.ZedTexture.Height;

            zone3.X = 0 - Textures.ZedTexture.Width;
            zone3.Y = Engine.Engine.MapSizeY - Textures.ZedTexture.Height;

            zone4.X = Engine.Engine.MapSizeX + Textures.ZedTexture.Width;
            zone4.Y = Engine.Engine.MapSizeY + Textures.ZedTexture.Height;

            zone5.X = Engine.Engine.MapSizeX / 2 - Textures.ZedTexture.Width;
            zone5.Y = 0 - Textures.ZedTexture.Height;

            zone6.X = Engine.Engine.MapSizeX - Textures.ZedTexture.Width;
            zone6.Y = Engine.Engine.MapSizeY / 2 - Textures.ZedTexture.Height;

            zone7.X = Engine.Engine.MapSizeX / 2 - Textures.ZedTexture.Width;
            zone7.Y = Engine.Engine.MapSizeY + Textures.ZedTexture.Height;

            zone8.X = 0 - Textures.ZedTexture.Width;
            zone8.Y = Engine.Engine.MapSizeY / 2 + Textures.ZedTexture.Height;

            var random = new Random(Guid.NewGuid().GetHashCode());
            var randomZone = random.Next(0, 7);

            var zedSpawnPoint = new Vector2();

            switch (randomZone)
            {
                case 0:
                    zedSpawnPoint.X = zone1.X;
                    zedSpawnPoint.Y = zone1.Y;
                    break;

                case 1:
                    zedSpawnPoint.X = zone2.X;
                    zedSpawnPoint.Y = zone2.Y;
                    break;

                case 2:
                    zedSpawnPoint.X = zone3.X;
                    zedSpawnPoint.Y = zone3.Y;
                    break;

                case 3:
                    zedSpawnPoint.X = zone4.X;
                    zedSpawnPoint.Y = zone4.Y;
                    break;

                case 4:
                    zedSpawnPoint.X = zone5.X;
                    zedSpawnPoint.Y = zone5.Y;
                    break;

                case 5:
                    zedSpawnPoint.X = zone6.X;
                    zedSpawnPoint.Y = zone6.Y;
                    break;

                case 6:
                    zedSpawnPoint.X = zone7.X;
                    zedSpawnPoint.Y = zone7.Y;
                    break;

                case 7:
                    zedSpawnPoint.X = zone8.X;
                    zedSpawnPoint.Y = zone8.Y;
                    break;
            }
            return zedSpawnPoint;
        }

        public static void StopZedsBunching()
        {
            foreach (var zed in EntityLists.ZedList)
            foreach (var otherZed in EntityLists.ZedList)
                if (zed.BRec.Intersects(otherZed.BRec) && !zed.ID.Equals(otherZed.ID))
                    if (zed.Position.X >= otherZed.Position.X)
                        zed.Position.X -= Textures.ZedTexture.Width;
                    else if (zed.Position.X <= otherZed.Position.X)
                        zed.Position.X += Textures.ZedTexture.Width;
                    else if (zed.Position.Y >= otherZed.Position.Y)
                        zed.Position.Y += Textures.ZedTexture.Height;
                    else if (zed.Position.Y <= otherZed.Position.Y)
                        zed.Position.Y -= Textures.ZedTexture.Height;
        }
    }
}