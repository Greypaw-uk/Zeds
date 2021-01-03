using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;
using Zeds.UI;

namespace Zeds.Resources
{
    public class Tree
    {
        public Vector2 Location;
        public Texture2D Texture;
        public Rectangle BRec;
    }

    public class TreeFoliage
    {
        public Vector2 Location;
        public Texture2D Texture;
        public Rectangle BRec;
        public float Transparency;
    }

    class Trees
    {
        public static void DrawTrees()
        {
            foreach (var tree in EntityLists.TreeList)
            {
                Engine.Engine.SpriteBatch.Draw(tree.Texture, tree.Location, Color.White);
            }
        }

        public static void DrawTreeFoliage()
        {
            foreach (var foliage in EntityLists.TreeFoliageList)
            {
                Engine.Engine.SpriteBatch.Draw(foliage.Texture, foliage.Location, new Color(Color.White, foliage.Transparency));
            }
        }

        public static void ChangeTreeFoliageTransparency()
        {
            foreach (var foliage in EntityLists.TreeFoliageList)
            {
                foliage.Transparency = 1f;

                if (foliage.BRec.Intersects(Cursor.CursorRectangle))
                {
                    foliage.Transparency = 0.25f;
                }

                foreach (var human in EntityLists.HumanList)
                {
                    if (foliage.BRec.Contains(human.BRec))
                    {
                        foliage.Transparency = 0.25f;
                    }
                }
            }
        }

        public static void CreateTrees()
        {
            Texture2D texture;
            var ran = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 40; i++)
            {
                // ToDo 3 Change to use mapsize height/width
                int x = ran.Next(150, Engine.Engine.ScreenWidth);
                int y = ran.Next(150, Engine.Engine.ScreenHeight);

                Vector2 location = new Vector2(x, y);

                //Move tree to reduce overlapping textures
                if (EntityLists.TreeList.Count > 0)
                    foreach (var tree in EntityLists.TreeList)
                        if (location == tree.Location)
                        {
                            location.X += ran.Next(50, 200);
                            location.Y += ran.Next(50, 200);
                        }

                int probability = ran.Next(1, 4);

                if (probability == 1)
                    texture = Textures.Tree1Texture;
                else if (probability == 2)
                    texture = Textures.Tree2Texture;
                else if (probability == 3)
                    texture = Textures.Tree3Texture;
                else
                    texture = Textures.Tree4Texture;

                var newTree = new Tree
                {
                    Location = location,
                    Texture = texture,
                };

                newTree.BRec.X = (int)newTree.Location.X;
                newTree.BRec.Y = (int)newTree.Location.Y;

                newTree.BRec.Height = texture.Height;
                newTree.BRec.Width = texture.Width;

                EntityLists.TreeList.Add(newTree);
            }
        }

        public static void CreateTreeFoliage()
        {
            foreach (var tree in EntityLists.TreeList)
            {
                Vector2 foliageLocation = new Vector2(tree.Location.X - 40, tree.Location.Y - 50);

                var treeFoliage = new TreeFoliage()
                {
                    Location = foliageLocation,
                    Texture = Textures.TreeFoliage1
                };

                treeFoliage.BRec.X = (int)treeFoliage.Location.X;
                treeFoliage.BRec.Y = (int)treeFoliage.Location.Y;

                treeFoliage.BRec.Height = treeFoliage.Texture.Height;
                treeFoliage.BRec.Width = treeFoliage.Texture.Width;

                treeFoliage.Transparency = 25f;

                EntityLists.TreeFoliageList.Add(treeFoliage);
            }
        }
    }
}
