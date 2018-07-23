using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project_OD
{
    class InputManager
    {
        /// <summary>
        /// this class handles the mouse and keyboard input
        /// </summary>
        
        private static KeyboardState currentKeyboardState;
        private static KeyboardState lastKeyboardState;

        //this function holds the current keyboard state
        public static KeyboardState CurrentKeyboardState
        {
            //this statement gets and returns the current keyboard state
            get { return currentKeyboardState; }
        }

        //this function tells if a key is being pressed or not
        public static bool IsKeyPressed(Keys key)
        {
            //this statement returns which key is being pressed
            return currentKeyboardState.IsKeyDown(key);
        }

        //this function tells if a key is being pressed in the currentState
        public static bool IsKeyTriggered(Keys key)
        {
            //returns which key is currently being pressed
            return (currentKeyboardState.IsKeyDown(key)) &&
                (!lastKeyboardState.IsKeyDown(key));
        }

        private static MouseState currentMouseState;
        private static MouseState lastMouseState;

        //this function  holds the mouse boundaries inside a rectanglle
        public static Rectangle GetMouseBoundaries(bool currentState)
        {
            if (currentState)
                //returns a Rectangle containing the current Mouse Position
                return new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);
            //returns a Rectangle containing the last Mouse Position
            else
                return new Rectangle(lastMouseState.X, lastMouseState.Y, 1, 1);
        } 

        //this function checks if there is no mouse button up
        public static bool GetIsMouseButtonUp(MouseButton button, bool currentState)
        {
            if (currentState)
                switch (button)
                {
                    case MouseButton.LeftButton:
                        //returns that the left mouse button is being released in the current
                        //mouse state
                        return currentMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.MiddleButton:
                        //returns that the middle mouse button is being released in the current
                        //mouse state
                        return currentMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.RightButton:
                        //returns that the right mouse button is being released in the current
                        //mouse state
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

        //this function holds if there is a mouse button down
        public static bool GetIsMouseButtonDown(MouseButton button, bool currentState)
        {
            //returns that the specific mouse button is being pressed
            return !GetIsMouseButtonUp(button, currentState);
        }

        public enum MouseButton
        {
            LeftButton,
            MiddleButton,
            RightButton
        }

        //this function updates the state of mouse and keyboard
        public static void Update()
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        } 
    }
}
