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
        Texture2D wSkillActive;
        Texture2D wSkillInActive;
        Texture2D eSkillActive;
        Texture2D eSkillInActive;
        Texture2D rSkillActive;
        Texture2D rSkillInActive;
        Texture2D tSkillActive;
        Texture2D tSkillInActive;

        public PlayerUI()
        {
            playerLife = OD.content.Load<Texture2D>("Project_OD_Assets/HUD/HP/heart0001");
            playerSkillBar = OD.content.Load<Texture2D>("Project_OD_Assets/HUD/Skillbar");

            wSkillActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/wind-grasp-air-3");
            wSkillInActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/wind-grasp-air-3-cooldown");
            eSkillActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/enchant-orange-3");
            eSkillInActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/enchant-orange-3-cooldown");
            rSkillActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/wild-orange-3");
            rSkillInActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/wild-orange-3-cooldown");
            tSkillActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/runes-orange-3");
            tSkillInActive = OD.content.Load<Texture2D>("Project_OD_Assets/Entity_Assets/Skill_Icon/Pred/runes-orange-3-cooldown");
        }

        public void DrawUI(SpriteBatch spritebatch, Player player, Camera camera)
        {
            spritebatch.Draw(playerSkillBar, new Rectangle((int)camera.getPosition.X - 25, (int)camera.getPosition.Y + 830, playerSkillBar.Width, playerSkillBar.Height), Color.White);
                if(player.getWCooldown == false)
                {
                spritebatch.Draw(wSkillActive, new Rectangle((int)camera.getPosition.X + 552, (int)camera.getPosition.Y + 861, wSkillActive.Width, wSkillActive.Height), Color.White);
                }
                else spritebatch.Draw(wSkillInActive, new Rectangle((int)camera.getPosition.X + 552, (int)camera.getPosition.Y + 861, wSkillInActive.Width, wSkillInActive.Height), Color.White);

                if(player.getECooldown == false)
                {
                spritebatch.Draw(eSkillActive, new Rectangle((int)camera.getPosition.X + 638, (int)camera.getPosition.Y + 861, eSkillActive.Width, eSkillActive.Height), Color.White);
                }
                else spritebatch.Draw(eSkillInActive, new Rectangle((int)camera.getPosition.X + 638, (int)camera.getPosition.Y + 861, eSkillInActive.Width, eSkillInActive.Height), Color.White);

                if(player.getRCooldown == false)
                {
                spritebatch.Draw(rSkillActive, new Rectangle((int)camera.getPosition.X + 728, (int)camera.getPosition.Y + 861, rSkillActive.Width, rSkillActive.Height), Color.White);
                }
                else spritebatch.Draw(rSkillInActive, new Rectangle((int)camera.getPosition.X + 728, (int)camera.getPosition.Y + 861, rSkillInActive.Width, rSkillInActive.Height), Color.White);

                if (player.getTCooldown == false)
                {
                spritebatch.Draw(tSkillActive, new Rectangle((int)camera.getPosition.X + 813, (int)camera.getPosition.Y + 861, rSkillActive.Width, rSkillActive.Height), Color.White);
                }
                else spritebatch.Draw(tSkillInActive, new Rectangle((int)camera.getPosition.X + 813, (int)camera.getPosition.Y + 861, tSkillInActive.Width, tSkillInActive.Height), Color.White);

            if (player.Hp > 60)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 150, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 220, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 290, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
            }
            else if (player.Hp > 30)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 150, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 220, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
            }
            else if (player.Hp > 0)
            {
                spritebatch.Draw(playerLife, new Rectangle((int)camera.getPosition.X + 150, (int)camera.getPosition.Y + 870, 50, 50), Color.White);
            }
        }
    }
}