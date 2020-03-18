using Zeds.Engine;

namespace Zeds.Debug
{
    class DamageEntities
    {
        public static void DamageHumanPawns()
        {
            foreach(var person in EntityLists.HumanList)
                person.CurrentHealth -= 0.1f;
        }

        public static void DamageZedPawns()
        {
            foreach (var zed in EntityLists.ZedList)
                zed.CurrentHealth -= 0.1f;
        }

        public static void DamageBuildings()
        {
            foreach (var building in EntityLists.BuildingList)
                building.CurrentHealth -= 1;
        }
    }
}