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

        public Buttons(Vector2 pos, string texture)
        {
            this.buttonPosition = pos;
            this.buttonTexture = OD.content.Load<Texture2D>(texture);
        }

        public Rectangle doIntersect(Buttons button)
        {
            return doRect.GetRectangle(this.buttonPosition, this.buttonTexture);
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.buttonTexture, doRect.GetRectangle(buttonPosition, this.buttonTexture), Color.White);
        }

    }
}
