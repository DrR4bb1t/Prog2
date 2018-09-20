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
        
        public new void Update(GameTime gameTime, int fps)
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
            if (state.IsKeyDown(Keys.Up)&onGround)
            {
                jumpSpeed = GetjumpMaxSpeed();
                onGround = false;
            }
            moveTo = physics.moveVector(this, gameTime,dir,rectangles);
            this.collisionCheck();
            Position += moveTo;
            spriteanim(gameTime, fps);
           
            //Console.WriteLine("Player X: {0}, Y: {1}", position.X, position.Y);
        }

    }
}
