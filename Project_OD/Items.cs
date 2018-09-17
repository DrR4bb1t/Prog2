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
        Entity entity;

        public  enum itemState
        {
            OnGround,
            Inventar,
            Equipped,
        }

        private static itemState itemstate = itemState.OnGround;
        public static itemState getItemState() { return itemstate; }
        public static void setItemState(itemState state) { itemstate = state; }

        private Texture2D item;

        private int itemDMGValue;
        private int itemArmourValue;

        private Vector2 playerPos;

        private Rectangle playerRect;
        private Rectangle itemRect;

        private bool inInventar = false;
        private bool isEquipped = false;

        public int ItemDMGValue { get; set; }
        public int ItemArmourValue { get; set; }

        public Items(int itemID, Vector2 pos, state)
        {
            switch(itemstate)
            {
                case itemState.OnGround:
                    {
                        inInventar = false;
                        isEquipped = false;
                    }
                    break;
                case itemState.Inventar:
                    {
                        inInventar = true;
                        isEquipped = false;
                    }
                    break;
                case itemState.Equipped:
                    {
                        inInventar = false;
                        isEquipped = true;
                    }
                    break;

            }

            ItemDMGValue = itemDMGValue;
            ItemArmourValue = itemArmourValue;
            ItemDMGValue = itemDMGValue;
            ItemArmourValue = itemArmourValue;

            itemRect = new Rectangle((int)pos.X, (int)pos.Y, item.Width, item.Height);
            playerPos = new Vector2(10f, 200f);
            playerRect = new Rectangle((int)playerPos.X, (int)playerPos.Y, 10, 10);
        }

        public void Update()
        {
            if(itemRect.Intersects(playerRect) && InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.E))
            {
                inInventar = true;

            }

            if(inInventar == true && InputManager.GetMouseBoundaries(true).Intersects(itemRect))
            {
                if(InputManager.GetIsMouseButtonDown(InputManager.MouseButton.LeftButton, true))
                {
                    isEquipped = true;
                    if(isEquipped == true)
                    {
                        entity.Hp = entity.Hp + ItemArmourValue;
                        entity.Atk = entity.Atk + ItemDMGValue;
                    }
                }
            }
        }


        public void Draw(SpriteBatch spritebatch)
        {
         
        }
    }
}
