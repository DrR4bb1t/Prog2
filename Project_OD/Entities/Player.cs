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
        private int skillCnt1;
        private int cooldown1;
        private int skillCnt2;
        private int cooldown2;
        private int skillCnt3;
        private int cooldown3;
        private string dir;
        private bool atkMove;
        private bool skill1;
        private bool skill2;
        private bool skill3;
        private bool skill1Cooldown;
        private bool skill2Cooldown;
        private bool skill3Cooldown;
        private bool predator2 = false;
        private bool technokrat2 = false;
        private bool technoMage2 = true;
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
        SpriteAnimation sprite4;
        SpriteAnimation sprite5;
        SpriteAnimation sprite5_1;
        SpriteAnimation sprite5_1_1;
        SpriteAnimation sprite5_2;
        SpriteAnimation sprite5_2_1;


        public void LoadTexture()
        {
            texture = OD.content.Load<Texture2D>("spritesheet-test2_1.png");
            texture2 = OD.content.Load<Texture2D>("spritesheet-atk");
            texture3 = OD.content.Load<Texture2D>("spritesheet-dash");
            texture4 = OD.content.Load<Texture2D>("spritesheet-smash");
            texture5 = OD.content.Load<Texture2D>("spritesheet-stamp2");
            texture5_1 = OD.content.Load<Texture2D>("spritesheet-thorns2_1");
            texture5_1_1 = OD.content.Load<Texture2D>("spritesheet-thorns_summon2");
            texture5_2 = OD.content.Load<Texture2D>("spritesheet-explosion2");
            texture5_2_1 = OD.content.Load<Texture2D>("spritesheet-explosion_summon");
        }
        


        public Player(int coordX, int coordY, int frames, int animations)
        {
            LoadTexture();

            dirR = true;

            sprite = new SpriteAnimation(texture, new Vector2(coordX, coordY), "R", frames, animations);
            sprite2 = new SpriteAnimation(texture2, new Vector2(coordX, coordY), "atk-R", frames, animations);
            sprite3 = new SpriteAnimation(texture3, new Vector2(coordX, coordY), "dash-R", frames, animations);
            sprite4 = new SpriteAnimation(texture4, new Vector2(coordX, coordY), "smash-R", frames, animations);
            sprite5 = new SpriteAnimation(texture5, new Vector2(coordX, coordY), "stamp-R", 8, animations);
            sprite5_1 = new SpriteAnimation(texture5_1, new Vector2(coordX, coordY), "spikes-R", frames, 1);
            sprite5_1_1 = new SpriteAnimation(texture5_1_1, new Vector2(coordX, coordY), "spikeCast-R", frames, animations);
            sprite5_2 = new SpriteAnimation(texture5_2, new Vector2(coordX, coordY), "explosion-R", frames, 1);
            sprite5_2_1 = new SpriteAnimation(texture5_2_1, new Vector2(coordX, coordY), "explosionCast-R", frames, animations);

            sprite.StoreAnimations(1);
            sprite2.StoreAnimations(2);
            sprite3.StoreAnimations(3);
            sprite4.StoreAnimations(4);
            sprite5.StoreAnimations(5);
            sprite5_1.StoreAnimations(7);
            sprite5_1_1.StoreAnimations(6);
            sprite5_2.StoreAnimations(9);
            sprite5_2_1.StoreAnimations(8);
            
            
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
                if (cooldown1 == 0)
                {                    
                    skill = 1;
                    cooldown1 = 180;
                    atkMove = true;
                    skill1 = true;
                }
            }
            else if (state.IsKeyDown(Keys.W) && dirL == true)
            {
                if (cooldown1 == 0)
                {
                    skill = 1;
                    cooldown1 = 180;
                    atkMove = true;
                    skill1 = true;
                }
            }

            if (skill1 == true)
            {
                
                if (dirR == true)
                {
                    sprite3.animation = "dash-R";
                    sprite3.Update(gameTime, true, 25);
                    position.X += 10.0f;
                    skillCnt1++;
                }
                else if (dirL == true)
                {
                    sprite3.animation = "dash-L";
                    sprite3.Update(gameTime, true, 25);
                    position.X -= 10.0f;
                    skillCnt1++;
                }

                if (skillCnt1 == 20)
                {
                    skill1 = false;
                    skillCnt1 = 0;
                    skill1Cooldown = true;
                }
            }

            if (skill1Cooldown == true)
            {
                --cooldown1;
                if (cooldown1 == 0)
                {
                    cooldown1 = 0;
                    skill1Cooldown = false;
                }
            }
            #endregion

            ///Smash-Attack
            #region Smash-Attack
            if (state.IsKeyDown(Keys.E) && dirR == true)
            {
                if (cooldown2 == 0)
                {
                    skill = 2;
                    cooldown2 = 180;
                    atkMove = true;
                    skill2 = true;
                }
            }
            else if (state.IsKeyDown(Keys.E) && dirL == true)
            {
                if (cooldown2 == 0)
                {
                    skill = 2;
                    cooldown2 = 180;
                    atkMove = true;
                    skill2 = true;
                }
            }

            if (skill2 == true)
            {

                if (dirR == true)
                {
                    sprite4.animation = "smash-R";
                    sprite4.Update(gameTime, true, 7);
                    skillCnt2++;
                }
                else if (dirL == true)
                {
                    sprite4.animation = "smash-L";
                    sprite4.Update(gameTime, true, 7);
                    skillCnt2++;
                }

                if (skillCnt2 == 60)
                {
                    skill2 = false;
                    skillCnt2 = 0;
                    skill2Cooldown = true;
                }
            }

            if (skill2Cooldown == true)
            {
                --cooldown2;
                if (cooldown2 == 0)
                {
                    cooldown2 = 0;
                    skill2Cooldown = false;
                }
            }
            #endregion

            ///Stamp-Attack
            #region Stamp-Attack
            if (state.IsKeyDown(Keys.R) && dirR == true)
            {
                if (cooldown3 == 0)
                {
                    skill = 3;
                    cooldown3 = 180;
                    atkMove = true;
                    skill3 = true;
                }
            }
            else if (state.IsKeyDown(Keys.R) && dirL == true)
            {
                if (cooldown3 == 0)
                {
                    skill = 3;
                    cooldown3 = 180;
                    atkMove = true;
                    skill3 = true;
                }
            }

            if (skill3 == true)
            {
                if (predator2 == true)
                {


                    if (dirR == true)
                    {
                        sprite5.animation = "stamp-R";
                        sprite5.Update(gameTime, true, 8);
                        skillCnt3++;
                    }
                    else if (dirL == true)
                    {
                        sprite5.animation = "stamp-L";
                        sprite5.Update(gameTime, true, 8);
                        skillCnt3++;
                    }

                    if (skillCnt3 == 60)
                    {
                        skill3 = false;
                        skillCnt3 = 0;
                        skill3Cooldown = true;
                    }
                }

                if (technokrat2 == true)
                {
                    if (dirR == true)
                    {
                        sprite5_1_1.animation = "spikeCast-R";
                        sprite5_1_1.Update(gameTime, true, 7);
                        sprite5_1.animation = "spikes-R";
                        sprite5_1.Update(gameTime, true, 7);
                        skillCnt3++;
                    }
                    else if (dirL == true)
                    {
                        sprite5_1_1.animation = "spikeCast-L";
                        sprite5_1_1.Update(gameTime, true, 7);
                        sprite5_1.animation = "spikes-L";
                        sprite5_1.Update(gameTime, true, 7);
                        skillCnt3++;
                    }

                    if (skillCnt3 == 60)
                    {
                        skill3 = false;
                        skillCnt3 = 0;
                        skill3Cooldown = true;
                    }
                }

                if (technoMage2 == true)
                {
                    if (dirR == true)
                    {
                        sprite5_2_1.animation = "explosionCast-R";
                        sprite5_2_1.Update(gameTime, true, 7);
                        sprite5_2.animation = "explosion-R";
                        sprite5_2.Update(gameTime, true, 7);
                        skillCnt3++;
                    }
                    else if (dirL == true)
                    {
                        sprite5_2_1.animation = "explosionCast-L";
                        sprite5_2_1.Update(gameTime, true, 7);
                        sprite5_2.animation = "explosion-L";
                        sprite5_2.Update(gameTime, true, 7);
                        skillCnt3++;
                    }

                    if (skillCnt3 == 60)
                    {
                        skill3 = false;
                        skillCnt3 = 0;
                        skill3Cooldown = true;
                    }
                }
            }

                         
            

            if (skill3Cooldown == true)
            {
                --cooldown3;
                if (cooldown3 == 0)
                {
                    cooldown3 = 0;
                    skill3Cooldown = false;
                }
            }

            
            #endregion

            if (state.IsKeyUp(Keys.Space) && state.IsKeyUp(Keys.W) && state.IsKeyUp(Keys.E) && state.IsKeyUp(Keys.R))
            {
                if (skill1 == false && skill2 == false && skill3 == false)
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
            sprite4.position.X = Position.X;
            sprite4.position.Y = Position.Y;
            sprite5.position.X = Position.X;
            sprite5.position.Y = Position.Y;

            if (dirR == true)
            {
                sprite5_1.position.X = position.X + 100;
                sprite5_1.position.Y = position.Y + 20;
                sprite5_2.position.X = position.X + 100;
                sprite5_2.position.Y = position.Y - 60;
            }
            else if (dirL == true)
            {
                sprite5_1.position.X = position.X - 100;
                sprite5_1.position.Y = position.Y + 20;
                sprite5_2.position.X = position.X - 200;
                sprite5_2.position.Y = position.Y - 60;
            }

            sprite5_1_1.position.X = Position.X;
            sprite5_1_1.position.Y = Position.Y;
            sprite5_2_1.position.X = Position.X;
            sprite5_2_1.position.Y = Position.Y;
            
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
                    case 2:
                        sprite4.Draw(spriteBatch);
                        break;
                    case 3:
                        if (predator2 == true)
                        {
                            sprite5.Draw(spriteBatch);
                        }
                        else if (technokrat2 == true)
                        {
                            sprite5_1_1.Draw(spriteBatch);
                            sprite5_1.Draw(spriteBatch);
                        }
                        else if (technoMage2 == true)
                        {
                            sprite5_2_1.Draw(spriteBatch);
                            sprite5_2.Draw(spriteBatch);
                        }
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
