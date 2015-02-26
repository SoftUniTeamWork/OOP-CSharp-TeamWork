namespace The_Powerful_Game.Items
{
    using The_Powerful_Game.Contracts;
    using The_Powerful_Game.Enums;

    public abstract class Consumable : Item, IConsumable
    {
        protected Consumable(string name, ItemType type, int price, int consumptionValue)
            : base(name, type, price)
        {
            this.ConsumptionValue = consumptionValue;
        }

        public int ConsumptionValue { get; set; }

        public abstract void Consume();
    }
}
