using Zeds.Engine;

namespace Zeds.Pawns.ZedLogic
{
    public static class ZedBuildingCollision
    {
        // ToDo 2 Check LargeTent collision interaction
        public static void CheckZedBuildingCollision(Zed zed)
        {
            foreach (var building in EntityLists.BuildingList)
                if (zed.BRec.Intersects(building.BRec))
                {
                    //Console.WriteLine("Bump");

                    if (zed.Position.X >= building.Position.X)
                        zed.Position.X += 1;
                    if (zed.Position.X <= building.Position.X)
                        zed.Position.X -= 1;
                    else if (zed.Position.Y >= building.Position.Y)
                        zed.Position.Y += 1;
                    if (zed.Position.Y <= building.Position.Y)
                        zed.Position.Y -= 1;
                }
        }
    }
}