using System;
using Zeds.Engine;

namespace Zeds.Items.Weapons.Melee
{
    public class CombatKnife : Weapon
    {
        public static CombatKnife CreateCombatKnife()
        {
            CombatKnife combatKnife = new CombatKnife
            {
                Icon = Textures.CombatKnife,
                Power = 1,
                Range = 1,
                IsWeapon = true,
                ID = Guid.NewGuid()
            };

            return combatKnife;
        }
    }
}
