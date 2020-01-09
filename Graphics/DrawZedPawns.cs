﻿using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Graphics
{
    public static class DrawZedPawns
    {
        public static void DrawZeds()
        {
            foreach (var pawn in DefaultSettings.ZedList)
                if (pawn.IsAlive)
// Warning disabled as old method of SpriteBatch.Draw() required so that pawns face movement direction.
#pragma warning disable CS0618 // Type or member is obsolete
                    Engine.Zeds.SpriteBatch.Draw(DefaultSettings.ZedTexture, pawn.Position, null, null,
                        new Vector2(0, DefaultSettings.ZedTexture.Height), pawn.Angle);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}