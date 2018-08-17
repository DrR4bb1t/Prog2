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


        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
            {
                sprite.animation = "R";
                sprite.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
                sprite.Update(gameTime, true, 20);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                sprite.animation = "L";
                sprite.position.X -= (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
                sprite.Update(gameTime, true, 20);
            }
            

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);

        }

           #endregion
    }
}
