using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.Items.Weapons;
using Zeds.UI;
using Zeds.UI.PawnInfoPanel.Items_Boxes;

namespace Zeds.Pawns.HumanLogic
{
    class EquipWeapon
    {
        private static Weapon previousWeapon;

        public static void CheckWeaponIconInteraction()
        {
            foreach (var weapon in EntityLists.WeaponIconList)
            {
                if (Cursor.CursorRectangle.Intersects(weapon.Brec) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    foreach (var person in EntityLists.HumanList)
                    {
                        if (person.IsSelected)
                        {
                            if (person.IsArmed)
                            {
                                previousWeapon = person.EquippedWeapon;
                                person.AttackPower -= previousWeapon.Power;

                                person.EquippedWeapon = weapon.Weapon;

                                for (int i = EntityLists.AvailableWeaponList.Count - 1; i >= 0; i--)
                                {
                                    if (EntityLists.AvailableWeaponList[i] == person.EquippedWeapon)
                                    {
                                        EntityLists.AvailableWeaponList.Remove(person.EquippedWeapon);
                                    }
                                }

                                EntityLists.AvailableWeaponList.Add(previousWeapon);
                                person.AttackPower += weapon.Weapon.Power;
                            }
                            else
                            {
                                person.IsArmed = true;
                                person.EquippedWeapon = weapon.Weapon;

                                for (int i = EntityLists.AvailableWeaponList.Count - 1; i >= 0; i--)
                                {
                                    if (EntityLists.AvailableWeaponList[i] == person.EquippedWeapon)
                                    {
                                        EntityLists.AvailableWeaponList.Remove(person.EquippedWeapon);
                                    }
                                }

                                person.AttackPower += weapon.Weapon.Power;
                            }
                        }
                    }

                    ExtendIconChecks.IsWeaponIconListVisible = false;
                }
            }
        }
    }
}