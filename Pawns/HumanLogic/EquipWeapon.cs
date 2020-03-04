using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.UI;
using Zeds.UI.PawnInfoPanel.Items_Boxes;

namespace Zeds.Pawns.HumanLogic
{
    class EquipWeapon
    {
        public static void CheckWeaponIconInteraction()
        {
            foreach (var weaponIcon in EntityLists.WeaponIconList)
            {
                if (Cursor.CursorRectangle.Intersects(weaponIcon.Brec) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    foreach (var person in EntityLists.HumanList)
                    {
                        if (person.IsSelected)
                        {
                            if (person.IsArmed)
                            {
                                var previousWeapon = person.EquippedWeapon;
                                person.EquippedWeapon = weaponIcon.Weapon;

                                for (int i = EntityLists.AvailableWeaponList.Count - 1; i > 0; i--)
                                    EntityLists.AvailableWeaponList.Remove(EntityLists.AvailableWeaponList[i]);

                                EntityLists.AvailableWeaponList.Add(previousWeapon);
                            }
                            else
                            {
                                person.IsArmed = true;
                                person.EquippedWeapon = weaponIcon.Weapon;

                                for (int i = EntityLists.AvailableWeaponList.Count - 1; i > 0; i--)
                                    EntityLists.AvailableWeaponList.Remove(EntityLists.AvailableWeaponList[i]);
                            }
                        }
                    }

                    ExtendIconChecks.IsWeaponIconListVisible = false;
                }
            }
        }
    }
}
