using Zeds.Engine;
using Zeds.Items.Weapons.Melee;

namespace Zeds.Items
{
    class GrantStartingItems
    {
        public static void PopulateItemList()
        {
            EntityLists.AvailableWeaponList.Add(CombatKnife.CreateCombatKnife());
            EntityLists.AvailableWeaponList.Add(KitchenKnife.CreateKitchenKnife());
            EntityLists.AvailableWeaponList.Add(KitchenKnife.CreateKitchenKnife());
        }
    }
}
