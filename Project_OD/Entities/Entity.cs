using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{

    public abstract class Entity
    {
        public Entity() { }
        //Create Entity

        public void SetEntity(Vector2 position, int width, int height, string texture, Texture2D deathTexture, float Speed, float jumpMaxSpeed, int maxHp, int baseAtk, float atkRange, float atkTimeout, int frames, int animations,List<Rectangle> rectangles )
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.texture = OD.content.Load<Texture2D>(texture);
            this.deathTexture = deathTexture;
            this.speed = Speed;
            this.jumpMaxSpeed = jumpMaxSpeed;
            this.maxHp = maxHp;
            this.baseAtk = baseAtk;
            this.atkRange = atkRange;
            this.atkTimeout = atkTimeout;
            this.rect = new Rectangle((int)position.X, (int)position.Y, width, height);
            this.rectangles = rectangles;

            this.sprite = new SpriteAnimation(this.texture, new Vector2(position.X, position.Y), "R", frames, animations);
            sprite.StoreAnimations();
        }
        public void spriteanim(GameTime gameTime,int fps)
        {
            if (moveTo.X > 0)
            {
                sprite.animation = "R";
                sprite.Update(gameTime, true, fps);
            }
            else if (moveTo.X < 0)
            {
                sprite.animation = "L";
                sprite.Update(gameTime, true, fps);
            }
            sprite.position.X = Position.X;
            sprite.position.Y = Position.Y;
            rect.X = (int)Position.X;
            rect.Y = (int)Position.Y;
        }
        public void collisionCheck()
        {
            foreach (var rects in rectangles)
            {
                if ((this.moveTo.X > 0 && this.IsTouchingLeft(rects)) ||
            (this.moveTo.X < 0 && this.IsTouchingRight(rects)))
                    this.moveTo.X = 0;
                Console.WriteLine("Collided at {0}, {1}", rect.X, rect.Y);

                if (this.moveTo.Y > 0 && this.IsTouchingTop(rects))
                {
                    this.moveTo.Y = 0;
                    onGround = true;
                }
                else if(this.moveTo.Y < 0 && this.IsTouchingBottom(rects))
                {
                    this.moveTo.Y = 0;
                }
                else
                {

                }
            }
        }
        #region Collision
        protected bool IsTouchingLeft(Rectangle rectangle)
        {
            return this.rect.Right + this.moveTo.X > rectangle.Left &&
              this.rect.Left < rectangle.Left &&
              this.rect.Bottom > rectangle.Top &&
              this.rect.Top < rectangle.Bottom;
        }

        protected bool IsTouchingRight(Rectangle rectangle)
        {
            return this.rect.Left + this.moveTo.X < rectangle.Right &&
              this.rect.Right > rectangle.Right &&
              this.rect.Bottom > rectangle.Top &&
              this.rect.Top < rectangle.Bottom;
        }

        protected bool IsTouchingTop(Rectangle rectangle)
        {
            return this.rect.Bottom + this.moveTo.Y > rectangle.Top &&
              this.rect.Top < rectangle.Top &&
              this.rect.Right > rectangle.Left &&
              this.rect.Left < rectangle.Right;
        }

        protected bool IsTouchingBottom(Rectangle rectangle)
        {
            return this.rect.Top + this.moveTo.Y < rectangle.Bottom &&
              this.rect.Bottom > rectangle.Bottom &&
              this.rect.Right > rectangle.Left &&
              this.rect.Left < rectangle.Right;
        }
        #endregion
        public void Update(GameTime gameTime, int fps)
        {
            spriteanim(gameTime,fps);
            
            //Animated Sprite
        }

        public void Destroy() { }

        SpriteAnimation sprite;
        //Private Properties
        protected bool onGround;
        protected Vector2 moveTo;
        protected Vector2 position=new Vector2(0, 0);
        protected Rectangle rect;
        protected int width=1;
        protected int height=1;
        protected Texture2D texture;
        protected Texture2D deathTexture;
        protected float speed=200;
        protected float jumpMaxSpeed=1;
        protected float jumpSpeed=0;
        protected int maxHp;
        protected int hp;
        protected int baseAtk;
        protected int atk;
        protected float atkRange;
        protected float atkTimeout;
        protected List<Rectangle> rectangles;

        

        //Modifiers required to be changeable
        public Vector2 Position { get => position; set => position = value; }
        public float Speed { get => speed; set => speed = value; } 
        //Add Acceleration if slows
        public float JumpSpeed { get => jumpSpeed; set => jumpSpeed = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Atk { get => atk; set => atk = value; }
        public float AtkRange { get => atkRange; set => atkRange = value; }
        public float GetjumpMaxSpeed() { return jumpMaxSpeed; }
        public int GetWith() { return width; }
        public int GetHeight() { return height; }


        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);

        }
    }
}
