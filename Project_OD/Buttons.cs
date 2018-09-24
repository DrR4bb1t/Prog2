using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    public class Buttons
    {
        private Vector2 buttonPosition;
        private Texture2D buttonTexture;
        private Rectangle buttonRectangle;

        public Rectangle ButtonRectangle { get => buttonRectangle; }     

        public Buttons(Vector2 pos, string texture)
        {
            this.buttonPosition = pos;
            this.buttonTexture = OD.content.Load<Texture2D>(texture);
            this.buttonRectangle = new Rectangle((int)this.buttonPosition.X, (int)this.buttonPosition.Y, this.buttonTexture.Width, this.buttonTexture.Height);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.buttonTexture, this.buttonPosition, this.buttonRectangle, Color.White);
        }

    }
}

