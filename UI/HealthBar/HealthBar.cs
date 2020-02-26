using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.UI.HealthBar
{
    public class HealthBar
    {
        public static void DrawHealthBar()
        {
            foreach (var person in EntityLists.HumanList)
            {
                if (person.CurrentHealth < person.MaxHealth)
                {
                    Vector2 barLocation = new Vector2
                    {
                        X = person.Position.X - Textures.HealthBarOuter.Width / 2,
                        Y = person.Position.Y - Textures.HumanTexture.Height
                    };

                    float width = (Textures.HealthBarInner.Width * (person.CurrentHealth / person.MaxHealth));

                    Rectangle r = new Rectangle
                    {
                        X = (int) barLocation.X + 1,
                        Y = (int) barLocation.Y + 1,
                        Width = (int) width,
                        Height = Textures.HealthBarInner.Height
                    };

                    Engine.Engine.SpriteBatch.Draw(Textures.HealthBarOuter, barLocation, Color.White);

                    Engine.Engine.SpriteBatch.Draw(Textures.HealthBarInner, new Rectangle(r.X, r.Y, r.Width, r.Height),
                        Color.White);
                }
            }

            foreach (var zed in EntityLists.ZedList)
            {
                if (zed.CurrentHealth < zed.MaxHealth)
                {
                    Vector2 barLocation = new Vector2
                    {
                        X = zed.Position.X - Textures.HealthBarOuter.Width / 2,
                        Y = zed.Position.Y - Textures.HumanTexture.Height
                    };

                    float width = (Textures.HealthBarInner.Width * (zed.CurrentHealth / zed.MaxHealth));

                    Rectangle r = new Rectangle
                    {
                        X = (int)barLocation.X + 1,
                        Y = (int)barLocation.Y + 1,
                        Width = (int)width,
                        Height = Textures.HealthBarInner.Height
                    };

                    Engine.Engine.SpriteBatch.Draw(Textures.HealthBarOuter, barLocation, Color.White);

                    Engine.Engine.SpriteBatch.Draw(Textures.HealthBarInner, new Rectangle(r.X, r.Y, r.Width, r.Height),
                        Color.White);
                }
            }

            foreach (var building in EntityLists.BuildingList)
            { 
                if ((building.CurrentHealth < building.MaxHealth))
                {
                    Rectangle outerBar = new Rectangle
                    {
                        X = (int)building.Position.X,
                        Y = (int)building.Position.Y - 10,
                        Width = building.Texture.Width,
                        Height = Textures.HealthBarOuter.Height

                    };

                    Rectangle innerBar = new Rectangle
                    {
                        X = outerBar.X + 1,
                        Y = outerBar.Y + 1,
                        Width = (outerBar.Width -2) * (int)(building.CurrentHealth / building.MaxHealth),
                        Height = Textures.HealthBarInner.Height
                    };

                    Engine.Engine.SpriteBatch.Draw(Textures.HealthBarOuter,
                        new Rectangle(outerBar.X, outerBar.Y, outerBar.Width, outerBar.Height), Color.White);

                    Engine.Engine.SpriteBatch.Draw(Textures.HealthBarInner,
                        new Rectangle(innerBar.X, innerBar.Y, innerBar.Width, innerBar.Height),
                        Color.White);
                }
            }
        }
    }
}