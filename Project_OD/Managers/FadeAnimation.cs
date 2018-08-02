using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project_OD
{
    public class FadeAnimation : Animation
    {
        private bool increase, startTimer, stopUpdating;
        private float fadeSpeed, activateValue, defaultAlpha;
        private TimeSpan defaultTime, timer;

        public TimeSpan Timer { get => timer; set => timer = defaultTime = value; }
        public float ActivateValue { get => activateValue; set => activateValue = value; }
        public float FadeSpeed { get => fadeSpeed; set => fadeSpeed = value; }
        public override float Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;

                if (alpha == 1.0f)
                {
                    increase = false;
                }
                else if (alpha == 0.0f)
                {
                    increase = true;
                }
            }
        }
        public override void LoadContent(ContentManager content, Texture2D img, string text, Vector2 position)
        {
            base.LoadContent(content, img, text, position);
            increase = false;
            fadeSpeed = 1.0f;
            defaultTime = new TimeSpan(0, 0, 1);
            timer = defaultTime;
            activateValue = 0.0f;
            stopUpdating = false;
            defaultAlpha = alpha;
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                if (!stopUpdating)
                {


                    if (increase)
                    {
                        alpha -= fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    }
                    else
                    {
                        alpha += fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    }

                    if (alpha <= 0.0f)
                    {
                        alpha = 0.0f;
                    }
                    else if (alpha >= 1.0f)
                    {
                        alpha = 1.0f;
                    }
                }

                if (alpha == activateValue)
                {
                    stopUpdating = true;
                    timer -= gameTime.ElapsedGameTime;

                    if (timer.TotalSeconds <= 0)
                    {
                        increase = true; /// !increase
                        timer = defaultTime;
                        stopUpdating = false;
                    }
                }
            }
            else
            {
                alpha = defaultAlpha;
            }
        }

    }
}
