
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
        bool collision = false;
        bool midAir = false;
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
                        
            return exitVector;
        }

        public void canMove(float posX, float posY, string dir,Map map, Entity entity)
        {
            if (dir == "x")
            {
                if (exitVector.X > 0)
                {
                    if (map.lvl1_Forelayer[(int)((posX + entity.GetWith()) / 64), (int)(posY / 64)] == 2)
                    {
                        exitVector.X = 0;
                    }
                    if (map.lvl1_Forelayer[(int)((posX + entity.GetWith()) / 64), (int)((posY - entity.GetHeight()) / 64)] == 2)
                    {
                        exitVector.X = 0;
                    }
                }
                else if(exitVector.X < 0)
                {
                    if (map.lvl1_Forelayer[(int)(posX / 64), (int)(posY / 64)] == 2)
                    {
                        exitVector.X = 0;
                    }
                    if (map.lvl1_Forelayer[(int)(posX / 64), (int)((posY - entity.GetHeight()) / 64)] == 2)
                    {
                        exitVector.X = 0;
                    }
                }
                
            }else if (dir == "y")
            {
                if (exitVector.Y > 0)
                {
                    if(map.lvl1_Forelayer[(int)(posX / 64), (int)(posY / 64)] == 2)
                    {
                        exitVector.Y = 0;
                        entity.JumpSpeed = 0;
                        Console.WriteLine("Left-Top");
                    }
                    if (map.lvl1_Forelayer[(int)((posX+entity.GetWith()) / 64), (int)(posY / 64)] == 2)
                    {
                        exitVector.Y = 0;
                        entity.JumpSpeed = 0;
                        Console.WriteLine("Right-Top");
                    }
                }else if (exitVector.Y < 0)
                {
                    if (map.lvl1_Forelayer[(int)(posX / 64), (int)((posY + entity.GetHeight()) / 64)] == 2)
                    {
                        exitVector.Y = 0;
                        midAir = false;
                        Console.WriteLine("Left-Bottom");
                    }
                    if (map.lvl1_Forelayer[(int)((posX + entity.GetWith()) / 64), (int)((posY + entity.GetHeight()) / 64)] == 2)
                    {
                        exitVector.Y = 0;
                        midAir = false;
                        Console.WriteLine("Right-Bottom");
                    }
                }
            }
        }

        public Vector2 falldown(Entity entity,GameTime gameTime)
        {
            if ((entity.JumpSpeed-0.01) > -entity.GetjumpMaxSpeed())
            {
                entity.JumpSpeed -= (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;
              
            }
            changeVector = new Vector2(0,-entity.JumpSpeed);
            return changeVector;
        }
    }
}
