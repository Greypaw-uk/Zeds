using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Zeds.Pawns
{
    public class Creature
    {
        public bool IsAlive;
        public bool IsSpawned;

        public float CurrentHealth;
        public float MaxHealth;

        public string ID;

        public string Description;

        public float Angle;
        public Vector2 Position;
        public float Speed;
        public Rectangle BRec;

        public Texture2D Texture;

        public Vector2 CurrentPoint;
        public Vector2 DestinationPoint;

        public List<Vector2> Path;
        public float AlertRange;

        public int AttackPower;
        public int AttackSpeed;
        public int NextAttack;
    }
}
