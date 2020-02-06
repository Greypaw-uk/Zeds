﻿using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zeds.Engine;
using Zeds.UI;

namespace Zeds.BuildingLogic
{
    public enum BuildingSelected
    {
        None,
        SmallTent,
        LargeTent
    }

    static class BuildingPlacementHandler
    {
        public static bool IsPlacingBuilding;
        private static Vector2 adjustedCoordinates;
        public static BuildingSelected SelectedStructure;


        public static Texture2D SetBuildingTexture()
        {
            switch (SelectedStructure)
            {
                case BuildingSelected.None:
                    return null;

                case BuildingSelected.SmallTent:
                    return Textures.SmallTentTexture;

                //case BuildingSelected.LargeTent:
                //return Textures.LargeTentTexture;
            }

            return null;
        }

        public static void PlaceAStructure(Texture2D texture)
        {
            //ToDo 3 Test necessity of adjustedCoordinates
            adjustedCoordinates = new Vector2(Engine.Engine.MouseCoordinates.X, Engine.Engine.MouseCoordinates.Y);

            Engine.Engine.Blueprint = new Rectangle((int)adjustedCoordinates.X - (texture.Width / 2),
                (int)adjustedCoordinates.Y - (texture.Width / 2), texture.Width, texture.Height);


            if (Mouse.GetState().LeftButton == ButtonState.Pressed && CheckIfGroundClear(Engine.Engine.Blueprint))
            {
                if (SelectedStructure == BuildingSelected.SmallTent)
                    Tent.CreateSmallTent(adjustedCoordinates, Engine.Engine.Blueprint);

                IsPlacingBuilding = false;
                MenuInteraction.IsBuildMenuOpen = false;
                SelectedStructure = BuildingSelected.None;
            }
        }

        public static bool CheckIfGroundClear(Rectangle blueprint)
        {
            foreach (var building in EntityLists.BuildingList)
            {
                if (blueprint.Intersects(building.BRec))
                    return false;
            }

            return true;
        }
    }
}