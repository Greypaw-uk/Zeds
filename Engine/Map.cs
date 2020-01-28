using Microsoft.Xna.Framework;

namespace Zeds.Engine
{
    public static class Map
    {
        public static Vector2 MapCentre()
        {
            var mapCentre = new Vector2
            {
                X = Engine.MapSizeX / 2,
                Y = Engine.MapSizeY / 2
            };

            return mapCentre;
        }
    }
}