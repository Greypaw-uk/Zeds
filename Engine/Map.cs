using Microsoft.Xna.Framework;
using static Zeds.Engine.DefaultSettings;

namespace Zeds.Engine
{
    public static class Map
    {
        public static Vector2 MapCentre()
        {
            var mapCentre = new Vector2
            {
                X = ScreenWidth / 2 - DefaultSettings.HumanTexture.Width / 2,
                Y = ScreenHeight / 2 - DefaultSettings.HumanTexture.Height / 2
            };

            return mapCentre;
        }
    }
}