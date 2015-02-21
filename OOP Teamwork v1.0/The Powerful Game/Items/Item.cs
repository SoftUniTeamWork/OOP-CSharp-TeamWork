using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Powerful_Game.Items
{
    class Item
    {
        private string itemName;
        private int itemPrice;

        public Item(string name, int price)
        {
            this.ItemName = name;
            this.ItemPrice = price;
        }

        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
    }
}
