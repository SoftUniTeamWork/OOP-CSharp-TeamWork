namespace The_Powerful_Game.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using The_Powerful_Game.Items;

    public class Merchant : Entity
    {
        // List of Item`s You can buy
        private List<Item> itemsList;

        public Merchant(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image image, List<Item> products) 
            : base(name, x, y, healthPoints, armorPoints, damage, image)
        {
            this.ItemsList = ItemList.EquipableItems;
        }

        public List<Item> ItemsList 
        {
            get { return this.itemsList; } 
            set { this.itemsList = value; }
        }

        public void SellItemToPlayer(Item item, Character player)
        {
            this.ItemsList.Remove(item);
            player.Gold -= item.Price;
            player.Inventory.Add(item);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
