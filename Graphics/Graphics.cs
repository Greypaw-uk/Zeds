using Microsoft.Xna.Framework;
using static Zeds.Engine.DefaultSettings;
using static Zeds.Engine.Zeds;

namespace Zeds
{
    public static class Graphics
    {
        public static void DrawHumans()
        {
            foreach (var pawn in HumanList)
                if (pawn.IsAlive)
// Warning disabled as old method of SpriteBatch.Draw() required so that pawns face movement direction.
#pragma warning disable CS0618 // Type or member is obsolete
                    SpriteBatch.Draw(HumanTexture, pawn.Position, null, null,
                        new Vector2(0, HumanTexture.Height), pawn.Angle);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public static void DrawZeds()
        {
            foreach (var pawn in ZedList)
                if (pawn.IsAlive)
// Warning disabled as old method of SpriteBatch.Draw() required so that pawns face movement direction.
#pragma warning disable CS0618 // Type or member is obsolete
                    SpriteBatch.Draw(ZedTexture, pawn.Position, null, null,
                        new Vector2(0, ZedTexture.Height), pawn.Angle);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public static void DrawBuildings()
        {
            foreach (var Building in BuildingList)
                SpriteBatch.Draw(Building.Texture, Building.Position, Color.AliceBlue);
        }

        public static void DrawBuildMenu()
        {
            foreach (var icon in MainIconList)
            {
                SpriteBatch.Draw(icon.Texture, icon.Position, Color.AliceBlue);
            }
            foreach (var building in BuildingList) SpriteBatch.Draw(building.Texture, building.Position, Color.AliceBlue);
        }
    }
}