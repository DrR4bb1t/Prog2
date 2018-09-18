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
        public enum itemState
        {
            notInInventar = 0,
            Inventar = 1,
            Equipped = 2
        }

        private itemState itemstate;
        public itemState getItemState() { return itemstate; }
        public void setItemState(itemState state) { itemstate = state; }


        private int itemDMGValue;
        private int itemArmourValue;

        private Rectangle itemRect;

        Texture2D item;

        public int ItemDMGValue { get; set; }
        public int ItemArmourValue { get; set; }

        public Items(int itemID, Vector2 pos, int itemstate)
        {
            itemRect = new Rectangle((int)pos.X, (int)pos.Y, item.Width, item.Height);

        }

        public void Update()
        {
            if(itemstate == itemState.Inventar)
            {
                
            }

            if(itemstate == itemState.Equipped)
            {
                
            }
        }

        public void LoadItemTextures()
        {

        }
    

        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}


