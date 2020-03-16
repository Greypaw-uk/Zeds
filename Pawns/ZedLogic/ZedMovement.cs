using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Zeds.Engine;
using Zeds.Pathfinding;

namespace Zeds.Pawns.ZedLogic
{
    public class ZedTarget
    {
        public int Distance;
        public Vector2 Destination;
    }

    public static class ZedMovement
    {
        public static ZedTarget FindClosestTarget(Creature zed)
        {
            int distance;
            List<ZedTarget> targetList = new List<ZedTarget>();

            foreach (var human in EntityLists.HumanList)
            {
                distance = PathFind.PythagThatMofo(human.CurrentPoint, zed.CurrentPoint);

                if (distance <= zed.AlertRange)
                {
                    ZedTarget target = new ZedTarget
                    {
                        Distance = distance,
                        Destination = human.CurrentPoint
                    };

                    targetList.Add(target);
                }
            }

            foreach (var building in EntityLists.BuildingList)
            {
                distance = PathFind.PythagThatMofo(building.Position, zed.CurrentPoint);
                {
                    if (targetList.Count == 0)
                    {
                        if (distance <= zed.AlertRange)
                        {
                            ZedTarget target = new ZedTarget
                            {
                                Distance = distance,
                                Destination = building.Position
                            };

                            targetList.Add(target);
                        }
                    }
                }
            }

            ZedTarget currentBest;

            if (targetList.Count > 0)
            {
                currentBest = targetList[0];

                for (int i = 0; i < targetList.Count; i++)
                    if (targetList[i].Distance < currentBest.Distance)
                        currentBest = targetList[i];

                return currentBest;
            }

            return null;
        }
    }
}