using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Zeds.UI;

namespace Zeds.Engine.Debug
{
    public static class Debug
    {
        public static bool IsDebugEnabled;
        private static List<Rectangle> recList = new List<Rectangle>();

        public static void DrawDebugInfo()
        {
            DrawCollisionBoxes();
            DamageEntities.DamageHumanPawns();
            DamageEntities.DamageZedPawns();
            DamageEntities.DamageBuildings();
        }

        private static void DrawCollisionBoxes()
        {
            recList.Clear();

            recList.Add(new Rectangle(Cursor.CursorRectangle.X, Cursor.CursorRectangle.Y, Cursor.CursorRectangle.Width, Cursor.CursorRectangle.Height));

            foreach (var zed in EntityLists.ZedList)
                recList.Add(new Rectangle(zed.BRec.X, zed.BRec.Y, zed.Texture.Width, zed.Texture.Height));

            foreach (var building in EntityLists.BuildingList)
                recList.Add(new Rectangle(building.BRec.X, building.BRec.Y, building.Texture.Width, building.Texture.Height));

            foreach (var human in EntityLists.HumanList)
                recList.Add(new Rectangle(human.BRec.X, human.BRec.Y, human.Texture.Width, human.Texture.Height));

            foreach (var rec in recList)
                if (rec.Height >= 100 || rec.Width >= 100 )
                    Engine.SpriteBatch.Draw(Textures.DebugSquareLarge, new Rectangle(rec.X, rec.Y, rec.Width, rec.Height), Color.White);
                else
                    Engine.SpriteBatch.Draw(Textures.DebugSquareSmall, new Rectangle(rec.X, rec.Y, rec.Width, rec.Height), Color.White);
        }
    }
}