using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    public class basicInteract
    {
        
        private bool doInteract = false;

        basicInteract() { }

        public void Interactions(NPC npc, Player player)
        {
            if(InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.P) && npc.NPCRectangle.Intersects(player.rect))
            {
                doInteract = true;
                if(InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.P))
                {
                    doInteract = false;
                }
            }
        }

    }
}
