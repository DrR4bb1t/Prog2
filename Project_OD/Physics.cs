
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

        public Vector2 Update(Entity entity, GameTime gameTime,string dir, Map map)
        {
            exitVector = moveVector(entity, gameTime, dir,map);
            return exitVector;
        }
        public Vector2 moveVector(Entity entity, GameTime gameTime, string dir,Map map)
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
            canMove(mapX + exitVector.X, mapY, "x", map, entity);
            if (entity.JumpSpeed==entity.GetjumpMaxSpeed())
            {
                midAir = true;
                exitVector += falldown(entity);
            }
            canMove(mapX + exitVector.X, mapY + exitVector.Y, "y", map, entity);
            
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
                    }
                    if (map.lvl1_Forelayer[(int)((posX+entity.GetWith()) / 64), (int)(posY / 64)] == 2)
                    {
                        exitVector.Y = 0;
                    }
                }else if (exitVector.Y < 0)
                {
                    if (map.lvl1_Forelayer[(int)(posX / 64), (int)((posY - entity.GetHeight()) / 64)] == 2)
                    {
                        exitVector.Y = 0;
                    }
                    if (map.lvl1_Forelayer[(int)((posX + entity.GetWith()) / 64), (int)((posY - entity.GetHeight()) / 64)] == 2)
                    {
                        exitVector.Y = 0;
                    }
                }
            }
        }

        public Vector2 falldown(Entity entity)
        {
            if ((entity.JumpSpeed-0.01) > -entity.GetjumpMaxSpeed())
            {
                entity.JumpSpeed -= 0.01f;
            }
            changeVector = new Vector2(0,entity.JumpSpeed);
            return changeVector;
        }
    }
}
