using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Project_OD
{
    public class Items
    {

        Player player;
        
        public enum itemState
        {
            notInInventar = 0,
            Inventar = 1,
            Equipped = 2
        }


        private itemState itemstate = itemState.notInInventar;
        public itemState getItemState() { return itemstate; }
        public void setItemState(itemState state) { itemstate = state; }


        private int itemDMGValue;
        private int itemArmourValue;

        private Rectangle itemRect;

        public int ItemDMGValue { get; set; }
        public int ItemArmourValue { get; set; }

        public Items(Texture2D texture, Vector2 pos, int state)
        {
            //explicit casting
            itemstate = (itemState) state;
            itemRect = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);

        }

        public void Update()
        {
            if (itemstate == itemState.Inventar)
            {
                if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(itemRect))
                {
                    setItemState(itemState.Equipped);
                }
                else if(itemstate == itemState.Equipped && InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(itemRect))
                {
                    this.player.Hp -= itemArmourValue;
                    this.player.ArmorValue -= itemDMGValue;
                }
            }
            else if (itemstate == itemState.Equipped)
            {
                this.player.Hp += itemArmourValue;
                this.player.ArmorValue += itemDMGValue;
            }
            if (itemstate == itemState.notInInventar)
            {
                if (InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true) && InputManager.GetMouseBoundaries(true).Intersects(itemRect))
                {
                    setItemState(itemState.Inventar);
                }
                else getItemState();
            }
        }

        public void LoadItemTextures()
        {
           // item = OD.content.Load<Texture2D>("");
        }
    
        /*
        public void Draw(SpriteBatch spriteBatch, int DMG_Value, int ARMOUR_Value)
        {
            
            this.itemDMGValue = DMG_Value;
            this.itemArmourValue = ARMOUR_Value;
            spriteBatch.Draw(button, pos, Color.White);
            
        }
        */
    }
}


