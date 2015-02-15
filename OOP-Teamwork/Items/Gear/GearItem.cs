namespace OOP_Teamwork.Items.Gear
{
    using System;
    using System.Linq;

    public abstract class GearItem : Item
    {
        // Fields
        // Constructors
        protected GearItem(string name, int sellPrice)
            : base(name, sellPrice)
        {
        }

        // Properties
        // Methods
        public virtual void Equip() // Give some stats whenever gear is equiped
        {

        }

        public virtual void Unequip() // Remove the stats
        {

        }
    }
}
