using System.Security.Permissions;
using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class PopulateMenus
    {
        private static Vector2 position; 

        public static void PopulateMenuIconList()
        {
            position.X = Engine.Engine.MouseCoordinates.X;
            position.Y = Engine.Engine.MouseCoordinates.Y;


            //==== Main Menu ====
            //Main build menu icon
            int bmX = 10;
            int bmY = 35;
            var bmP = new Vector2(position.X + bmX, position.Y + bmY);
            var bmRec = new Rectangle((int)bmP.X + bmX, (int)bmP.Y + bmY, 30, 30);
            MainMenu.CreateMainMenuIcon(Textures.BuildMenuIcon, bmP, bmX, bmY, bmRec, "Basic Structures");

            // Demolish Icon
            int demX = 50;
            int demY = 35;
            var demP = new Vector2(position.X + demX, position.Y + demY);
            var demRec = new Rectangle((int)demP.X, (int)demP.Y, 30, 30);
            MainMenu.CreateMainMenuIcon(Textures.DemolishIcon, demP, demX,demY, demRec, "Demolish");


            //==== Build Menu ====
            //Small Tent
            int stX = 10;
            int stY = 70;
            var stP = new Vector2(position.X - stX, position.Y + stY);
            var stRec = new Rectangle((int)position.X - stX, (int)position.Y, 30, 30); 
            BasicBuildMenu.CreateBuildMenuIcon(Textures.SmallTentBuildIcon, stP, stRec, "Small Tent");

            
            //Large Tent
            int ltX = 10;
            int ltY = 110;
            var ltP = new Vector2(position.X - ltX, position.Y + stY);
            var ltRec = new Rectangle((int)ltP.X, (int)ltP.Y, 30, 30);
            BasicBuildMenu.CreateBuildMenuIcon(Textures.LargeTentBuildIcon, ltP, ltRec, "Large Tent");
        }
    }
}