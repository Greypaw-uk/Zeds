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
                    targetList.Add(new ZedTarget { Distance = distance, Destination = human.CurrentPoint });
                }
            }

            foreach (var building in EntityLists.BuildingList)
            {
                distance = PathFind.PythagThatMofo(building.Position, zed.CurrentPoint);
                {
                    //If no humans, aim for closest building
                    if (targetList.Count == 0)
                        targetList.Add(new ZedTarget
                        {
                            Distance = distance,
                            Destination = new Vector2(building.Position.X + (1.0f * building.Texture.Width / 2),
                                building.Position.Y + (1.0f *  building.Texture.Height / 2))
                        });
                    /*
                    if (distance <= zed.AlertRange)
                    {
                        targetList.Add(new ZedTarget { Distance = distance, Destination = building.Position });
                    }
                    */
                }
            }

            if (targetList.Count > 0)
            {
                var currentBest = targetList[0];

                for (var i = 0; i < targetList.Count; i++)
                    if (targetList[i].Distance < currentBest.Distance)
                        currentBest = targetList[i];

                return currentBest;
            }

            return null;
        }
    }
}