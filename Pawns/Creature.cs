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

        public float Angle;
        public Vector2 Position;
        public float Speed;
        public BoundingBox BoundingBox;

        public Texture2D Texture;
    }
}
