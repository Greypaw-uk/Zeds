using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Pathfinding;

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

        public Point CurrentPoint;
        public Point DestinationPoint;

        public List<Node> Path;
    }
}
