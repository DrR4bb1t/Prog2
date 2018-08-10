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


        //public override void LoadContent(ContentManager content, InputManager input)
        //{
        //    //base.LoadContent(content, input);
        //    TextureManager.LoadTexture(texture, "spritesheet3");
        //    //moveAnimation = new SpriteSheetAnimation();
        //    ////texture = content.Load<Texture2D>("spritesheet3");
        //    //Vector2 tempFrames = Vector2.Zero;
        //    //moveAnimation.LoadContent(content, texture, "", positionTest);
        //}

        public void LoadTexture()
        {
            texture = OD.content.Load<Texture2D>("spritesheet3");
        }

        //public override void UnloadContent()
        //{
        //    base.UnloadContent();
        //    moveAnimation.UnloadContent();
        //}

        //public override void Update(GameTime gameTime)
        //{
        //    moveAnimation.Update(gameTime);
        //}

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    //moveAnimation.Draw(spriteBatch);
        //    TextureManager.Draw(texture, spriteBatch, positionTest, 1, 1, 100, 100);
        //}

        
        public int Rows { get; set; }
        public int Columns { get; set; }
        
        private int totalFrames;

        public Player(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
            {
                position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, /*height * row*/ 0, width, height);
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
