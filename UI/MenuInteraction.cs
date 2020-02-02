using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;

namespace Zeds.UI
{
    public static class MenuInteraction
    {
        public static bool IsBuildMenuActive;

        public static bool CheckCursorMenuInteraction(Rectangle cursor)
        {
            foreach (var item in EntityLists.MainIconList)
            {
                if (cursor.Intersects(item.BRec))
                {
                    //ToDo 1 Keep menu open whilst selecting a build open
                    if (item.Texture == Textures.BuildMenuIconTexture &&
                        Mouse.GetState().LeftButton == ButtonState.Pressed || IsBuildMenuActive)
                    { IsBuildMenuActive = true;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}