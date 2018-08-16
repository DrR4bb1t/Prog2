using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    class SpriteAnimation : SpriteManager
    {
        private float timeElapsed;
        private float timeToUpdate = 0.5f;
        public bool isLooping = false;
        public int FPS { set => timeToUpdate = (1f / value); }
        public SpriteAnimation(Texture2D texture, int frames, int animations) : base(texture, frames, animations)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (frameIndex < recs.Length - 1)
                {
                    frameIndex++;
                }
                else if (isLooping)
                {
                    frameIndex = 0;
                }
            }
        }
    }
}
