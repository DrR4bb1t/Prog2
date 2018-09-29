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
        Buttons startButton;
        Buttons exitButton;

        public GameMenu()
        {
            startButton = new Buttons(new Vector2(665, 400), "Textures/Button/start_EN");
            exitButton = new Buttons(new Vector2(665, 700), "Textures/Button/quit_EN");
        }

        public void Update()
        {
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
            startButton.Draw(spritebatch);
            exitButton.Draw(spritebatch);
        }

    }
}

