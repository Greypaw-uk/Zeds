using System.Linq;
using Microsoft.Xna.Framework;
using Zeds.Engine;
using Zeds.Graphics;

namespace Zeds.UI.PawnInfoPanel
{
    class DrawPawnsInfoPanel
    {
        public static void DrawPawnInfoPanel()
        {
            Engine.Engine.SpriteBatch.Draw(Textures.PawnInfoPane, PawnInfo.PawnInfoRec, Color.White);
            Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, PawnInfo.DisplayInfo, PawnInfo.InfoLocation, Color.White);

            Engine.Engine.SpriteBatch.Draw(Textures.InfoPawnOutline, PawnInfo.PawnOutlineBox, Color.White);

            Engine.Engine.SpriteBatch.Draw(Textures.InfoHead, PawnInfo.PawnHeadBox, Color.White);
            Engine.Engine.SpriteBatch.Draw(Textures.InfoChest, PawnInfo.PawnChestBox, Color.White);
            

            foreach (var person in EntityLists.HumanList.Where(person => person.IsSelected))
                if (!person.IsArmed)
                    Engine.Engine.SpriteBatch.Draw(Textures.InfoHand, PawnInfo.PawnHandBox, Color.White);
                else
                    Engine.Engine.SpriteBatch.Draw(person.EquippedWeapon.Icon, PawnInfo.PawnHandBox, Color.White);
            

            Engine.Engine.SpriteBatch.Draw(Textures.InfoMisc, PawnInfo.PawnMiscBox, Color.White);


            //Expand Icons
            if (EntityLists.AvailableWeaponList.Count != 0)
                Engine.Engine.SpriteBatch.Draw(Textures.ExtendArrow, PawnInfo.ExpandHandBox, Color.White);
            
            if (EntityLists.AvailableHeadwearList.Count != 0)
                Engine.Engine.SpriteBatch.Draw(Textures.ExtendArrow, PawnInfo.ExpandHeadBox, Color.White);
            
            if (EntityLists.AvailableChestwearList.Count != 0)
                Engine.Engine.SpriteBatch.Draw(Textures.ExtendArrow, PawnInfo.ExpandsChestBox, Color.White);

            if (EntityLists.AvailableMiscItemList.Count != 0)
                Engine.Engine.SpriteBatch.Draw(Textures.ExtendArrow, PawnInfo.ExpandMiscBox, Color.White);
        }
    }
}