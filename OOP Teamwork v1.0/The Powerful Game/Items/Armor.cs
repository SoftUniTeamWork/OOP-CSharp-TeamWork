using The_Powerful_Game.Items.Location;

namespace The_Powerful_Game.Items
{
    class Armor : Item
    {
        private ItemLocation location;
        private int defenseValue;
        private int defenseModifier;
        public Armor(string name, string type, int price, int levelRequired, ItemLocation location, int defenseValue, int defenseModifier)
            : base(name, type, price, levelRequired)
        {
            this.Location = location;
            this.DefenseValue = defenseValue;
            this.DefenseModifier = defenseModifier;
        }

        public ItemLocation Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public int DefenseValue
        {
            get { return this.defenseValue; }
            set { this.defenseModifier = value; }
        }

        public int DefenseModifier { get; set; }

        public override object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
