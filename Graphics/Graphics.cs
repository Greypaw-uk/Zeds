using Microsoft.Xna.Framework;
using static Zeds.DefaultSettings;
using static Zeds.Game1;

namespace Zeds
{
    public static class Graphics
    {
        public static void DrawHumans()
        {
            foreach (var pawn in HumanList)
                if (pawn.IsAlive)
                    SpriteBatch.Draw(HumanTexture, pawn.Position, null, null,
                        new Vector2(0, HumanTexture.Height), pawn.Angle);
        }

        public static void DrawZeds()
        {
            foreach (var pawn in ZedList)
                if (pawn.IsAlive)
                    SpriteBatch.Draw(ZedTexture, pawn.Position, null, null,
                        new Vector2(0, ZedTexture.Height), pawn.Angle);
        }

        public static void DrawBuildings()
        {
            foreach (var Building in BuildingList)
                SpriteBatch.Draw(Building.Texture, Building.Position);
        }

        public static void DrawBuildMenu()
        {
            var iconScale = new Vector2
            {
                X = 0.25f,
                Y = 0.25f
            };

            foreach (var icon in MainIconList)
            {
                SpriteBatch.Draw(icon.Texture, icon.Position,null, null, iconScale);
            }
            foreach (var Building in BuildingList) SpriteBatch.Draw(Building.Texture, Building.Position);
        }
    }
}