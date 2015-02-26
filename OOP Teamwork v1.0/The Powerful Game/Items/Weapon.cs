namespace The_Powerful_Game.Items
{
    using The_Powerful_Game.Contracts;
    using The_Powerful_Game.Enums;

    public class Weapon : Item, IEquipable
    {
        public Weapon(string name, ItemType type, int price, int equipEffect)
            : base(name, type, price)
        {
            this.EquipEffect = equipEffect;
        }

        public int EquipEffect { get; set; }

        public override object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
