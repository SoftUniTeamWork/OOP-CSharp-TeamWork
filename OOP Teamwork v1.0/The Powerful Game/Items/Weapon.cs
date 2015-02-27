namespace The_Powerful_Game.Items
{
    using The_Powerful_Game.Enums;

    public class Weapon : GearItem
    {
        public Weapon(string name, ItemType type, int price, int str, int intelect, int agi, int damage)
            : base(name, type, price, str, intelect, agi)
        {
            this.DamageModifier += damage;
        }

        public int DamageModifier { get; set; }

        public override object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
