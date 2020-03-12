using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zeds.Engine;

namespace Zeds.Graphics.Background
{
    public class Bush
    {
        public Vector2 Location;
        public Texture2D Texture;
        public Rectangle BRec;
    }

    public static class Bushes
    {
        public static void DrawBushes()
        {
            foreach (var bush in EntityLists.BushList)
            {
                Engine.Engine.SpriteBatch.Draw(bush.Texture, bush.Location, Color.White);
            }
        }

        public static void CreateBushes()
        {
            Texture2D texture;
            var ran = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 40; i++)
            {
                // ToDo 3 Change to use mapsize height/width
                int x = ran.Next(150, Engine.Engine.ScreenWidth);
                int y = ran.Next(150, Engine.Engine.ScreenHeight);

                Vector2 location = new Vector2(x, y);

                //Move bush to reduce overlapping textures
                if (EntityLists.BushList.Count > 0)
                    foreach (var bush in EntityLists.BushList)
                        if (location == bush.Location)
                        {
                            location.X += ran.Next(0, 200);
                            location.Y += ran.Next(0, 200);
                        }

                int probability = ran.Next(1, 4);

                if (probability == 1)
                    texture = Textures.Bush1Texture;
                else if (probability == 2)
                    texture = Textures.Bush2Texture;
                else if (probability == 3)
                    texture = Textures.Bush3Texture;
                else
                    texture = Textures.Bush4Texture;

                AddBushToList(location, texture);
            }
        }

        private static void AddBushToList(Vector2 location, Texture2D texture)
        {
            var bush = new Bush
            {
                Location = location,
                Texture = texture,
            };

            bush.BRec.X = (int)bush.Location.X;
            bush.BRec.Y = (int)bush.Location.Y;

            EntityLists.BushList.Add(bush);
        }
    }
}
