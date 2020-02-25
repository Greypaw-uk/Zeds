using System.Collections.Generic;
using Zeds.BuildingLogic;
using Zeds.Graphics;
using Zeds.Graphics.Background;
using Zeds.Pawns.HumanLogic;
using Zeds.Pawns.ZedLogic;
using Zeds.UI.Build_Menu;

namespace Zeds.Engine
{
    public static class EntityLists
    {
        public static List<Zed> ZedList = new List<Zed>();
        public static List<Human> HumanList = new List<Human>();

        public static List<Building> BuildingList = new List<Building>();

        public static List<DrawBuildMenus.MainMenuIcon> MainIconList = new List<DrawBuildMenus.MainMenuIcon>();
        public static List<DrawBuildMenus.BuildMenuIcon> BuildIconList = new List<DrawBuildMenus.BuildMenuIcon>();

        public static List<GrassTuft> GrassList = new List<GrassTuft>();
    }
}