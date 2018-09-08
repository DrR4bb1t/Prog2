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
        private Texture2D skillBar;
        private Texture2D inventar;
    
        private Vector2 healthBarPosition;
        private Vector2 skillBarPosition;
        private Vector2 inventarPosition;

        private Rectangle healthBarRect;
        private Rectangle skillBarRect;
        private Rectangle inventarRect;

        UI()
        {
            healthBarPosition = new Vector2(50, 30);
            healthBarRect = new Rectangle(0, 0, healthBar.Width, healthBar.Height);
        }

        public void Update()
        {
            //if(player gets dmg)
            {
                healthBarRect.Width -= 1;
            }
            if(InputManager.IsKeyPressed(Keys.I))
            {
                //load the inventar
            }
        }

        public void LoadTexture()
        {
           // healthBar = OD.content.Load<Texture2D>("healthBar");
           // skillBar = OD.content.Load<Texture2D>("skillBar");
           // inventar = OD.content.Load<Texture2D>("inventar");
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(healthBar, healthBarPosition, healthBarRect, Color.White);
            spritebatch.Draw(skillBar, skillBarPosition, skillBarRect, Color.White);
            spritebatch.Draw(inventar, inventarPosition, inventarRect, Color.White);
        }
    }
}