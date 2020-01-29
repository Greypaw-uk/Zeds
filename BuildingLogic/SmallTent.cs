using Microsoft.Xna.Framework;
using System;
using Zeds.Engine;

namespace Zeds.BuildingLogic
{
    public class Tent : Building
    {
        public static void CreateSmallTent(Vector2 position, Rectangle bRec)
        {
            Tent smallTent = new Tent
            {
                Texture = Textures.SmallTentTexture,
                ID = Guid.NewGuid().ToString(),
                Position = new Vector2(position.X, position.Y),
                BRec = bRec
            };
            
            EntityLists.BuildingList.Add(smallTent);
        }
    }
}