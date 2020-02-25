using System;
using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Pawns.HumanLogic
{
    public static class HumanMovement
    {
        private static readonly float PanicDistance = 100f;

        public static void RunFromZeds()
        {
            foreach (var human in EntityLists.HumanList)
            foreach (var zed in EntityLists.ZedList)
            {
                var distance = (human.Position.Y - zed.Position.Y) * (human.Position.Y - zed.Position.Y) +
                               (human.Position.X - zed.Position.X) * (human.Position.X - zed.Position.X);

                distance = (float) Math.Sqrt(distance);

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

        //ToDo 2 Rotation is affecting offset of collision box
        private static void UpdateHumanPosition(Human human, float rotation, Vector2 dir)
        { 
            human.Angle = rotation;
            human.Position += dir * human.Speed;

            human.BRec.X = (int)human.Position.X - (human.Texture.Width / 2);
            human.BRec.Y = (int)human.Position.Y - (human.Texture.Height / 2);
        }
    }
}