using System.Text;
using The_Powerful_Game.Validations;

namespace The_Powerful_Game.Items
{
    public abstract class Item
    {
        //protected List<Type> allowableClasses = new List<Type>();

        private string name;
        private string type;
        private int price;
        private int levelRequired;
        private bool isEquipped;

        public Item(string name, string type, int price, int levelRequired/*, params Type[] allowableClasses*/)
        {
            //foreach (Type t in allowableClasses)
            //    AllowableClasses.Add(t);

            this.Name = name;
            this.Type = type;
            this.Price = price;
            this.LevelRequired = levelRequired;
            isEquipped = false;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = ItemValidator.ItemNameValidating(value); }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = ItemValidator.ItemTypeValidating(value); }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = ItemValidator.PriceValidating(value); }
        }

        public int LevelRequired
        {
            get { return this.levelRequired; }
            set { this.levelRequired = ItemValidator.LevelRequired(value); }
        }

        public bool IsEquipped
        {
            get { return this.isEquipped; }
            protected set { this.isEquipped = value; }
        }

        public abstract object Clone();

        //public virtual bool CanEquip(Type characterType)
        //{
        //    return allowableClasses.Contains(characterType);
        //}

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendFormat("{0}, {1}, {2}, {3}, {4}, {5}", this.Name, this.Type, this.price, this.LevelRequired);

            return toString.ToString();
        }
    }
}
