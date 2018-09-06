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
        private int skillCnt;
        private string dir;
        private bool atkMove;
        private bool skill1;
        private bool dirR;
        private bool dirL;
        public int skill;
        Physics physics = new Physics();

        public bool DirR { get => dirR; }
        public bool DirL { get => dirL; }
        public bool ATK { get => atkMove; }
        public int ArmorValue { get => armorValue; set => armorValue = value; }
        public int WeaponValue { get => weaponValue; set => weaponValue = value; }

        #region test for playeranimation

        SpriteAnimation sprite;
        SpriteAnimation sprite2;
        SpriteAnimation sprite3;


        public void LoadTexture()
        {
            texture = OD.content.Load<Texture2D>("spritesheet-test2_1.png");
            texture2 = OD.content.Load<Texture2D>("spritesheet-atk");
            texture3 = OD.content.Load<Texture2D>("spritesheet-dash");
        }
        


        public Player(int coordX, int coordY, int frames, int animations)
        {
            LoadTexture();

            dirR = true;

            sprite = new SpriteAnimation(texture, new Vector2(coordX, coordY), "R", frames, animations);
            sprite2 = new SpriteAnimation(texture2, new Vector2(coordX, coordY), "atk-R", frames, animations);
            sprite3 = new SpriteAnimation(texture3, new Vector2(coordX, coordY), "dash-R", frames, animations);
            sprite.StoreAnimations(1);
            sprite2.StoreAnimations(2);
            sprite3.StoreAnimations(3);
            
            
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
                skill = 0;
                atkMove = true;
                sprite2.animation = "atk-R";
                sprite2.Update(gameTime, true, fps);
            }
            else if (state.IsKeyDown(Keys.Space) && dirL == true)
            {
                skill = 0;
                atkMove = true;
                sprite2.animation = "atk-L";
                sprite2.Update(gameTime, true, fps);
            }

            ///Dash-Attack
            #region Dash-Attack
            if (state.IsKeyDown(Keys.W) && dirR == true)
            {
                skill = 1;
                atkMove = true;
                skill1 = true;        
            }
            else if (state.IsKeyDown(Keys.W) && dirL == true)
            {
                skill = 1;
                atkMove = true;
                skill1 = true;
            }

            if (skill1 == true)
            {
                if (dirR == true)
                {
                    sprite3.animation = "dash-R";
                    sprite3.Update(gameTime, true, 25);
                    position.X += 10.0f;
                    skillCnt++;
                }
                else if (dirL == true)
                {
                    sprite3.animation = "dash-L";
                    sprite3.Update(gameTime, true, 25);
                    position.X -= 10.0f;
                    skillCnt++;
                }

                if (skillCnt > 20)
                {
                    skill1 = false;
                    skillCnt = 0;
                }
            }
            #endregion

            if (state.IsKeyUp(Keys.Space) && state.IsKeyUp(Keys.W))
            {
                if (skill1 == false)
                {
                    atkMove = false;
                }
            }
            sprite.position.X = Position.X;
            sprite.position.Y = Position.Y;
            sprite2.position.X = Position.X;
            sprite2.position.Y = Position.Y;
            sprite3.position.X = Position.X;
            sprite3.position.Y = Position.Y;
            
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

        public void Draw(SpriteBatch spriteBatch, bool atk, int skill)
        {


            if (atk == true)
            {
                switch (skill)
                {
                    case 0:
                        sprite2.Draw(spriteBatch);
                        break;
                    case 1:
                        sprite3.Draw(spriteBatch);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                sprite.Draw(spriteBatch);
                //sprite3.Draw(spriteBatch);
            }
        }

           #endregion
    }
}
