using System;
using Microsoft.Xna.Framework;
using Zeds.Engine;
using Zeds.Engine.Collisions;

namespace Zeds.ZedLogic
{
    public static class ZedMovement
    {
        private static void UpdateBoundingRectangle(Zed zed)
        {
            zed.BRec.X = (int) zed.Position.X;
            zed.BRec.Y = (int) zed.Position.Y;
        }

        public static void CalculateZedMovement()
        {
            if (DefaultSettings.ZedList.Count != 0)
                foreach (var zed in DefaultSettings.ZedList)
                {
                    // Move zed towards closest target
                    var dir = FindClosestTarget(zed) - zed.Position;
                    dir.Normalize();

                    // Rotate to face movement direction
                    var rotation = (float) Math.Atan2(dir.Y, dir.X);

                    UpdateBoundingRectangle(zed);
                    UpdateZedPosition(zed, rotation, dir);
                }
        }

        private static Vector2 FindClosestTarget(Zed zed)
        {
            var buildingLocation = new Vector2();
            var humanLocation = new Vector2();
            Vector2 target;

            float closestBuilding = 1000;
            float closestHuman = 1000;

            if (DefaultSettings.HumanList.Count != 0)
                foreach (var human in DefaultSettings.HumanList)
                {
                    var distance = Vector2.Distance(zed.Position, human.Position);

                    if (distance <= closestHuman)
                    {
                        closestHuman = distance;
                        humanLocation = human.Position;
                    }
                }
            else if (DefaultSettings.BuildingList.Count != 0)
                foreach (var building in DefaultSettings.BuildingList)
                {
                    var distance = Vector2.Distance(zed.Position, building.Position);
                    {
                        if (distance <= closestBuilding)
                        {
                            closestBuilding = distance;
                            buildingLocation = building.Position;
                        }
                    }
                }

            if (closestHuman < closestBuilding)
                target = humanLocation;
            else
                target = buildingLocation;

            return target;
        }

        private static void UpdateZedPosition(Zed zed, float rotation, Vector2 dir)
        {
            ZedBuildingCollision.CheckZedBuildingCollision(zed);

            zed.Angle = rotation;
            zed.Position += dir * zed.Speed;
        }
    }
}