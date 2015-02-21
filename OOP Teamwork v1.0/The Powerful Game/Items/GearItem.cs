using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Powerful_Game.Items
{
    class GearItem : Item
    {

        public GearItem(string name, int price) : base(name, price)
        {
        }
        public virtual void ApplyItemBonus() // Give some stats whenever gear is equiped
        {

        }

        public virtual void RemoveItemBonus() // Remove the stats
        {

        }
    }
}
