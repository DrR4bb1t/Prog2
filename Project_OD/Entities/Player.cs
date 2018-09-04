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
        Physics physics = new Physics();

        public int ArmorValue { get => armorValue; set => armorValue = value; }
        public int WeaponValue { get => weaponValue; set => weaponValue = value; }

        #region test for playeranimation

        SpriteAnimation sprite;


        public void LoadTexture()
        {
            texture = OD.content.Load<Texture2D>("spritesheet-test2_1.png");
        }
        


        public Player(int coordX, int coordY, int frames, int animations)
        {
            LoadTexture();

            sprite = new SpriteAnimation(texture, new Vector2(coordX, coordY), "R", frames, animations);
            sprite.StoreAnimations();
            
            
        }


        public void Update(GameTime gameTime, int fps)
        {
            KeyboardState state = Keyboard.GetState();
            dir = "";
            if (state.IsKeyDown(Keys.Right)) {
                dir = "R";
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                dir = "L";
            }
            moveTo = physics.Update(this, gameTime,dir);
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
            sprite.position.X = Position.X;
            sprite.position.Y = Position.Y;
            
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

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);

        }

           #endregion
    }
}
