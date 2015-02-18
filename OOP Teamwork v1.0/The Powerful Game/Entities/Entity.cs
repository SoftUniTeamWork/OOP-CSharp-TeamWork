using System;
using System.Text;
using Entities.Chooses;
using Validations;

namespace The_Powerful_Game.Entities
{
    public abstract class Entity
    {
        // Private Fields
        private string name;
        private int hitPoints;
        private int armor;
        private int entityDamage;
        private double attackSpeed;

        /// <summary>
        /// Constructor for entities
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="hitPts">Health points</param>
        /// <param name="armor">Armor</param>
        /// <param name="entityDamage">Base damage</param>
        /// <param name="attackSpeed">Attack speed</param>
        public Entity(string name, int hitPts, int armor, int entityDamage, double attackSpeed)
        {
            this.Name = name;
            this.HitPoints = hitPts;
            this.Armor = armor;
            this.EntityDamage = entityDamage;
            this.AttackSpeed = attackSpeed;
        }

        // Properties
        public virtual string Name
        {
            get { return this.name; }
            set { this.name = EntityValidator.NameValidating(value); }
        }

        public virtual int HitPoints
        {
            get { return this.hitPoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Hit points cannot be negative number.");
                }
                this.hitPoints = value;
            }
        }

        public virtual int Armor
        {
            get { return this.armor; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Armor cannot be negative number.");
                }
                this.armor = value;
            }
        }
        public int EntityDamage
        {
            get { return this.entityDamage; }
            set { this.entityDamage = EntityValidator.DamageValidating(value); }
        }

        public double AttackSpeed
        {
            get { return this.attackSpeed; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Attack speed cannot be less than 0,0 sec.");
                }
                this.attackSpeed = value;
            }
        }

        /// <summary>
        /// Converts Entity to string.
        /// </summary>
        /// <returns>By default returns Enemy name</returns>
        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendLine("Entity with name " + this.name);

            return toString.ToString();
        }

        /// <summary>
        /// Method for calculating the damage to be dealt.
        /// </summary>
        /// <returns>Returns a number in range: from 80% to 120% of Base damage.</returns>
        protected virtual int CalcDamage()
        {
            Random getDamage = new Random();
            int diff = (int)Math.Round(EntityDamage / 10.0); // Difference between min and max damage
            int minDmgFormula = (EntityDamage - diff); // Min damage
            int maxDmgFormula = (EntityDamage + diff); // Max damage
            int damageDone = getDamage.Next(minDmgFormula, maxDmgFormula); // Random number between min and max damage

            if (CalcCritChance() == true)
            {
                damageDone = damageDone * 2;
            }

            return damageDone;
        }

        public bool CalcCritChance()
        {
            Random getChance = new Random();
            bool isCrit = false;
            int chance = getChance.Next(1, 100);
            if (chance > 85)
            {
                isCrit = true;
            }
            return isCrit;
        }
        // Attack method takes target and damage as parameters.
        public void Attack(Entity target, int damage)
        {
            int damageDealt = damage - target.Armor; // Damage dealth will be the damage of the attacker - armor value of attacked
            target.HitPoints -= damageDealt; // Reduces target HP by "damageDealt"
        }
    }
}