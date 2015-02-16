namespace OOP_Teamwork.Items.Consumables
{
    using System;
    using System.Linq;

    public abstract class Consumable : Item
    {
        // Fields
        // Constructors
        public Consumable(string name, int sellPrice) : base(name, sellPrice)
        {
            
        }

        // Properties
        // Methods
        public void Use() // Use the item
        {
            
        }
    }
}
