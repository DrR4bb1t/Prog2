using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    public class Story
    {
        Texture2D prologue_1;
        Texture2D prologue_2;
        Texture2D prologue_3;
        Texture2D prologue_4;
        Texture2D prologue_5;
        Texture2D prologue_6;
        Texture2D prologue_7;
        Texture2D prologue_8;

        Texture2D mc_1;
        Texture2D mc_2;
        Texture2D mc_3;
        Texture2D mc_4;
        Texture2D mc_5;
        Texture2D mc_7;

        Texture2D friedrich_1;

        Texture2D theo_1;
        Texture2D theo_2;

        Texture2D clara_1;

        public bool cnt = false;

        public static int ProgressCounter = 0;

        public Story()
        {
            prologue_1 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue");
            prologue_2 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue_2");
            prologue_3 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue_3");
            prologue_4 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue_4");
            prologue_5 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue_5");
            prologue_6 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue_6");
            prologue_7 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue_7");
            prologue_8 = OD.content.Load<Texture2D>("npcs/Dialogue/prologue_8");

            mc_1 = OD.content.Load<Texture2D>("npcs/Dialogue/mc_1");
            mc_2 = OD.content.Load<Texture2D>("npcs/Dialogue/mc_2");
            mc_3 = OD.content.Load<Texture2D>("npcs/Dialogue/mc_3");
            mc_4 = OD.content.Load<Texture2D>("npcs/Dialogue/mc_4");
            mc_5 = OD.content.Load<Texture2D>("npcs/Dialogue/mc_5");
            mc_7 = OD.content.Load<Texture2D>("npcs/Dialogue/mc_6");

            friedrich_1 = OD.content.Load<Texture2D>("npcs/Dialogue/friedrich_1");

            theo_1 = OD.content.Load<Texture2D>("npcs/Dialogue/theo_1");
            theo_2 = OD.content.Load<Texture2D>("npcs/Dialogue/theo_2");

            clara_1 = OD.content.Load<Texture2D>("npcs/Dialogue/clara_1");
        }

        public void updateStory()
        {
            if(cnt == false)
            {
                if (InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    ProgressCounter = 1;
                    return;
                    
                }
                if (InputManager.IsKeyPressed(Keys.Enter) && ProgressCounter == 1)
                {
                    
                    ProgressCounter = 2;
                   // cnt = true;
                    
                }
            }



        }
        
        public void drawStory(SpriteBatch spritebatch)
        {
            if (Story.ProgressCounter == 0 && OD.lvlID == 1)
            {
                spritebatch.Draw(prologue_1, new Rectangle(0, 0, OD.ScreenWidth, OD.ScreenHeight), Color.White);
            }

            if (Story.ProgressCounter == 1 && OD.lvlID == 1)
            {
                spritebatch.Draw(prologue_2, new Rectangle(0, 0, OD.ScreenWidth, OD.ScreenHeight), Color.White);
            }
        }
    }
}
