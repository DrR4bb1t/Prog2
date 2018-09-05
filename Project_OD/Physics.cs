﻿using System;
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
        Vector2 exitVector;
        Vector2 changeVector;

        public Vector2 Update(Entity entity, GameTime gameTime, string dir)
        {
            exitVector = new Vector2(0, 0);
            if (dir == "R") {
                exitVector += new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds * entity.Speed, 0);
            }
            else if (dir == "L")
            {
                exitVector += new Vector2(-(float)gameTime.ElapsedGameTime.TotalSeconds * entity.Speed, 0);
            }
            return exitVector;
        }
    }
}
