using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project_OD
{
    public class InputManager
    {
        /// <summary>
        /// Tutorial Keyboard Manager:
        /// Snippet -
        /// if(InputManager.IsKeyPressed(Keys.Enter) {do Something }
        /// call the Input Managers 'isKeyPressed' Method and pass 'Keys.YourKey'
        /// </summary>
        private static KeyboardState currentKeyboardState;
        private static KeyboardState lastKeyboardState;

        public static KeyboardState CurrentKeyboardState
        {
            get { return currentKeyboardState; }
        }

        public static bool IsKeyPressed(Keys key)
        {

            return currentKeyboardState.IsKeyDown(key);
        }

        public static bool IsKeyTriggered(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key)) &&
                (!lastKeyboardState.IsKeyDown(key));
        }

        private static MouseState currentMouseState;
        private static MouseState lastMouseState;

        public static Rectangle GetMouseBoundaries(bool currentState)
        {
            if (currentState)
                return new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);
            else
                return new Rectangle(lastMouseState.X, lastMouseState.Y, 1, 1);
        } 

        public static bool GetIsMouseButtonUp(MouseButton button, bool currentState)
        {
            if (currentState)
                switch (button)
                {
                    case MouseButton.LeftButton:
                        return currentMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.MiddleButton:
                        return currentMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.RightButton:
                        return currentMouseState.RightButton == ButtonState.Released;
                }
            else
                switch (button)
                {
                    case MouseButton.LeftButton:
                        return lastMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.MiddleButton:
                        return lastMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.RightButton:
                        return lastMouseState.RightButton == ButtonState.Released;
                }

            return false;
        }

        public static bool GetIsMouseButtonDown(MouseButton button, bool currentState)
        {
            return !GetIsMouseButtonUp(button, currentState);
        }

        public enum MouseButton
        {
            LeftButton,
            MiddleButton,
            RightButton
        }

        public static void Update()
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        } 
    }
}
