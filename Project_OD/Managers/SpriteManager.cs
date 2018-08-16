using Microsoft.Xna.Framework;
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
        protected Rectangle[] recs;
        protected int frameIndex = 0;
        protected Dictionary<string, Rectangle[]> Animations = new Dictionary<string, Rectangle[]>();
        protected int frames;
        private int width;
        private int height;
        public Vector2 position = Vector2.Zero;
        public Color color = Color.White;
        public Vector2 origin;
        public float rotation = 0f;
        public float scale = 1f;
        public SpriteEffect spriteEffect;
        public string animation;

        public SpriteManager(Texture2D texture, int frames, int animations)
        {
            this.texture = texture;
            this.frames = frames;
            width = texture.Width / frames;
            height = texture.Height / animations;

        }

        public void AddAnimation(string name, int row)
        {
            recs = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                recs[i] = new Rectangle(i * width, (row - 1) * height, width, height);
            }

            Animations.Add(name, recs);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Animations[animation][frameIndex], color);
        }
    }
}
