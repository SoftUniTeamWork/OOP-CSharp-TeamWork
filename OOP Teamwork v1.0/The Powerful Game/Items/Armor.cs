namespace The_Powerful_Game.Items
{
    using The_Powerful_Game.Contracts;
    using The_Powerful_Game.Enums;

    public class Armor : GearItem
    {
        public Armor(string name, ItemType type, int price, int str, int intelect, int agi, int armor)
            : base(name, type, price, str, intelect, agi)
        {
            this.ArmorModifier = armor;
        }

        public int ArmorModifier { get; set; }

        public override object Clone()
        {
            throw new System.NotImplementedException();

        }
    }
}
