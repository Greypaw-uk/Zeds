using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.UI.PawnInfoPanel.Items_Boxes
{
    class DrawPawnInfoIcons
    {
        public static void DrawWeaponListIcons()
        {
            foreach (var weaponIcon in EntityLists.WeaponIconList)
                Engine.Engine.SpriteBatch.Draw(weaponIcon.Weapon.Icon, weaponIcon.Brec, Color.White);
        }
    }
}
