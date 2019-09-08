using Microsoft.Xna.Framework;
using static Zeds.Variables;

namespace Zeds
{
    public static class Graphics
    {
        public static void DrawHumans()
        {
            foreach (var pawn in HumanList)
            {
                if (pawn.isAlive)
                {
                    SpriteBatch.Draw(HumanTexture, pawn.position, null, null,
                        new Vector2(0, HumanTexture.Height), pawn.angle);
                }
            }
        }

        public static void DrawZeds()
        {
            foreach (var pawn in ZedList)
            {
                if (pawn.isAlive)
                {
                    SpriteBatch.Draw(ZedTexture, pawn.position, null, null,
                        new Vector2(0,ZedTexture.Height), pawn.angle);
                }
            }
        }

        public static void DrawBuildings()
        {
            SpriteBatch.Draw(HqTexture, MapCentre());
        }
    }
}
