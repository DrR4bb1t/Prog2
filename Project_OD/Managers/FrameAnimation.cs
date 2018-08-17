using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    class FrameAnimation : SpriteManager
    {
        public FrameAnimation(Texture2D texture, Vector2 position, string startAnimation, int frames, int animations) : base(texture, position, startAnimation, frames, animations)
        {

        }
    }
}
