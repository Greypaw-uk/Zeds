using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Zeds.Engine;
using Zeds.UI;

namespace Zeds.Resources
{
    public enum ResourceTypes
    {
        Wood,
        Metal,
        Food,
        Water
    }
    public class Resource
    {
        public string Name;
        public ResourceTypes Type;
        private bool IsBeingGathered;

        public static void SetResourcesForGathering()
        {
            foreach (var human in EntityLists.HumanList)
            {
                if (human.IsSelected)
                {
                    foreach (var tree in EntityLists.TreeList.Where(person => Cursor.CursorRectangle.Intersects(person.BRec)))
                    {
                        if (Mouse.GetState().RightButton == ButtonState.Pressed && !Bulldozer.IsBulldozerActive)
                        {
                            tree.IsBeingGathered = true;
                        }
                    }
                }
            }
        }

        public static void DrawGatherIcon()
        {
            foreach (var tree in EntityLists.TreeList)
            {
                if (tree.IsBeingGathered)
                {
                    var tex = Textures.GatherIcon;

                    var location = new Vector2(tree.Location.X + (tree.Texture.Width/2) - (tex.Width/2), 
                        tree.Location.Y + (tree.Texture.Height/2) - (tex.Height/2));

                    Engine.Engine.SpriteBatch.Draw(tex, location, Color.Red);
                }
            }
        }
    }
}
