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
        Buttons bg;
        Buttons startButton;
        Buttons exitButton;


        public GameMenu()
        {
            startButton = new Buttons(new Vector2(665, 400), "Textures/Button/start_EN");
            exitButton = new Buttons(new Vector2(665, 700), "Textures/Button/quit_EN");
            bg = new Buttons(new Vector2(1600, 900),  "Textures/bg");
        }

        public void Update()
        {
            //creates rects for the buttons (modifiable aswell as width and height)

            if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(startButton.ButtonRectangle))
            {
                
                OD.setState(gameStates.InGame);
            }

            if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(exitButton.ButtonRectangle))
            {

                OD.setState(gameStates.Exit);
            }

        }

        public void Draw(SpriteBatch spritebatch)
        {
            bg.Draw(spritebatch);
            startButton.Draw(spritebatch);
            exitButton.Draw(spritebatch);
        }

    }
}

