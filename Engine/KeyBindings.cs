using System;
using Microsoft.Xna.Framework.Input;
using Zeds.Graphics;

namespace Zeds.Engine
{
    class KeyBindings
    {
        public static int PreviousScrollValue;
        public static MouseState CurrentMouseState;

        public static void CheckKeyBindings()
        {
            // Move Camera
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Engine.CameraPosition.X >= 0)
                Engine.CameraPosition.X -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Engine.CameraPosition.X <= Engine.MapSizeX)
                Engine.CameraPosition.X += 10;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Engine.CameraPosition.Y >= 0)
                Engine.CameraPosition.Y -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.S) && Engine.CameraPosition.Y <= Engine.MapSizeY)
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
        }

        public static void CheckMouseBindings()
        {
            Console.WriteLine("Previous scroll value = " + PreviousScrollValue);
            if (CurrentMouseState.ScrollWheelValue > PreviousScrollValue && Engine.Camera.Zoom <= 1.8f)
            {
                Engine.Camera.Zoom += 0.1f;
                PreviousScrollValue = CurrentMouseState.ScrollWheelValue;
            }

            if (CurrentMouseState.ScrollWheelValue > PreviousScrollValue && Engine.Camera.Zoom >= 0.2f)
            {
                Engine.Camera.Zoom -= 0.1f;
                PreviousScrollValue = CurrentMouseState.ScrollWheelValue;
            }
            Console.WriteLine("New scroll value = " + CurrentMouseState.ScrollWheelValue);
        }
    }
}
