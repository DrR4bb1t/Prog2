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
    public class Player : Entity
    {
        //public Player() { }
        private int armorValue;
        private int weaponValue;
        private string dir;
        private bool atkMove;
        private bool dirR;
        private bool dirL;
        Physics physics = new Physics();

        public bool DirR { get => dirR; }
        public bool DirL { get => dirL; }
        public bool ATK { get => atkMove; }
        public int ArmorValue { get => armorValue; set => armorValue = value; }
        public int WeaponValue { get => weaponValue; set => weaponValue = value; }

        #region test for playeranimation

        SpriteAnimation sprite;
        SpriteAnimation sprite2;


        public void LoadTexture()
        {
            texture = OD.content.Load<Texture2D>("spritesheet-test2_1.png");
            texture2 = OD.content.Load<Texture2D>("spritesheet-atk");
        }
        


        public Player(int coordX, int coordY, int frames, int animations)
        {
            LoadTexture();

            dirR = true;

            sprite = new SpriteAnimation(texture, new Vector2(coordX, coordY), "R", frames, animations);
            sprite2 = new SpriteAnimation(texture2, new Vector2(coordX, coordY), "atk-R", frames, animations);
            sprite.StoreAnimations(1);
            sprite2.StoreAnimations(2);
            
            
        }


        public void Update(GameTime gameTime, int fps)
        {
            KeyboardState state = Keyboard.GetState();

            dir = "";
            if (state.IsKeyDown(Keys.Right))
            {
                dir = "R";
                dirR = true;
                dirL = false;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                dir = "L";
                dirR = false;
                dirL = true;
            }
            moveTo = physics.Update(this, gameTime, dir);
            Position += moveTo;
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

            if (state.IsKeyDown(Keys.Space) && dirR == true)
            {
                atkMove = true;
                sprite2.animation = "atk-R";
                sprite2.Update(gameTime, true, fps);
            }
            if (state.IsKeyDown(Keys.Space) && dirL == true)
            {
                atkMove = true;
                sprite2.animation = "atk-L";
                sprite2.Update(gameTime, true, fps);
            }

            if (state.IsKeyUp(Keys.Space))
            {
                atkMove = false;
            }
            sprite.position.X = Position.X;
            sprite.position.Y = Position.Y;
            sprite2.position.X = Position.X;
            sprite2.position.Y = Position.Y;
            
            //if (state.IsKeyDown(Keys.Right))
            //{
            //    sprite.animation = "R";
            //    sprite.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);//sprite.position=player.position
            //    sprite.Update(gameTime, true, fps);
            //}
            //else if (state.IsKeyDown(Keys.Left))
            //{
            //    sprite.animation = "L";
            //    sprite.position.X -= (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
            //    sprite.Update(gameTime, true, fps);
            //}

            Console.WriteLine("X: {0}, Y: {1}", position.X, position.Y);
        }

        public void Draw(SpriteBatch spriteBatch, bool atk)
        {


            if (atk == true)
            {
               sprite2.Draw(spriteBatch);
            }
            else
            {
               sprite.Draw(spriteBatch);
            }
        }

           #endregion
    }
}
