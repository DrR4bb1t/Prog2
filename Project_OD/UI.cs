using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Project_OD
{

    public class PlayerUI
    {
        Texture2D playerLife;
        Texture2D playerSkillBar;

        public PlayerUI()
        {
            playerLife = OD.content.Load<Texture2D>("Project_OD_Assets/HUD/HP/heart0001");
            playerSkillBar = OD.content.Load<Texture2D>("Project_OD_Assets/HUD/Skillbar");
        }

        public void DrawUI(SpriteBatch spritebatch, Player player, Camera camera)
        {
            //spritebatch.Draw(playerSkillBar, new Rectangle((int)camera.getPosition.X + 300, (int)camera.getPosition.Y + 870, playerSkillBar.Width +100, playerSkillBar.Height +100), Color.White);
            if (player.Hp > 60)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 50, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 120, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 190, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
            }
            else if (player.Hp > 30)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 50, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 120, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
            }
            else if (player.Hp > 0)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 50, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
            }
        }
    }
}