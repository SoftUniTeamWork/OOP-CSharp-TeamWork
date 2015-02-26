namespace The_Powerful_Game.Items
{
    using System;
    using The_Powerful_Game.Enums;

    public class ResourcePotion : Consumable
    {
        public ResourcePotion(string name, ItemType type, int price, int consumptionValue)
            : base(name, type, price, consumptionValue)
        {
        }

        public override void Consume()
        {
            throw new NotImplementedException();
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
