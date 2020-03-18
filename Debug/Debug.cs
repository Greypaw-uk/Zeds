using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Zeds.Engine;
using Zeds.Pathfinding;
using Zeds.UI;

namespace Zeds.Debug
{
    public static class Debug
    {
        public static bool IsDebugEnabled;
        private static readonly List<Rectangle> recList = new List<Rectangle>();

        public static void DrawDebugInfo()
        {
            DrawCollisionBoxes();
            DrawPathFindingNodes();
            DrawPathFindingPath();

            //DamageEntities.DamageHumanPawns();
            //DamageEntities.DamageZedPawns();
            //DamageEntities.DamageBuildings();
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
                    Engine.Engine.SpriteBatch.Draw(Textures.DebugSquareLarge, new Rectangle(rec.X, rec.Y, rec.Width, rec.Height), Color.White);
                else
                    Engine.Engine.SpriteBatch.Draw(Textures.DebugSquareSmall, new Rectangle(rec.X, rec.Y, rec.Width, rec.Height), Color.White);
        }

        private static void DrawPathFindingNodes()
        {
            for (int x = 0; x < Grid.NodeList.Count; x++)
            {
                for (int y = 0; y < Grid.NodeList[x].Count; y++)
                {
                    Engine.Engine.SpriteBatch.Draw(Textures.OnePixel,
                        new Vector2(Grid.NodeList[x][y].Point.X, Grid.NodeList[x][y].Point.Y), Color.White);
                }
            }
        }

        private static void DrawPathFindingPath()
        {
            foreach (var human in EntityLists.HumanList)
            {
                if (human.Path != null)
                {
                    for (int i = 0; i < human.Path.Count -1; i++)
                    {
                        var width = Textures.OnePixel.Width;

                        Vector2 begin = new Vector2
                        {
                            X = human.Path[i].X,
                            Y = human.Path[i].Y
                        };

                        Vector2 end = new Vector2
                        {
                            X = human.Path[i + 1].X,
                            Y = human.Path[i + 1].Y
                        };

                        Rectangle r = new Rectangle((int) begin.X, (int) begin.Y, (int) (end - begin).Length() + width,
                            width);
                        Vector2 v = Vector2.Normalize(begin - end);

                        float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
                        if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;

                        Engine.Engine.SpriteBatch.Draw(Textures.OnePixel, r, null, Color.White, angle, Vector2.Zero, SpriteEffects.None, 0);
                    }
                }
            }

            foreach (var zed in EntityLists.ZedList)
            {
                if (zed.Path != null)
                {
                    for (int i = 0; i < zed.Path.Count - 1; i++)
                    {
                        var width = Textures.OnePixel.Width;

                        Vector2 begin = new Vector2
                        {
                            X = zed.Path[i].X,
                            Y = zed.Path[i].Y
                        };

                        Vector2 end = new Vector2
                        {
                            X = zed.Path[i + 1].X,
                            Y = zed.Path[i + 1].Y
                        };

                        Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width,
                            width);
                        Vector2 v = Vector2.Normalize(begin - end);

                        float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
                        if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;

                        Engine.Engine.SpriteBatch.Draw(Textures.OnePixel, r, null, Color.White, angle, Vector2.Zero, SpriteEffects.None, 0);
                    }
                }
            }
        }
    }
}