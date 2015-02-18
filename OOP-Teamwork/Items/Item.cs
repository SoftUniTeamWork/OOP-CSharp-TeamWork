namespace OOP_Teamwork.Items
{
    public abstract class Item
    {
        // Fields
        private string name;
        private int sellPrice;

        // Constructors
        public Item(string name, int sellPrice)
        {
            Name = name;
            SellPrice = sellPrice;
        }

        // Properties
        public string Name { get; set; }
        public int SellPrice { get; set; }

        // Methods
    }
}
