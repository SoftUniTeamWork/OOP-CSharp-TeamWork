using System.Text;
using The_Powerful_Game.Items.HandsCount;

namespace The_Powerful_Game.Items
{
    public class Weapon : Item
    {
        private Hands hands;
        private int damageValue;
        private int damageModifier;
        public Weapon(string name, string type, int price, int levelRequired, Hands hands, int damageValue, int damageModifier)
            : base(name, type, price, levelRequired)
        {
            this.Hands = hands;
            this.DamageValue = damageValue;
            this.damageModifier = damageModifier;
        }

        public Hands Hands
        {
            get { return this.hands; }
            set { this.hands = value; }
        }

        public int DamageValue
        {
            get { return this.damageValue; }
            set { this.damageValue = value; }
        }

        public int DamageModifier
        {
            get { return this.damageModifier; }
            set { this.damageModifier = value; }
        }

        public override object Clone()
        {
            return new Weapon(
                this.Name,
                this.Type,
                this.Price,
                this.LevelRequired,
                this.Hands,
                this.DamageValue,
                this.DamageModifier);
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendFormat("{0}, {1}, {2}, {3}",
                base.ToString(),
                this.Hands,
                this.DamageValue,
                this.DamageModifier);

            return toString.ToString();
        }
    }
}