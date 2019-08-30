using Microsoft.Xna.Framework;
using static Zeds.Variables;
using static Zeds.HumanController;
using static Zeds.ZedController;

namespace Zeds
{
    public static class Graphics
    {
        public static void DrawHumans()
        {
            foreach (var pawn in human)
            {
                if (pawn.isAlive)
                {
                    spriteBatch.Draw(humanTexture, pawn.position, null, null,
                        new Vector2(0, humanTexture.Height), pawn.angle);
                }
            }
        }

        public static void DrawZeds()
        {
            foreach (var pawn in zeds)
            {
                if (pawn.isAlive)
                {
                    spriteBatch.Draw(zedTexture, pawn.position, null, null,
                        new Vector2(0,zedTexture.Height), pawn.angle);
                }
            }
        }
    }
}
