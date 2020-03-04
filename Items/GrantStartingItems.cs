using Zeds.Engine;
using Zeds.Items.Weapons.Melee;

namespace Zeds.Items
{
    class GrantStartingItems
    {
        public static void PopulateItemList()
        {
            KitchenKnife kitchenKnife = new KitchenKnife
            {
                Icon = Textures.KitchenKnife,
                Power = 1,
                Range = 1,
                IsWeapon = true
            };

            EntityLists.AvailableWeaponList.Add(kitchenKnife);
            EntityLists.AvailableWeaponList.Add(kitchenKnife);
            EntityLists.AvailableWeaponList.Add(kitchenKnife);
        }
    }
}
