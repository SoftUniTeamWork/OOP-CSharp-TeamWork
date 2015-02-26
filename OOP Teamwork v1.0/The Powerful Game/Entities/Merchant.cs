using System;
using System.Collections.Generic;
using System.Windows.Controls;
using The_Powerful_Game.Items;

namespace The_Powerful_Game.Entities
{
    public class Merchant : Entity
    {
        // List of Item`s You can buy
        private List<Item> productsList;

        public Merchant(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image image, List<Item> products) 
            : base(name, x, y, healthPoints, armorPoints, damage, image)
        {
            this.ProductsList = products;
        }

        public List<Item> ProductsList 
        {
            get { return this.productsList; } 
            set { this.productsList = value; }
        }

        public void SellItemToPlayer(Item item, Character player)
        {
            ProductsList.Remove(item);
            player.Gold -= item.Price;
            player.Inventory.Add(item);
        }

        public void BuyItemFromPlayer(Item item, Character player)
        {
            player.Inventory.Remove(item);
            player.Gold += item.Price;
            ProductsList.Add(item);
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
