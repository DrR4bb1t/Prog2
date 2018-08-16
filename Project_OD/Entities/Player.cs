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
        public Player() { }
        private int armorValue;
        private int weaponValue;

        
        public int ArmorValue { get => armorValue; set => armorValue = value; }
        public int WeaponValue { get => weaponValue; set => weaponValue = value; }

        #region test for playeranimation

        KeyboardState currentKBState;
        KeyboardState previousKBState;

        private float frame;
        private int animationFrame;
        private int step;
        private int sWidth;

        public int SWidth { get => sWidth; set => sWidth = value; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        
        private int totalFrames;
        private int posXRect;
        private int posYRect;
        private bool activeRight;
        private bool activeLeft;

        public void LoadTexture()
        {
            texture = OD.content.Load<Texture2D>("spritesheet3");
        }
        


        public Player(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = 7;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
            {
                position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
                activeRight = true;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }

            if (state.IsKeyUp(Keys.Right))
            {
                activeRight = false;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                position.X -= (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
                activeLeft = true;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }

            if (state.IsKeyUp(Keys.Left))
            {
                activeLeft = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;



            if (activeRight == true)
            {
                posXRect = width * column;
                posYRect = 0;
            }

            if (activeLeft == true)
            {
                posXRect = 345 - (width * column);
                posYRect = 51;

            }

            Rectangle sourceRectangle = new Rectangle(posXRect, posYRect, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(Texture, Position, new Rectangle(sWidth, 0, 53, 48), Color.White);
        //}

        //public void Update(GameTime gameTime)
        //{
        //    KeyboardState state = Keyboard.GetState();

        //    if (state.IsKeyDown(Keys.Left))
        //        position.X -= (float)(gameTime.ElapsedGameTime.TotalSeconds * Speed);

        //    if (state.IsKeyDown(Keys.Right))
        //    {
        //        position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * Speed);





        //        SWidth = 1 * (48 * step);

        //        step++;

        //        if (step > 9)
        //        {
        //            step = 1;
        //        }

        //        //frame += (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
        //        //if (frame > 400)
        //        //{
        //        //    frame = 0;
        //        //}
        //    }
        //}

           #endregion
    }
}
