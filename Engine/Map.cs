using Microsoft.Xna.Framework;

using static Zeds.Engine.Zeds;

namespace Zeds.Engine
{
    public static class Map
    {
        public static Vector2 MapCentre()
        {
            var mapCentre = new Vector2
            {
                X = ScreenWidth / 2,
                Y = ScreenHeight / 2
            };

            return mapCentre;
        }
    }
}