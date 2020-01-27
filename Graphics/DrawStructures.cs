using Microsoft.Xna.Framework;
using Zeds.Engine;

namespace Zeds.Graphics
{
    public static class DrawStructures
    {
        public static void DrawBuildings()
        {
            foreach (var building in EntityLists.BuildingList)
                Engine.Engine.SpriteBatch.Draw(building.Texture, building.Position, Color.AliceBlue);
        }
    }
}