using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;

namespace Zeds.Pawns.HumanLogic
{
    public static class DrawHumanPawns
    {
        public static void DrawHumans()
        {
            foreach (var pawn in EntityLists.HumanList)
                if (pawn.IsAlive)
                    Engine.Engine.SpriteBatch.Draw(pawn.Texture, pawn.Position, null, Color.White, pawn.Angle,
                        new Vector2(pawn.Texture.Width / 2, pawn.Texture.Height / 2), 1, SpriteEffects.None, 0);
        }
    }
}
