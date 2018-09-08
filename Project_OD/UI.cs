using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Project_OD
{

    public class UI
    {
        private Texture2D healthBar;
        private Vector2 healthBarPosition;
        private Rectangle healthBarRect;

        UI()
        {
            healthBarPosition = new Vector2(50, 30);
            healthBarRect = new Rectangle(0, 0, healthBar.Width, healthBar.Height);
        }

        public void Update()
        {
            if(InputManager.IsKeyPressed(Keys.E))
            {
                healthBarRect.Width -= 1;
            }
        }

        public void LoadTexture()
        {
            healthBar = OD.content.Load<Texture2D>("healthBar");
        }

        public void Draw(SpriteBatch spritebatch)
        {
            SpriteBatch.Draw(healthBar, healthBarPosition, healthBarRect, Color.White);
        }




    }


}
