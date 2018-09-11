using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    class TextBox
    {
        static public void DrawString(SpriteBatch spritebatch, SpriteFont font, string text, Rectangle boundaries)
        {
            Vector2 size = font.MeasureString(text);

            float xScale = (boundaries.Width / size.X);
            float yScale = (boundaries.Height / size.Y);

            // take the smaller value to fit inside the rectangle
            float scale = Math.Min(xScale, yScale);

            //fct to center the string in the boundaries rectangle
            int strWidth = (int)Math.Round(size.X * scale);
            int strHeight = (int)Math.Round(size.Y * scale);
            Vector2 position = new Vector2();
            position.X = (((boundaries.Width - strWidth) / 2) + boundaries.X);
            position.Y = (((boundaries.Height - strHeight) / 2) + boundaries.Y);

            spritebatch.DrawString(font, text, position, Color.White);

        }
    }
}