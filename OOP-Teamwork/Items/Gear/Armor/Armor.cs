namespace OOP_Teamwork.Items.Gear.Armor
{
    public abstract class Armor : GearItem
    {
        // Fields
        private int armorValue;
        
        // Constructors
        protected Armor(string name, int sellPrice, int armorVal) 
            : base(name, sellPrice)
        {
            ArmorValue = armorVal;
        }

        // Properties
        public int ArmorValue
        {
            get { return armorValue; }
            set { armorValue = value; }
        }

        // Methods
        /// <summary>
        /// Equips player with item
        /// </summary>
        public override void Equip()
        {
            // player.Armor += this.ArmorValue;
        }
        /// <summary>
        /// Unequips player with item
        /// </summary>
        public override void Unequip()
        {
            // player.Armor -= this.ArmorValue;
        }
    }
}
