namespace The_Powerful_Game.Items
{
    using System.Text;
    using Validations;
    using Enums;

    public abstract class Item
    {
        private string name;
        private ItemType type;
        private int price;

        public Item(string name, ItemType type, int price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = ItemValidator.ItemNameValidating(value);
            }
        }

        public ItemType Type { get; set; }

        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = ItemValidator.PriceValidating(value);
            }
        }

        public abstract object Clone();

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendFormat("{0}, {1}, {2}", this.Name, this.Type, this.price);

            return toString.ToString();
        }
    }
}
