namespace The_Powerful_Game.Entities
{
    using System;
    using System.Text;
    using Contracts;
    using System.Windows.Controls;
    using Validations;

    public abstract class Entity : IUpdatable, IRenderable
    {
        private string name;
        private AttributePair healthPoints;
        private int armorPoints;
        protected int damage;
        private double attackSpeed;
        private Image image;

        public bool isAlive = true;

        public Entity(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image image)
        {
            this.Name = name;
            this.healthPoints = healthPoints;
            this.ArmorPoints = armorPoints;
            this.Damage = damage;
            this.Image = image;
            this.X = x;
            this.Y = y;
        }

        public virtual string Name
        {
            get { return this.name; }
            set
            {
                this.name = EntityValidator.NameValidating(value);
            }
        }

        public AttributePair HealthPoints
        {
            get { return this.healthPoints; }
            protected set { this.healthPoints = value; }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public virtual int ArmorPoints
        {
            get { return this.armorPoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Armor cannot be negative number.");
                }
                this.armorPoints = value;
            }
        }

        public virtual int Damage
        {
            get { return this.damage; }
            set { this.damage = EntityValidator.DamageValidating(value); }
        }

        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Entity image cannot be empty.");
                }
                this.image = value;
            }
        }

        public abstract void Update();

        public abstract void Render();

        public virtual int ProcessDamageTaken(int damage)
        {
            int balance = damage - this.ArmorPoints <= 0 ? 0 : damage - this.ArmorPoints;
            this.HealthPoints = this.HealthPoints.Decrease(balance);
            return balance;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendLine("Entity with name " + this.name);

            return toString.ToString();
        }
    }
}