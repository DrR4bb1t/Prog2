using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public void SetEntity(Vector2 position, int width, int height, Texture2D texture, Texture2D deathTexture, float maxSpeed, float acceleration, float jumpHeight, int maxHp, int baseAtk,float atkRange)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.texture = texture;
            this.deathTexture = deathTexture;
            this.maxSpeed = maxSpeed;
            this.acceleration = acceleration;
            this.jumpHeight = jumpHeight;
            this.maxHp = maxHp;
            this.baseAtk = baseAtk;
            this.atkRange = atkRange;
        }
        public void Update()
        {

            //Animated Sprite

        }
        public void Destroy() { }
        //Private Properties
        protected Vector2 position;
        protected int width;
        protected int height;
        protected Texture2D texture;
        protected Texture2D deathTexture;
        protected float maxSpeed;
        protected float speed;
        protected float acceleration;
        protected float jumpHeight;
        protected float jumpSpeed;
        protected int maxHp;
        protected int hp;
        protected int baseAtk;
        protected int atk;
        protected float atkRange;
        
        //?Add Frame for Animated?

        //Modifiers required to be changeable
        public Vector2 Position { get => position; set => position = value; }
        public float Speed { get => speed; set { if (value <= maxSpeed) speed = value; } }
        //Add Acceleration if slows
        public float JumpSpeed { get => jumpSpeed; set => jumpSpeed = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Atk { get => atk; set => atk = value; }
        public float AtkRange { get => atkRange; set => atkRange = value; }
    }
}
