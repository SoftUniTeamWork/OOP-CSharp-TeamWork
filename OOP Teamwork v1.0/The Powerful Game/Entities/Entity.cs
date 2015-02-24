using System.Windows.Forms;

namespace The_Powerful_Game.Entities
{
    using System;
    using System.Text;
    using Contracts;
    using System.Windows.Controls;
    using The_Powerful_Game.Validations;

    public abstract class Entity : IUpdatable, IRenderable
    {
        private string name;
        private AttributePair healthPoints;
        private int armorPoints;
        private int damage;
        private int defense;
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

        public int Damage
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

        public virtual void ProcessDamageTaken(int damage)
        {
            this.HealthPoints = this.HealthPoints.Decrease(damage - this.ArmorPoints);
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendLine("Entity with name " + this.name);

            return toString.ToString();
        }

        //                                          DO NOT DELETE!!!
        //protected virtual int CalcDamage()
        //{
        //    Random getDamage = new Random();
        //    int diff = (int)Math.Round(Damage / 10.0); // Difference between min and max damage
        //    int minDmgFormula = (Damage - diff); // Min damage
        //    int maxDmgFormula = (Damage + diff); // Max damage
        //    int damageDone = getDamage.Next(minDmgFormula, maxDmgFormula); // Random number between min and max damage

        //    if (CalcCritChance() == true)
        //    {
        //        damageDone = damageDone * 2;
        //    }

        //    return damageDone;
        //}

        //public bool CalcCritChance()
        //{
        //    Random getChance = new Random();
        //    bool isCrit = false;
        //    int chance = getChance.Next(1, 100);
        //    if (chance > 85)
        //    {
        //        isCrit = true;
        //    }
        //    return isCrit;
        //}

        //public void Attack(Entity target, int damage)
        //{
        //    int damageDealt = damage - target.ArmorPoints; // Damage dealth will be the damage of the attacker - armorPoints value of attacked
        //    target.healthPoints -= damageDealt; // Reduces target HP by "damageDealt"
        //}
    }
}