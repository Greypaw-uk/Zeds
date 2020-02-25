using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds.Pawns
{
    public class Creature
    {
        public bool IsAlive;
        public bool IsSpawned;

        public int Health;
        public string ID;

        public string Description;

        public float Angle;
        public Vector2 Position;
        public float Speed;
        public Rectangle BRec;

        public Texture2D Texture;
    }
}
