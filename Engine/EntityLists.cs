using System.Collections.Generic;
using Zeds.BuildingLogic;
using Zeds.Graphics.Background;
using Zeds.Items.Weapons;
using Zeds.Pawns.HumanLogic;
using Zeds.Pawns.ZedLogic;
using Zeds.Resources;
using Zeds.UI.Build_Menu;
using Zeds.UI.PawnInfoPanel.Items_Boxes;

namespace Zeds.Engine
{
    public static class EntityLists
    {
        public static List<Zed> ZedList = new List<Zed>();
        public static List<Human> HumanList = new List<Human>();

        public static List<Building> BuildingList = new List<Building>();
        public static List<Building> RuinedBuildingList = new List<Building>();

        public static List<DrawBuildMenus.MainMenuIcon> MainIconList = new List<DrawBuildMenus.MainMenuIcon>();
        public static List<DrawBuildMenus.BuildMenuIcon> BuildIconList = new List<DrawBuildMenus.BuildMenuIcon>();

        public static List<GrassTuft> GrassList = new List<GrassTuft>();
        public static List<Bush> BushList = new List<Bush>();
        public static List<Tree> TreeList = new List<Tree>();
        public static List<TreeFoliage> TreeFoliageList = new List<TreeFoliage>();

        public static List<Weapon> AvailableWeaponList = new List<Weapon>();
        public static List<string> AvailableHeadwearList = new List<string>();
        public static List<string> AvailableChestwearList = new List<string>();
        public static List<string> AvailableMiscItemList = new List<string>();

        public static List<WeaponIcon> WeaponIconList = new List<WeaponIcon>();
    }
}