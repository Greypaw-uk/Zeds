using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Zeds.Engine;

namespace Zeds.Pathfinding
{
    class Grid
    {
        public static List<List<Node>> NodeList = new List<List<Node>>();


        public static void SetUpGrid()
        {
            CreateGrid();
            SetNodeCost();
        }


        /// <summary>
        /// Break the play area into columns, each containing Nodes
        /// </summary>
        private static void CreateGrid()
        {
            for (int x = 0; x < Engine.Engine.ScreenWidth; x += 15)
            {
                NodeList.Add(new List<Node>());

                for (int y = 0; y < Engine.Engine.ScreenHeight; y += 15)
                { 
                    NodeList.Last().Add(new Node
                    {
                        Point = {X = x, Y = y}, 
                        BRec = new Rectangle {X = x, Y = y, Width = 15, Height = 15}
                    });
                }
            }
        }

        /// <summary>
        /// Check each node - any buildings sets a high cost for that node so that it can be discounted when working out movement
        /// </summary>
        private static void SetNodeCost()
        {
            foreach (var building in EntityLists.BuildingList)
            {
                for (int x = 0; x < NodeList.Count; x++)
                {
                    for (int y = 0; y < NodeList[x].Count; y++)
                    {
                        if (building.BRec.Intersects(NodeList[x][y].BRec))
                            NodeList[x][y].Cost = 1000;
                    }
                }
            }
        }
    }
}