namespace The_Powerful_Game.Items
{
    using The_Powerful_Game.Enums;
    using The_Powerful_Game.Contracts;

    public abstract class GearItem : Item, IEquipable
    {
        protected GearItem(string name, ItemType type, int price, int str, int intelect, int agi)
            : base(name, type, price)
        {
            this.StrengthModifier = str;
            this.IntelectModifier = intelect;
            this.AgilityModifier = agi;
        }

        public int StrengthModifier { get; set; }

        public int IntelectModifier { get; set; }

        public int AgilityModifier { get; set; }
    }
}
