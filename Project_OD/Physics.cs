
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{

    class Physics
    {

        public Physics() { }
        string activeButton = null;
        float mapX;
        float mapY;
        Vector2 exitVector;
        Vector2 changeVector;

        public Vector2 Update(Entity entity, GameTime gameTime,string dir, List<Rectangle> rectangles)
        {
            exitVector = moveVector(entity, gameTime, dir,rectangles);
            return exitVector;
        }
        public Vector2 moveVector(Entity entity, GameTime gameTime, string dir,List<Rectangle> rectangles)
        {
            mapX = entity.Position.X;
            mapY = entity.Position.Y;
            exitVector = new Vector2(0, 0);
            if (dir == "R")
            {
                exitVector += new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds * entity.Speed, 0);
            }
            else if (dir == "L")
            {
                exitVector += new Vector2(-(float)gameTime.ElapsedGameTime.TotalSeconds * entity.Speed, 0);
            }
            exitVector.Y -= entity.JumpSpeed;
            falldown(entity, gameTime);
                        
            return exitVector;
        }

        

        public Vector2 falldown(Entity entity,GameTime gameTime)
        {
            if ((entity.JumpSpeed-0.01) > -entity.GetjumpMaxSpeed())
            {
                entity.JumpSpeed -= (float)gameTime.ElapsedGameTime.TotalSeconds * 3f;
              
            }
            changeVector = new Vector2(0,-entity.JumpSpeed);
            return changeVector;
        }
    }
}
