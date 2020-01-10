using System.Collections.Generic;
using Zeds.BuildingLogic;
using Zeds.Graphics;
using Zeds.ZedLogic;

namespace Zeds.Engine
{
    public static class EntityLists
    {
        public static List<Zed> ZedList = new List<Zed>();
        public static List<Human> HumanList = new List<Human>();
        public static List<Building> BuildingList = new List<Building>();
        public static List<DrawMenus.BuildMenuIcon> MainIconList = new List<DrawMenus.BuildMenuIcon>();
    }
}