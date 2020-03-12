using Microsoft.Xna.Framework.Input;
using Zeds.BuildingLogic;
using Zeds.Graphics;
using Zeds.UI;
using Zeds.UI.Build_Menu;

namespace Zeds.Engine
{
    class KeyBindings
    {
        public static int PreviousScrollValue;
        private static MouseState currentMouseState = Mouse.GetState();

        public static void CheckForKeyInput()
        {
            // Move Camera
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Engine.CameraPosition.X >= 0)
                Engine.CameraPosition.X -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Engine.CameraPosition.X <= Engine.ScreenWidth)
                Engine.CameraPosition.X += 10;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Engine.CameraPosition.Y >= 0)
                Engine.CameraPosition.Y -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.S) && Engine.CameraPosition.Y <= Engine.ScreenHeight)
                Engine.CameraPosition.Y += 10;

            if (Keyboard.GetState().IsKeyDown(Keys.Add) && Engine.Camera.Zoom <= 1.8f)
                Engine.Camera.Zoom += 0.1f;

            if (Keyboard.GetState().IsKeyDown(Keys.Subtract) && Engine.Camera.Zoom >= 0.2f)
                Engine.Camera.Zoom -= 0.1f;


            //Toggle Resolution Test
            Engine.ResolutionChanged = false;
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                ResolutionHandler.resolution = ResolutionHandler.Resolution.One;
                Engine.ResolutionChanged = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                ResolutionHandler.resolution = ResolutionHandler.Resolution.Two;
                Engine.ResolutionChanged = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                ResolutionHandler.resolution = ResolutionHandler.Resolution.Three;
                Engine.ResolutionChanged = true;
            }


            //Menu Interaction
            if (BuildMenuInteraction.IsBuildMenuOpen && Keyboard.GetState().IsKeyDown(Keys.Escape))
                BuildMenuInteraction.IsBuildMenuOpen = false;


            if (BuildMenuPane.IsBuildMenuWindowVisible && Keyboard.GetState().IsKeyDown(Keys.X))
            {
                BuildMenuPane.IsBuildMenuWindowVisible = false;
                BuildMenuInteraction.IsBuildMenuOpen = false;
            }

            if (!BuildMenuPane.IsBuildMenuWindowVisible && Keyboard.GetState().IsKeyDown(Keys.B))
                BuildMenuPane.IsBuildMenuWindowVisible = true;


            //Enter Modes
            if (BuildingPlacementHandler.IsPlacingBuilding && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                BuildMenuInteraction.IsBuildMenuOpen = false;
            }


            //Cancel Modes
            if (BuildingPlacementHandler.IsPlacingBuilding && Keyboard.GetState().IsKeyDown(Keys.Escape))
                BuildingPlacementHandler.IsPlacingBuilding = false;

            if (Bulldozer.IsBulldozerActive && Keyboard.GetState().IsKeyDown(Keys.Escape))
                Bulldozer.IsBulldozerActive = false;

            //Debug Mode
            if (!Zeds.Debug.Debug.IsDebugEnabled && Keyboard.GetState().IsKeyDown(Keys.F11))
                Zeds.Debug.Debug.IsDebugEnabled = true;
            if (Zeds.Debug.Debug.IsDebugEnabled && Keyboard.GetState().IsKeyDown(Keys.F12))
                Zeds.Debug.Debug.IsDebugEnabled = false;
        }

        public static void CheckForMouseInput()
        {
            if (currentMouseState.ScrollWheelValue > PreviousScrollValue && Engine.Camera.Zoom <= 1.8)
                Engine.Camera.Zoom += 0.1f;

            if (currentMouseState.ScrollWheelValue > PreviousScrollValue && Engine.Camera.Zoom >= 0.2)
                Engine.Camera.Zoom -= 0.1f;

            PreviousScrollValue = currentMouseState.ScrollWheelValue;

            
            if (BuildMenuInteraction.IsBuildMenuOpen)
            {
                bool intersects = false;
                foreach (var icon in EntityLists.BuildIconList)
                {
                    if (Cursor.CursorRectangle.Intersects(icon.BRec))
                        intersects = true;
                }

                foreach (var icon in EntityLists.MainIconList)
                {
                    if (Cursor.CursorRectangle.Intersects(icon.BRec))
                        intersects = true;
                }

                if (!intersects && CheckMouseStateChange.IsMouseClicked())
                    BuildMenuInteraction.IsBuildMenuOpen = false;
            }
        }
    }
}