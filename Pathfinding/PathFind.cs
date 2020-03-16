using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Zeds.Engine;
using Zeds.Pawns;
using Zeds.Pawns.ZedLogic;

namespace Zeds.Pathfinding
{
    class PathFind
    {
        public static void MovePawns()
        {
            SetHumanPawnDestination();

            foreach (var pawn in EntityLists.HumanList)
            {
                // i.e. if it's got somewhere to go and we haven't already worked out a route
                // without the count check, it'll constantly be recalculating a route
                // you might want this later but .. for now ... 
                if (pawn.CurrentPoint != pawn.DestinationPoint && (pawn.Path == null || pawn.Path.Count == 0))
                {
                    pawn.Path = GetPath(pawn.CurrentPoint, pawn.DestinationPoint);
                }

                if (pawn.Path?.Count > 0)
                {
                    if (Mouse.GetState().RightButton == ButtonState.Pressed)
                    {
                        pawn.Path.Clear();
                        SetHumanPawnDestination();
                    }
                    else
                    {
                        MovePawn(pawn);
                    }
                }
            }

            if (EntityLists.ZedList.Count != 0)
            {
                foreach (var zed in EntityLists.ZedList)
                {
                    ZedBuildingCollision.CheckZedBuildingCollision(zed);
                    ZedHumanCollision.CheckZedHumanCollision(zed);

                    var target = ZedMovement.FindClosestTarget(zed);

                    if (target != null)
                    {
                        zed.DestinationPoint = target.Destination;

                        zed.Path = GetPath(zed.CurrentPoint, zed.DestinationPoint);
                        MovePawn(zed);
                    }
                }
            }
        }

        private static void SetHumanPawnDestination()
        {
            foreach (var pawn in EntityLists.HumanList)
                if (pawn.IsSelected)
                {
                    if (Mouse.GetState().RightButton == ButtonState.Pressed)
                    {
                        if (Mouse.GetState().X > 15 && Mouse.GetState().X < Engine.Engine.ScreenWidth - 15)
                            pawn.DestinationPoint.X = (int) Engine.Engine.MouseCoordinates.X;

                        if (Mouse.GetState().Y > 0 + 15 && Mouse.GetState().Y < Engine.Engine.ScreenHeight -15)
                            pawn.DestinationPoint.Y = (int) Engine.Engine.MouseCoordinates.Y;
                    }
                }
        }

        private static List<Vector2> GetPath (Vector2 fromPoint, Vector2 toPoint)
        {
            var fromPointIndexX = fromPoint.X / 15;
            var fromPointIndexY = fromPoint.Y / 15;
            var toPointIndexX = toPoint.X / 15;
            var toPointIndexY = toPoint.Y / 15;


            var neighbours = new List<Node>
            {
                Grid.NodeList[(int) fromPointIndexX - 1][(int) fromPointIndexY],
                Grid.NodeList[(int) fromPointIndexX + 1][(int) fromPointIndexY],
                Grid.NodeList[(int) fromPointIndexX][(int) fromPointIndexY - 1],
                Grid.NodeList[(int) fromPointIndexX][(int) fromPointIndexY + 1]
            };

            var currentDistance = PythagThatMofo(Grid.NodeList[(int) toPointIndexX][(int) toPointIndexY].Point,
                Grid.NodeList[(int) fromPointIndexX][(int) fromPointIndexY].Point);

            Node currentFavourite = null;

            foreach (var neighbour in neighbours)
            {
                var newDistance = PythagThatMofo(Grid.NodeList[(int) toPointIndexX][(int) toPointIndexY].Point,
                    neighbour.Point);

                if (newDistance < currentDistance) currentFavourite = neighbour;
            }

            // if we get here, and currentFavourite is null, then one of 2 things has happened:
            // a) there IS no path. Given we're not checking for impassible terrain, that's not going to happen (yet)
            // b) there isn't a closer point in the pathfinding nodes
            //    if this is the case, we just need to add one more point to the end; where we want to go as a final step
            if (currentFavourite == null)
                return new List<Vector2> {toPoint}; // but you've got the path as a list of nodes, so we can't

            System.Diagnostics.Debug.Assert(currentFavourite != null);
            var resultingPath = new List<Vector2> {currentFavourite.Point};

            if (currentFavourite.Point.X != toPointIndexX || currentFavourite.Point.Y != toPointIndexY)
                // ToDo 3 Watch for edge case
                resultingPath.AddRange(GetPath(currentFavourite.Point, toPoint));

            return resultingPath;
        }

        public static int PythagThatMofo(Vector2 destination, Vector2 current)
        {
            var x = (int) destination.X - (int) current.X;
            x *= x;

            var y = (int) destination.Y - (int) current.Y;
            y *= y;

            return (int) Math.Sqrt(x + y);
        }

        private static void MovePawn(Creature pawn)
        {
            if (pawn.Path.Count == 0)
                // if there isn't a next step, there's nothing left to do here
                return;

            var nextStep = pawn.Path.First();


            // Left and Right Movement
            if (Math.Abs(pawn.CurrentPoint.X - nextStep.X) < 0.1f)
            {
                // Pawn is close enough to node and doesn't need to move
            }
            else if (pawn.CurrentPoint.X > nextStep.X)
            {
                // Move Left
                pawn.Position.X -= pawn.Speed;
            }
            else if (pawn.CurrentPoint.X < nextStep.X)
            {
                // Move Right
                pawn.Position.X += pawn.Speed;
            }

            // Up and Down Movement
            if (Math.Abs(pawn.CurrentPoint.Y - nextStep.Y) < 0.1f)
            {
                // Pawn is close enough to node and doesn't need to move
            }
            else if (pawn.CurrentPoint.Y > nextStep.Y)
            {
                // Move Up
                pawn.Position.Y -= pawn.Speed;
            }
            else if (pawn.CurrentPoint.Y < nextStep.Y)
            {
                // Move Down
                pawn.Position.Y += pawn.Speed;
            }

            pawn.Angle = SetPawnAngle(nextStep, pawn);
            pawn.BRec = AdjustPawnBRec(pawn);

            pawn.CurrentPoint.X = (int) pawn.Position.X;
            pawn.CurrentPoint.Y = (int) pawn.Position.Y;
            
            // Remove visited Nodes from Path
            if (Math.Abs(pawn.Position.X - nextStep.X) < 0.1f && Math.Abs(pawn.Position.Y - nextStep.Y) < 0.1f)
                pawn.Path.RemoveAt(0);
        }

        private static float SetPawnAngle(Vector2 nextStep, Creature pawn)
        {
            var direction = nextStep - pawn.CurrentPoint;
            direction.Normalize();

            return (float) Math.Atan2(direction.Y, direction.X);
        }

        private static Rectangle AdjustPawnBRec(Creature pawn)
        {
            pawn.BRec.X = (int) pawn.Position.X - pawn.BRec.Width / 2;
            pawn.BRec.Y = (int) pawn.Position.Y - pawn.BRec.Height / 2;

            return pawn.BRec;
        }
    }
}
