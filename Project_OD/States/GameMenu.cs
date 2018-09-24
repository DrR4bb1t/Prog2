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
    public class GameMenu : Game
    {
        Buttons startButton;
        Buttons exitButton;
        
        public GameMenu()
        {
           startButton = new Buttons(new Vector2(10, 10), "Textures/Button/start_EN");
           exitButton = new Buttons(new Vector2(20, 20), "Textures/Button/quit_EN");
        }

        public void Update()
        {
            //creates rects for the buttons (modifiable aswell as width and height)

            if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(startButton.doIntersect(startButton)))
            {
                //test
                OD.setState(gameStates.Exit);
            }

            else if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(exitButtonRect))
            {

            OD.setState(gameStates.InGame);
            }

        }


        public void Draw(SpriteBatch spritebatch)
        {
            button.Draw(spritebatch);
        }

    }
}

    