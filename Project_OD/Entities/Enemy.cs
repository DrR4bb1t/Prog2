using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//todo: add attack
namespace Project_OD
{
    public class Enemy : Entity
    {
        public Enemy()
        {
            LoadTexture();
            sprite2 = new SpriteAnimation(texture2, position, "atk-R", frames, animations);
            sprite2.StoreAnimations(2);
            atkTimeout = 100;
        }
        public void LoadTexture()
        {
            texture2 = OD.content.Load<Texture2D>("spritesheet-atk");
        }
        Physics physics = new Physics();

        public void enemyinit(Vector2 startpos)
        {
            target1 = startpos;
            target2 = target1 + new Vector2(100, 0);
            currTarget = target2;
        }

        public void setEnemies(List<Enemy> enemies, Collision collision)
        {
            if(OD.lvlID == 0)
            {
                Enemy enemy_1 = new Enemy();
                enemy_1.enemyinit(new Vector2(400, 720));
                enemy_1.SetEntity(new Vector2(400, 720), 50, 46, "spritesheet-test2_1.png", null, 120, 1, 100, 10, 50, 0, 7, 2, collision.rectangles);
            }
            if (OD.lvlID == 1)
            {

            }
            if (OD.lvlID == 2)
            {

            }
            if (OD.lvlID == 3)
            {

            }
            if (OD.lvlID == 4)
            {

            }
            if (OD.lvlID == 5)
            {

            }
            if (OD.lvlID == 6)
            {

            }
            if (OD.lvlID == 7)
            {

            }
        }

        protected Vector2 target1;
        protected Vector2 target2;
        protected Vector2 playerPos;
        protected Vector2 currTarget;
        protected float distance = 10000;
        protected int triggerRange = 150;
        private Player player;
        private bool isAttacking = false;
        private bool finishedAttack = false;

        SpriteAnimation sprite2;


        public void takeDamage(int damage)
        {
            hp -= damage;
            Console.WriteLine("HP: {0}", hp);
        }
        public void getDamaged(Player player, GameTime gameTime)
        {
            if (rect.Intersects(player.rect))
            {
                if (player.skill1 && !damaged)
                {
                    damaged = true;
                    Console.WriteLine("HP: {0}", hp);
                    hp -= (int)((player.baseAtk + player.WeaponValue) * player.skillScaling1);
                    Console.WriteLine("HP Dash: {0}", hp);
                    timer = 0;
                }
                else if (player.jumpAttack && !damaged)
                {
                    if (player.JumpSpeed < -0.1)
                    {
                        damaged = true;
                        hp -= (int)((player.baseAtk + player.WeaponValue) * player.skillScaling3);
                        timer = 0;
                        Console.WriteLine("HP Stomp: {0}", hp);
                        player.jumpAttack = false;
                    }
                }
                else if (damaged && (timer >= 100))
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
            distance = (float)Math.Sqrt(Math.Pow(Math.Abs(position.X - playerPos.X), 2) + Math.Pow(Math.Abs(position.Y - playerPos.Y), 2));
        }
        public void attackPlayer()
        {
            isAttacking = true;
            finishedAttack = false;
        }
        public void doAttack(Player player, GameTime gameTime)
        {
            if (isAttacking)
            {
                sprite2.Update(gameTime, true, 20, 100);
                if (atkTimeout > 0)
                {
                    atkTimeout--;
                }
                else
                if (sprite2.frameIndex == 6)
                {
                    if (atkRect.Intersects(player.rect))
                    {
                        player.takeDamage(baseAtk);
                    }
                    atkTimeout = 100;
                    finishedAttack = true;
                    isAttacking = false;


                }
                else if (atkTimeout == 0)
                {
                    isAttacking = false;
                    dir = "";
                }
            }
            else
            {

            }
        }
        public void patrol()
        {
            if (distance < atkRange)
            {
                if (dir == "R")
                {
                    sprite2.animation = "atk-R";
                }
                else if (dir == "L")
                {
                    sprite2.animation = "atk-L";
                }

                dir = "S";
                attackPlayer();
                //attack
            }
            else if (distance < triggerRange && atkTimeout == 0)
            {
                currTarget = playerPos;
                if (playerPos.X > position.X)
                {
                    dir = "R";
                }
                else if (playerPos.X < position.X)
                {
                    dir = "L";
                }
                //Console.WriteLine("Distance xy:{0}, {1} xy:{2}, {3} is {4}", position.X, position.Y, playerPos.X, playerPos.Y, distance);
            }
            else
            {
                if (dir == "S")
                {

                }
                if (dir == "")
                {
                    dir = "R";
                }
                if (dir == "R" && position.X >= target2.X)
                {
                    currTarget = target1;
                    dir = "L";
                }
                if (dir == "L" && position.X <= target1.X)
                {
                    currTarget = target2;
                    dir = "R";
                }
            }
        }

        public void Update(GameTime gameTime, int fps, Player player, int lvlID)
        {
            this.player = player;
            playerPos = this.player.Position;
            getDistance();
            getDamaged(this.player, gameTime);
            patrol();
            moveTo = physics.moveVector(this, gameTime, dir, rectangles);
            this.collisionCheck(lvlID);
            Position += moveTo;
            spriteanim(gameTime, fps);
            sprite2.position = position;
            doAttack(player, gameTime);

            //check distance to player
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            if (isAttacking)
            {
                sprite2.Draw(spriteBatch);
            }
            else
            {
                sprite.Draw(spriteBatch);
            }
        }


        public Vector2 Target1 { get => target1; set => target1 = value; }
        public Vector2 Target2 { get => target2; set => target2 = value; }
        public int TriggerRange { get => triggerRange; set => triggerRange = value; }
    }
}
