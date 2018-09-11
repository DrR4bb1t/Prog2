using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    public class Splash
    {
        public Splash() { }

        public void Update()
        {
            if (InputManager.IsKeyPressed(Keys.Enter))
            {
                OD.setState(gameStates.GameMenu);
            }
            else
            {
                OD.setState(gameStates.Splash);
            }
        }

        public void Draw()
        {
            //draw texture here
        }

    }
}