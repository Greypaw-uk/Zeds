using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class PopulateMenus
    {
        //ToDo 1 Alter locations relevant to the BuildMenuPane

        public static void PopulateMenuIconList()
        {
            //==== Main Menu ====
            //Main build menu icon
            var bmLoc = new Vector2(Engine.Engine.ScreenWidth / 2, Engine.Engine.ScreenHeight - 10);
            var bmRec = new Rectangle((int)bmLoc.X, (int)bmLoc.Y, 30, 30);
            MainMenu.CreateMainMenuIcon(Textures.BuildMenuIcon, bmLoc, bmRec, "Basic Structures");

            // Demolish Icon
            var demLoc = new Vector2((Engine.Engine.ScreenWidth / 2) + 50, Engine.Engine.ScreenHeight - 10);
            var demRec = new Rectangle((int)demLoc.X, (int)demLoc.Y, 30, 30);
            MainMenu.CreateMainMenuIcon(Textures.DemolishIcon, demLoc, demRec, "Demolish");


            //==== Build Menu ====
            //ToDo 2 increase size of Brecs to ensure it can be clicked on correctly
            //Small Tent
            var stLoc = new Vector2(Engine.Engine.ScreenWidth / 2, Engine.Engine.ScreenHeight - 50);
            var stRec = new Rectangle((int)stLoc.X, (int)stLoc.Y, 30, 30); 
            BasicBuildMenu.CreateBuildMenuIcon(Textures.SmallTentBuildIcon, stLoc, stRec, "Small Tent");

            //Large Tent
            var ltLoc = new Vector2(Engine.Engine.ScreenWidth / 2, Engine.Engine.ScreenHeight - 100);
            var ltRec = new Rectangle((int)stLoc.X, (int)stLoc.Y, 30, 30);
            BasicBuildMenu.CreateBuildMenuIcon(Textures.LargeTentBuildIcon, ltLoc, ltRec, "Large Tent");
        }
    }
}