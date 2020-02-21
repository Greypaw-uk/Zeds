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
                BRec = bRec,
                Name = "Small Tent",
                Description = "A flimsy fabric tent suitable for camping"
            };

            smallTent.BRec.X = (int) smallTent.Position.X;
            smallTent.BRec.Y = (int) smallTent.Position.Y;

            smallTent.BRec.Width = Textures.SmallTentTexture.Width;
            smallTent.BRec.Height = Textures.SmallTentTexture.Height;

            EntityLists.BuildingList.Add(smallTent);
        }

        public static void CreateLargeTent(Vector2 position, Rectangle bRec)
        {
            Tent largeTent = new Tent
            {
                Texture = Textures.LargeTentTexture,
                ID = Guid.NewGuid().ToString(),
                Position = new Vector2(position.X, position.Y),
                BRec = bRec,
                Name = "Large Tent",
                Description = "A large tent, suitable for several people to camp in"
            };

            largeTent.BRec.X = (int)largeTent.Position.X;
            largeTent.BRec.Y = (int) largeTent.Position.Y;

            largeTent.BRec.Width = Textures.LargeTentTexture.Width;
            largeTent.BRec.Height = Textures.LargeTentTexture.Height;

            EntityLists.BuildingList.Add(largeTent);
        }
    }
}