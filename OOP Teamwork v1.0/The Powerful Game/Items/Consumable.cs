namespace The_Powerful_Game.Items
{
    using Contracts;
    using Enums;

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
