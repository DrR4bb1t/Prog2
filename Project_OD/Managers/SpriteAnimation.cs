using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    public class SpriteAnimation : SpriteManager
    {
        /// <summary>
        /// Elapsed time from the last frame.
        /// </summary>
        private float timeElapsed;
        /// <summary>
        /// Sets the update-time of the animation.
        /// </summary>
        private float timeToUpdate = 0.5f;
        /// <summary>
        /// Let the animation run.
        /// </summary>
        public bool isLooping = false;
        private float Timer = 0;
        private bool timerSet = false;
        /// <summary>
        /// Calculates the frames per secunds of the animation.
        /// </summary>
        public int FPS { set => timeToUpdate = (1f / value); }
        public SpriteAnimation(Texture2D texture, Vector2 position, string startAnimation, int frames, int animations) : base(texture, position, startAnimation, frames, animations)
        {
            
        }

        /// <summary>
        /// Updates the shown sprite.
        /// EXPLANATION:
        /// The function goes through a frame index and shows the current sprite.
        /// The bool variable 'isLooping' sets the frame index to 0, everytime the spritesheet.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="isLooping"></param>
        /// <param name="fps"></param>
        public void Update(GameTime gameTime, bool isLooping, int fps)
        {
            FPS = fps;
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (frameIndex < rectangles.Length - 1)
                {
                    frameIndex++;
                }
                else if (isLooping)
                {
                    frameIndex = 0;
                }
            }
        }
        public void Update(GameTime gameTime, bool isLooping, int fps, int timer)
        {
            FPS = fps;
            if (timerSet)
            {
                if(Timer - (float)gameTime.ElapsedGameTime.TotalSeconds > 0)
                {
                    Timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    timerSet = false;
                }
            }
            else
            {
                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (frameIndex < rectangles.Length - 1)
                {
                    frameIndex++;
                }
                else if (isLooping)
                {
                    timerSet = true;
                    Timer = timer/100;
                    frameIndex = 0;
                }
            }
        }
    }
}
