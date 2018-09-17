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

    public class Entity
    {
        public Entity() { }
        //Create Entity
        public void SetEntity(Vector2 position, int width, int height, Texture2D texture, Texture2D deathTexture, float maxSpeed, float jumpMaxSpeed, int maxHp, int baseAtk,float atkRange, float atkTimeout)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.texture = texture;
            this.deathTexture = deathTexture;
            this.jumpMaxSpeed = jumpMaxSpeed;
            this.maxHp = maxHp;
            this.baseAtk = baseAtk;
            this.atkRange = atkRange;
            this.atkTimeout = atkTimeout;
        }
        public void Update()
        {
            
           
            //Animated Sprite

        }
        public void Destroy() { }
        //Private Properties
        protected Vector2 moveTo;
        //Physics physics = new Physics();    //create generally
        
        protected Vector2 position=new Vector2(0, 850);
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

        //?Add Frame for Animated?

        //Modifiers required to be changeable
        public Vector2 Position { get => position; set => position = value; }
        public float Speed { get => speed; set => speed = value; } 
        //Add Acceleration if slows
        public float JumpSpeed { get => jumpSpeed; set => jumpSpeed = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Atk { get => atk; set => atk = value; }
        public float AtkRange { get => atkRange; set => atkRange = value; }
        public float GetjumpMaxSpeed() { return jumpMaxSpeed; }

        public Vector2 GetPosition() { return position; }

    }
}
