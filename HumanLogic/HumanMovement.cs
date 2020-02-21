using System;
using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.HumanLogic
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

        private static void UpdateHumanPosition(Human human, float rotation, Vector2 dir)
        {
            human.Angle = rotation;
            human.Position += dir * human.Speed;

            human.BRec.X = (int)human.Position.X;
            human.BRec.Y = (int) human.Position.Y;
        }
    }
}