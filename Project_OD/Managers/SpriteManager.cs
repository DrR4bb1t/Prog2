﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    public abstract class SpriteManager
    {
        protected Texture2D texture;
        protected Rectangle[] rectangles;
        protected int frameIndex = 0;
        /// <summary>
        /// Creates a dictionary to store and call the different animations.
        /// </summary>
        protected Dictionary<string, Rectangle[]> Animations = new Dictionary<string, Rectangle[]>();
        /// <summary>
        /// Initialize variables.
        /// </summary>
        protected int frames;
        private int width;
        private int height;
        public Vector2 position = Vector2.Zero;
        public Color color = Color.White;
        public string animation;

        public SpriteManager(Texture2D texture, Vector2 position, string startAnimation, int frames, int animations)
        {
            this.texture = texture;
            this.position = position;
            animation = startAnimation;
            this.frames = frames;
            width = texture.Width / frames;
            height = texture.Height / animations;

        }

        /// <summary>
        /// Adds a animation to the dictionary.
        /// </summary>
        /// <param name="name">Name of the animation.</param>
        /// <param name="row">Row of the needed sprites.</param>
        public void AddAnimation(string name, int row)
        {
            rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                rectangles[i] = new Rectangle(i * width, (row - 1) * height, width, height);
            }

            Animations.Add(name, rectangles);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Animations[animation][frameIndex], color);
        }

        /// <summary>
        /// Stores all animations.
        /// </summary>
        public void StoreAnimations(int moveset)
        {
            switch (moveset)
            {
                case 1:
                    AddAnimation("R", 1);
                    AddAnimation("L", 2);
                    break;
                case 2:
                    AddAnimation("atk-R", 1);
                    AddAnimation("atk-L", 2);
                    break;
                case 3:
                    AddAnimation("dash-R", 1);
                    AddAnimation("dash-L", 2);
                    break;
                case 4:
                    AddAnimation("smash-R", 1);
                    AddAnimation("smash-L", 2);
                    break;
                case 5:
                    AddAnimation("stamp-R", 1);
                    AddAnimation("stamp-L", 2);
                    break;
                case 6:
                    AddAnimation("spikeCast-R", 1);
                    AddAnimation("spikeCast-L", 2);
                    break;
                case 7:
                    AddAnimation("spikes-R", 1);
                    AddAnimation("spikes-L", 1);
                    break;
                case 8:
                    AddAnimation("explosionCast-R", 1);
                    AddAnimation("explosionCast-L", 2);
                    break;
                case 9:
                    AddAnimation("explosion-R", 1);
                    AddAnimation("explosion-L", 1);
                    break;
                case 10:
                    AddAnimation("activation-R", 1);
                    AddAnimation("activation-L", 2);
                    break;
                default:
                    break;
            }


        }
    }
}
