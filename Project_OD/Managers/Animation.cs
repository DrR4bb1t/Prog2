using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_OD
{
    public class Animation
    {
        protected Texture2D img;
        protected string text;
        protected SpriteFont font;
        protected Color color;
        protected Rectangle srcRect;
        protected float rotation, scale, axis, alpha;
        protected Vector2 origin, position;
        protected ContentManager content;
        protected bool isActive;

        public bool IsActive { get => isActive; set => isActive = value; }
        public virtual float Alpha { get => alpha; set => alpha = value; }
        public virtual void LoadContent(ContentManager content, Texture2D img, string text, Vector2 position)
        {
            content = new ContentManager(content.ServiceProvider, "Content");
            this.img = img;
            this.text = text;
            this.position = position;

            if (text != String.Empty)
            {
                font = content.Load<SpriteFont>("test");
                color = new Color(255, 255, 255);
            }

            if (img != null)
            {
                srcRect = new Rectangle(0, 0, img.Width, img.Height);
            }

            rotation = 0.0f;
            axis = 0.0f;
            scale = alpha = 1.0f;
            isActive = false;
        }

        public virtual void UnloadContent()
        {
            content.Unload();
            text = String.Empty;
            position = Vector2.Zero;
            srcRect = Rectangle.Empty;
            img = null;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (img != null)
            {
                origin = new Vector2(srcRect.Width / 2, srcRect.Height / 2);
                spriteBatch.Draw(img, position + origin, srcRect, Color.White, rotation, origin,
                                scale, SpriteEffects.None, 0.0f);
            }

            if (text != String.Empty)
            {
                origin = new Vector2(font.MeasureString(text).X / 2,
                                     font.MeasureString(text).Y / 2);
                spriteBatch.DrawString(font, text, position + origin, color,
                                       rotation, origin, scale, SpriteEffects.None, 0.0f);
            }
        }
    }
}
