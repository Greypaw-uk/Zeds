using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Graphics
{
    public static class DrawHumanPawns
    {
        public static void DrawHumans()
        {
            foreach (var pawn in EntityLists.HumanList)
                if (pawn.IsAlive)
// Warning disabled as old method of SpriteBatch.Draw() required so that pawns face movement direction.
#pragma warning disable CS0618 // Type or member is obsolete
                    Engine.Zeds.SpriteBatch.Draw(Textures.HumanTexture, pawn.Position, null, null,
                        new Vector2(0, Textures.HumanTexture.Height), pawn.Angle);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}