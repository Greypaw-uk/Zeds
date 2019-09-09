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
                if (pawn.IsAlive)
                {
                    SpriteBatch.Draw(HumanTexture, pawn.Position, null, null,
                        new Vector2(0, HumanTexture.Height), pawn.Angle);
                }
            }
        }

        public static void DrawZeds()
        {
            foreach (var pawn in ZedList)
            {
                if (pawn.IsAlive)
                {
                    SpriteBatch.Draw(ZedTexture, pawn.Position, null, null,
                        new Vector2(0,ZedTexture.Height), pawn.Angle);
                }
            }
        }

        public static void DrawBuildings()
        {
            foreach (var Building in BuildingList)
            {
                SpriteBatch.Draw(Building.Texture, Building.Position);
            }
        }
    }
}
