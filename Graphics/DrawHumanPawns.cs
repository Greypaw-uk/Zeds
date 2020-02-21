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
                    Engine.Engine.SpriteBatch.Draw(pawn.Texture, pawn.Position, null, null,
                        new Vector2(0, pawn.Texture.Height), pawn.Angle);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}