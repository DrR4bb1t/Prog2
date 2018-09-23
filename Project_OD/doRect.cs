using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{

    public static class doRect
    {
        public static Rectangle GetRectangle(Vector2 pos, Texture2D texture)
        {
            Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
            return rect;
        }
    }
}
