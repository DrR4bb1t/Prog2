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

        public PlayerUI()
        {
            playerLife = OD.content.Load<Texture2D>("Project_OD_Assets/HUD/HP/heart0001");
        }

        public void DrawUI(SpriteBatch spritebatch, Player player, Camera camera)
        {
            if (player.Hp > 60)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 100, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 170, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 240, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
            }
            if (player.Hp > 30)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 100, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 170, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
            }
            if (player.Hp > 0)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 100, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
            }
        }
    }
}