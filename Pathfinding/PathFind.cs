using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.Pawns;

namespace Zeds.Pathfinding
{
    class PathFind
    {
            public static void MovePawns()
        {
            SetPawnDestination();

            foreach (var pawn in EntityLists.HumanList)
            {
                pawn.Path = GetPath(pawn.CurrentPoint, pawn.DestinationPoint);

                MovePawn(pawn);
            }
        }

        private static void SetPawnDestination()
        {
            foreach (var pawn in EntityLists.HumanList)
            {
                if (pawn.IsSelected)
                {
                    if (Mouse.GetState().RightButton == ButtonState.Pressed)
                    {
                        pawn.DestinationPoint.X = (int)Engine.Engine.MouseCoordinates.X / 15;
                        pawn.DestinationPoint.Y = (int)Engine.Engine.MouseCoordinates.Y / 15;
                    }
                }
            }
        }

        private static List<Node> GetPath (Point currentPoint, Point destinationPoint)
        {
            var neighbours = new List<Node>
            {
                Grid.NodeList[currentPoint.X - 1][currentPoint.Y],
                Grid.NodeList[currentPoint.X + 1][currentPoint.Y],
                Grid.NodeList[currentPoint.X][currentPoint.Y - 1],
                Grid.NodeList[currentPoint.X][currentPoint.Y + 1]
            };

            var currentDistance = PythagThatMofo(destinationPoint, currentPoint);

            Node currentFavourite = new Node{Point = currentPoint};

            foreach (var neighbour in neighbours)
            {
                var newDistance = PythagThatMofo(destinationPoint, neighbour.Point);

                if (newDistance < currentDistance)
                {
                    currentFavourite = Grid.NodeList[currentPoint.X][currentPoint.Y];
                }
            }

            System.Diagnostics.Debug.Assert(currentFavourite != null);
            var resultingPath = new List<Node> { currentFavourite };

            if (currentFavourite.Point != destinationPoint)
            {
                resultingPath.AddRange(GetPath(currentFavourite.Point, destinationPoint));
            }

            return resultingPath;
        }

        private static double PythagThatMofo(Point destination, Point current)
        {
            double x = destination.X - current.X;
            x *= x;

            double y = destination.Y - current.Y;
            y *= y;

            return Math.Sqrt(x + y);
        }

        private static void MovePawn(Creature pawn)
        {
            for (int i = 0; i < pawn.Path.Count; i++)
            {
                if (pawn.CurrentPoint.X > pawn.Path[i].Point.X)
                    MovePawnLeft(pawn);
                else if (pawn.CurrentPoint.X < pawn.Path[i].Point.X)
                    MovePawnRight(pawn);

                if (pawn.CurrentPoint.Y > pawn.Path[i].Point.Y)
                    MovePawnUp(pawn);
                else if (pawn.CurrentPoint.Y < pawn.Path[i].Point.Y)
                    MovePawnDown(pawn);
            }
        }

        private static void MovePawnLeft(Creature pawn)
        {
            pawn.Position.X -= 1;
        }

        private static void MovePawnRight(Creature pawn)
        {
            pawn.Position.X += 1;
        }

        private static void MovePawnUp(Creature pawn)
        {
            pawn.Position.Y -= 1;
        }

        private static void MovePawnDown(Creature pawn)
        {
            pawn.Position.Y += 1;
        }
    }
}
