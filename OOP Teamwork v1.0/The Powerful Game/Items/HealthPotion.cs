namespace The_Powerful_Game.Items
{
    using Enums;

    public class HealthPotion : Consumable
    {
        public HealthPotion(string name, ItemType type, int price, int consumptionValue)
            : base(name, type, price, consumptionValue)
        {
        }

        public override void Consume()
        {
            throw new System.NotImplementedException();
        }

        public override object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
