using System;
using Microsoft.Xna.Framework;
using Zeds.Engine;
using Zeds.Pathfinding;

namespace Zeds.Pawns.HumanLogic
{
    public static class HumanMovement
    {
        private static readonly float PanicDistance = 100f;


        //ToDo 2 Re-write this to work with Pathfinding
        public static void RunFromZeds()
        {
            foreach (var human in EntityLists.HumanList)
            foreach (var zed in EntityLists.ZedList)
            {
                var distance = PathFind.PythagThatMofo(human.Position, zed.Position);

                if (distance != 0)
                    if (distance <= PanicDistance)
                    {
                        var dir = human.Position - zed.Position;
                        dir.Normalize();

                        // Rotate to face movement direction
                        var rotation = (float) Math.Atan2(dir.Y, dir.X);

                        UpdateHumanPosition(human, rotation, dir);
                    }
            }
        }
        
        private static void UpdateHumanPosition(Human human, float rotation, Vector2 dir)
        { 
            human.Angle = rotation;
            human.Position += dir * human.Speed;

            human.BRec.X = (int)human.Position.X - (human.Texture.Width / 2);
            human.BRec.Y = (int)human.Position.Y - (human.Texture.Height / 2);
        }
    }
}