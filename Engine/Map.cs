using Microsoft.Xna.Framework;

using Zeds.Engine;

namespace Zeds.Engine
{
    public static class Map
    {
        public static Vector2 MapCentre()
        {
            var mapCentre = new Vector2
            {
                X = Zeds.ScreenWidth / 2,
                Y = Zeds.ScreenHeight / 2
            };

            return mapCentre;
        }
    }
}