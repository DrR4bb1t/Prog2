using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    class Itemlist
    {
        private List<Items> itemlist = new List<Items>() { };
        public Itemlist(params Items[] items)
        {
            foreach (var item in items)
            {
                itemlist.Add(item);
            }
        }
        public void ChangeState(int itemId,int state)
        {
            var obj = itemlist.FirstOrDefault(Items => Items.id == itemId);
            if (obj != null)
            {
                obj.setItemState((Items.itemState) state);
                Console.WriteLine("Changed Itemstate to: {0}", state);
            }
        }
    }
}
