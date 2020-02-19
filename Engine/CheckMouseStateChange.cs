using Microsoft.Xna.Framework.Input;

namespace Zeds.Engine
{
    class CheckMouseStateChange
    {
        public static MouseState mouseState;

        public static bool IsMouseClicked()
        {
            MouseState mouseState = Mouse.GetState();

            if (CheckMouseStateChange.mouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static void UpdateMouseState()
        {
            mouseState = Mouse.GetState();
        }
    }
}