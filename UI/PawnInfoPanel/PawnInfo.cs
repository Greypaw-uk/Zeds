using Microsoft.Xna.Framework;
using System.Text;
using Zeds.Engine;
using Zeds.Pawns.HumanLogic;

namespace Zeds.UI.PawnInfoPanel
{
    class PawnInfo
    {
        public static bool IsPawnInfoVisible;

        public static Rectangle PawnInfoRec;

        public static Rectangle PawnOutlineBox;
        public static Rectangle PawnHeadBox;
        public static Rectangle PawnChestBox;
        public static Rectangle PawnHandBox;
        public static Rectangle PawnMiscBox;

        public static Rectangle ExpandHandBox;
        public static Rectangle ExpandHeadBox;
        public static Rectangle ExpandsChestBox;
        public static Rectangle ExpandMiscBox;

        public static Vector2 InfoLocation;

        public static string DisplayInfo;

        public static void DisplayPawnInfo(Human pawn)
        {
            PawnInfoRec = new Rectangle
            {
                X = 0,
                Y = 0,
                Width = 250,
                Height = 300
            };

            InfoLocation = new Vector2
            {
                X = PawnInfoRec.X + 10,
                Y = PawnInfoRec.Y + 10
            };

            StringBuilder info = new StringBuilder();
            info.Append("Name: " + pawn.Name + "\n");
            info.Append("A " + pawn.Age + " year old " + pawn.Occupation + "\n\n");
            info.Append("Health: " + pawn.CurrentHealth + "/" + pawn.MaxHealth + "\n");
            info.Append("Morale: " + "\n");
            info.Append("Current task: " + "\n");

            DisplayInfo = info.ToString();

            PawnOutlineBox = new Rectangle
            {
                X = PawnInfoRec.X +10,
                Y = PawnInfoRec.Y + 130,
                Width = Textures.InfoPawnOutline.Width,
                Height = Textures.InfoPawnOutline.Height
            };

            // Row 1
            PawnHeadBox = new Rectangle
            {
                X = PawnOutlineBox.X + PawnOutlineBox.Width + 20,
                Y = PawnOutlineBox.Y,
                Width = 40,
                Height = 40
            };

            ExpandHeadBox = new Rectangle
            {
                X = PawnHeadBox.X + PawnHeadBox.Width - 5,
                Y = PawnHeadBox.Y + PawnHeadBox.Height - 5,
                Width = 10,
                Height = 10
            };

            PawnChestBox = new Rectangle
            {
                X = PawnHeadBox.X + PawnHeadBox.Width + 10,
                Y = PawnOutlineBox.Y,
                Width = 40,
                Height = 40
            };

            ExpandsChestBox = new Rectangle
            {
                X = PawnChestBox.X + PawnChestBox.Width - 5,
                Y = PawnChestBox.Y + PawnChestBox.Height - 5,
                Width = 10,
                Height = 10
            };

            //Row 2
            PawnHandBox = new Rectangle
            {
                X = PawnOutlineBox.X + PawnOutlineBox.Width + 20,
                Y = PawnHeadBox.Y + PawnHeadBox.Height +20,
                Width = 40,
                Height = 40
            };

            ExpandHandBox = new Rectangle
            {
                X = PawnHandBox.X + PawnHandBox.Width - 5,
                Y = PawnHandBox.Y + PawnHandBox.Height - 5,
                Width = 10,
                Height = 10
            };

            PawnMiscBox = new Rectangle
            {
                X = PawnHandBox.X + PawnHandBox.Width + 10,
                Y = PawnChestBox.Y + PawnChestBox.Height +20,
                Width = 40,
                Height = 40
            };

            ExpandMiscBox = new Rectangle
            {
                X = PawnMiscBox.X + PawnMiscBox.Width - 5,
                Y = PawnMiscBox.Y + PawnMiscBox.Height -5,
                Width = 10,
                Height = 10
            };
        }
    }
}