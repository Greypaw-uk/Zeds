using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.UI.PawnInfoPanel.Items_Boxes
{
    class CreateItemIcons
    {
        public static Rectangle IconRec;

        public static void UpdateWeaponIconList()
        {
            EntityLists.WeaponIconList.Clear();
            Vector2 iconLocation = new Vector2
            {
                X = PawnInfo.ExpandHandBox.X - 20,
                Y = PawnInfo.ExpandHandBox.Y
            };

            foreach (var weapon in EntityLists.AvailableWeaponList)
            {
                iconLocation.X += 35;

                IconRec = new Rectangle
                {
                    X = (int)iconLocation.X,
                    Y = (int)iconLocation.Y,
                    Width = 30,
                    Height = 30
                };

                WeaponIcon icon = new WeaponIcon
                {
                    Weapon = weapon,
                    Brec = IconRec
                };

                EntityLists.WeaponIconList.Add(icon);
            }
        }
    }
}
