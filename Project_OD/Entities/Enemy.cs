using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//todo: add attack
namespace Project_OD
{
    public class Enemy:Entity
    {
        Physics physics = new Physics();
        
        public void enemyinit(Vector2 startpos)
        {
            target1 = startpos;
            target2 = target1 + new Vector2(100, 0);
            currTarget = target2;
        }
        private string direction="R"; 
        protected Vector2 target1;
        protected Vector2 target2;
        protected Vector2 playerPos;
        protected Vector2 currTarget;
        protected float distance=10000;
        protected int triggerRange=150;
        protected bool damaged = false;
        protected float timer;
        public void getDamaged(Player player,GameTime gameTime)
        {
            if (rect.Intersects(player.rect))
            {
                if (player.skill1&&!damaged)
                {
                    damaged = true;
                    Console.WriteLine("HP: {0}",hp);
                    hp -= (int)((player.baseAtk + player.WeaponValue) * player.skillScaling1);
                    Console.WriteLine("HP Dash: {0}", hp);
                    timer = 0;
                }
                else if (player.jumpAttack&&!damaged)
                {
                    damaged=true;
                    hp-= (int)((player.baseAtk + player.WeaponValue) * player.skillScaling3);
                    timer = 0;
                    Console.WriteLine("HP Stomp: {0}", hp);
                    player.jumpAttack = false;
                }
                else if(damaged&&(timer>=100))
                {
                    damaged = false;
                }
                if (timer < 100)
                {
                    timer++;
                }
            }
        }
        public void getDistance()
        {
            distance= (float)Math.Sqrt(Math.Pow(Math.Abs(position.X - playerPos.X), 2) + Math.Pow(Math.Abs(position.Y - playerPos.Y), 2));
        }
        public void patrol()
        {
            if (distance < atkRange)
            {
                direction = "S";
                //attack
            }
            else if (distance<triggerRange)
            {
                currTarget = playerPos;
                if (playerPos.X > position.X)
                {
                    direction = "R";
                }
                else if (playerPos.X<position.X)
                {
                    direction = "L";
                }
                //Console.WriteLine("Distance xy:{0}, {1} xy:{2}, {3} is {4}", position.X, position.Y, playerPos.X, playerPos.Y, distance);
            }
            else {
                if (direction == "S")
                {
                    direction = "R";
                }
                if (direction == "R" && position.X >= target2.X)
                {
                    currTarget = target1;
                    direction = "L";
                }
                if (direction == "L" && position.X <= target1.X)
                {
                    currTarget = target2;
                    direction = "R";
                }
            }
        }

        public void Update(GameTime gameTime, int fps,Player player)
        {
            playerPos = player.Position;
            getDistance();
            getDamaged(player, gameTime);
            patrol();
            moveTo = physics.moveVector(this, gameTime, direction,rectangles);
            this.collisionCheck();
            Position += moveTo;
            spriteanim(gameTime, fps);

            //check distance to player
        }


        public Vector2 Target1 { get => target1; set => target1 = value; }
        public Vector2 Target2 { get => target2; set => target2 = value; }
        public int TriggerRange { get => triggerRange; set => triggerRange = value; }
    }
}
