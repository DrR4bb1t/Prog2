using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Project_OD
{
    public class GameMenu
    {
        /// <summary>
        /// this class will handle the main game menu
        /// </summary>


        //declares a texture for buttons (modifiable)
        private Texture2D startButton;
        /*private Texture2D optionButton;
        private Texture2D exitButton; */
        //declares a position for buttons (modifiable)
        private Vector2 startButtonPosition;
        private Vector2 optionButtonPosition;
        private Vector2 exitButtonPosition;

        //declares a rectangle for the buttons(modifiable)
        private Rectangle startButtonRect;
        /* private Rectangle optionButtonRect;
         private Rectangle exitButtonRect; */



        public GameMenu()
        {
            //defines the position for buttons (modifiable)
            startButtonPosition = new Vector2((OD.ScreenWidth / 2) - 500, 200);
            optionButtonPosition = new Vector2((OD.ScreenWidth / 2) - 50, 220);
            exitButtonPosition = new Vector2((OD.ScreenWidth / 2) - 50, 250);

            startButtonRect = new Rectangle((int)startButtonPosition.X,
            (int)startButtonPosition.Y, 250, 64);

            //optionButtonRect = new Rectangle((int)optionButtonPosition.X,
            //(int)optionButtonPosition.Y, 2336, 591);

            //exitButtonRect = new Rectangle((int)exitButtonPosition.X,
            //(int)exitButtonPosition.Y, 2336, 591);
        }

        public void Update()
        {
            //creates rects for the buttons (modifiable aswell as width and height)

            if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(startButtonRect))
            {
                //test
                OD.setState(gameStates.Exit);
            }
            /*else if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(optionButtonRect))
            {

            OD.setState(gameStates.InGame);
            }
            else if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(exitButtonRect))
            {

            OD.setState(gameStates.InGame);
            } */

        }

        public void LoadButtonTextures()
        {
            startButton = OD.content.Load<Texture2D>("Textures/Button/start_EN");
            /*optionButton = OD.content.Load<Texture2D>("Buttons/option");
            exitButton = OD.content.Load<Texture2D>("Buttons/option"); */

        }

        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(startButton, startButtonPosition, null, Color.White, 0f,
            Vector2.Zero, 1.0f, SpriteEffects.None, 0f);

            /*spriteBatch.Draw(optionButton, optionButtonPosition, null, Color.White, 0f,
            Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
            spriteBatch.Draw(exitButton, exitButtonPosition, null, Color.White, 0f,
            Vector2.Zero, 1.0f, SpriteEffects.None, 0f); */

        }

    }
}
