using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Zeds.Engine
{
    public static class Debug
    {
        public static bool IsDebugEnabled;
        private static List<Rectangle> recList = new List<Rectangle>();

        public static void DrawDebugInfo()
        {
            DrawCollisionBoxes();
        }

        private static void DrawCollisionBoxes()
        {
            recList.Clear();

            foreach (var zed in EntityLists.ZedList)
                recList.Add(new Rectangle(zed.BRec.X, zed.BRec.Y, zed.Texture.Width, zed.Texture.Height));

            foreach (var building in EntityLists.BuildingList)
                recList.Add(new Rectangle(building.BRec.X, building.BRec.Y, building.Texture.Width, building.Texture.Height));

            foreach (var human in EntityLists.HumanList)
                recList.Add(new Rectangle(human.BRec.X, human.BRec.Y, human.Texture.Width, human.Texture.Height));

            foreach (var rec in recList)
                Engine.SpriteBatch.Draw(Textures.DebugSquare, new Rectangle(rec.X, rec.Y, rec.Width, rec.Height), Color.White);
        }
    }
}