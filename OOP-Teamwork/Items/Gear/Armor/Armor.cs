namespace OOP_Teamwork.Items.Gear.Armor
{
    using System;
    using System.Linq;

    public abstract class Armor : GearItem
    {
        // Fields
        private int armorValue;
        
        // Constructors
        protected Armor(string name, int sellPrice, int armorVal) 
            : base(name, sellPrice)
        {
            this.ArmorValue = armorVal;
        }

        // Properties
        public int ArmorValue
        {
            get { return this.armorValue; }
            set { this.armorValue = value; }
        }

        // Methods
        public override void Equip()
        {
            // player.Armor += this.ArmorValue;
        }
        public override void Unequip()
        {
            // player.Armor -= this.ArmorValue;
        }
    }
}
