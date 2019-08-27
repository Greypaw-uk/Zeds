using Microsoft.Xna.Framework;

namespace Zeds
{
    public static class ZedController
    {
        private static Vector2 zone1;
        private static Vector2 zone2;
        private static Vector2 zone3;
        private static Vector2 zone4;

        public static void ZedSpawnLocations()
        {
            zone1.X = 0;
            zone1.Y = 0;

            zone2.X = 800;
            zone2.Y = 0;

            zone3.X = 0;
            zone3.Y = 600;

            zone4.X = 800;
            zone4.Y = 600;
        }
    }
}
