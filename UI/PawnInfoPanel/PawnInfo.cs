using Microsoft.Xna.Framework;
using System.Text;
using Zeds.Engine;
using Zeds.Graphics;
using Zeds.Pawns.HumanLogic;

namespace Zeds.UI.PawnInfoPanel
{
    class PawnInfo
    {
        public static bool IsPawnInfoVisible;

        private static Rectangle pawnInfo;

        private static Rectangle pawnOutlineBox;
        private static Rectangle pawnHeadBox;
        private static Rectangle pawnChestBox;
        private static Rectangle pawnHandBox;
        private static Rectangle pawnMiscBox;

        private static Vector2 infoLocation;

        private static string displayInfo;

        public static void DisplayPawnInfo(Human pawn)
        {
            pawnInfo = new Rectangle
            {
                X = 0,
                Y = 0,
                Width = 250,
                Height = 300
            };

            infoLocation = new Vector2
            {
                X = pawnInfo.X + 10,
                Y = pawnInfo.Y + 10
            };

            StringBuilder info = new StringBuilder();
            info.Append("Name: " + pawn.Name + "\n");
            info.Append("A " + pawn.Age + " year old " + pawn.Occupation + "\n\n");
            info.Append("Health: " + pawn.CurrentHealth + "/" + pawn.MaxHealth + "\n");
            info.Append("Morale: " + "\n");
            info.Append("Current task: " + "\n");

            displayInfo = info.ToString();

            pawnOutlineBox = new Rectangle
            {
                X = pawnInfo.X +10,
                Y = pawnInfo.Y + 130,
                Width = Textures.InfoPawnOutline.Width,
                Height = Textures.InfoPawnOutline.Height
            };

            // Row 1
            pawnHeadBox = new Rectangle
            {
                X = pawnOutlineBox.X + pawnOutlineBox.Width + 20,
                Y = pawnOutlineBox.Y,
                Width = 40,
                Height = 40
            };

            pawnChestBox = new Rectangle
            {
                X = pawnHeadBox.X + pawnHeadBox.Width + 10,
                Y = pawnOutlineBox.Y,
                Width = 40,
                Height = 40
            };

            //Row 2
            pawnHandBox = new Rectangle
            {
                X = pawnOutlineBox.X + pawnOutlineBox.Width + 20,
                Y = pawnHeadBox.Y + pawnHeadBox.Height +20,
                Width = 40,
                Height = 40
            };

            pawnMiscBox = new Rectangle
            {
                X = pawnHandBox.X + pawnHandBox.Width + 10,
                Y = pawnChestBox.Y + pawnChestBox.Height +20,
                Width = 40,
                Height = 40
            };
        }

        public static void DrawPawnInfoPanel()
        {
            Engine.Engine.SpriteBatch.Draw(Textures.PawnInfoPane, pawnInfo, Color.White);
            Engine.Engine.SpriteBatch.DrawString(Fonts.DebugFont, displayInfo, infoLocation, Color.White);

            Engine.Engine.SpriteBatch.Draw(Textures.InfoPawnOutline, pawnOutlineBox, Color.White);

            Engine.Engine.SpriteBatch.Draw(Textures.InfoHead, pawnHeadBox, Color.White);
            Engine.Engine.SpriteBatch.Draw(Textures.InfoChest, pawnChestBox, Color.White);
            Engine.Engine.SpriteBatch.Draw(Textures.InfoHand, pawnHandBox, Color.White);
            Engine.Engine.SpriteBatch.Draw(Textures.InfoMisc, pawnMiscBox, Color.White);
        }
    }
}