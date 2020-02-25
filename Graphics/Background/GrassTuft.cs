using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;

namespace Zeds.Graphics.Background
{
    public class GrassTuft
    {
        public Vector2 Location;
        public Texture2D Texture;
    }

    public static class GrassTufts
    {
        public static void DrawGrassTufts()
        {
            foreach (var tuft in EntityLists.GrassList)
            {
                Engine.Engine.SpriteBatch.Draw(tuft.Texture, tuft.Location, Color.White);
            }
        }

        public static void CreateGrassTufts()
        {
            Texture2D texture;
            var ran = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 100; i++)
            {
                int x = ran.Next(50, Engine.Engine.ScreenWidth);
                int y = ran.Next(50, Engine.Engine.ScreenHeight);

                Vector2 location = new Vector2(x, y);

                //ToDo 3 Ensure GrassTufts are more spaced out
                //Move tuft to reduce overlapping textures
                if (EntityLists.GrassList.Count > 0)
                    foreach (var tuft in EntityLists.GrassList)
                        if (location == tuft.Location)
                        {
                            location.X += ran.Next(0, 100);
                            location.Y += ran.Next(0, 100);
                        }


                int probability = ran.Next(0, 99);

                if (probability >= 95)
                    texture = Textures.GrassTuft4Texture;
                else if (probability >= 89 && probability < 95)
                    texture = Textures.GrassTuft3Texture;
                else if (probability >= 45 && probability < 89)
                    texture = Textures.GrassTuft2Texture;
                else
                    texture = Textures.GrassTuftTexture;

                AddTuftsToList(location, texture);
            }
        }

        private static void AddTuftsToList(Vector2 location, Texture2D texture)
        {
            var tuft = new GrassTuft
            {
                Location =  location,
                Texture = texture
            };

            EntityLists.GrassList.Add(tuft);
        }
    }
}
