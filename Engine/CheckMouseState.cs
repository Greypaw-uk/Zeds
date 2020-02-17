using Microsoft.Xna.Framework.Input;

namespace Zeds.Engine
{
    class CheckMouseState
    {
        public static MouseState mState;

        public static bool IsMouseClicked()
        {
            MouseState mouseState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static void UpdateMState()
        {
            mState = Mouse.GetState();
        }
    }
}
