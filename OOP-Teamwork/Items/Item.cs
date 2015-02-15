namespace OOP_Teamwork.Items
{
    using System;
    using System.Linq;

    public abstract class Item
    {
        // Fields
        private string name;
        private int sellPrice;

        // Constructors
        public Item(string name, int sellPrice)
        {
            this.Name = name;
            this.SellPrice = sellPrice;
        }

        // Properties
        public string Name { get; set; }
        public int SellPrice { get; set; }

        // Methods
    }
}
