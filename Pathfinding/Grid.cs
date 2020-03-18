using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Zeds.Pathfinding
{
    class Grid
    {
        public static List<List<Node>> NodeList = new List<List<Node>>();

        public static void SetUpGrid()
        {
            for (int x = 0; x < Engine.Engine.ScreenWidth; x += 15)
            {
                NodeList.Add(new List<Node>());

                for (int y = 0; y < Engine.Engine.ScreenHeight; y += 15)
                {
                    NodeList.Last().Add(new Node
                    {
                        Point = { X = x, Y = y },
                        BRec = new Rectangle { X = x, Y = y, Width = 15, Height = 15 }
                    });
                }
            }
        }
    }
}