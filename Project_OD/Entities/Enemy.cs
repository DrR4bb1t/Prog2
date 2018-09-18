using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    class Enemy:Entity
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
        protected int triggerRange;
        public void patrol()
        {
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

        public new void Update(GameTime gameTime, int fps)
        {
            patrol();
            moveTo = physics.moveVector(this, gameTime, direction,rectangles);
            Position += moveTo;
            spriteanim(gameTime, fps);

            //check distance to player
        }


        public Vector2 Target1 { get => target1; set => target1 = value; }
        public Vector2 Target2 { get => target2; set => target2 = value; }
        public int TriggerRange { get => triggerRange; set => triggerRange = value; }
    }
}
