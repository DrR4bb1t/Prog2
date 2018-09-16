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
        private Texture2D item;

        private int itemDMGValue;
        private int itemArmourValue;

        private bool inIventar = false;

        public int ItemDMGValue { get; set; }
        public int ItemArmourValue { get; set; }

        public Items(int itemID, Vector2 pos)
        {
            //itemid
            ItemDMGValue = itemDMGValue;
            ItemArmourValue = itemArmourValue;
            ItemDMGValue = itemDMGValue;
            ItemArmourValue = itemArmourValue;

            Rectangle itemRect = new Rectangle((int)pos.X, (int)pos.Y, item.Width, item.Height);
        }

        public void Update()
        {
           //if item rect intersect with player position and button is pressed
           //in inventar is true

            //if in inventar and button is pressed
            // is equipped is true
            //and values get added to the players current stats
        }

        public void Draw()
        {

        }
    }
}
