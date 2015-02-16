using OOP_Teamwork.Contracts;

namespace OOP_Teamwork.Characters
{


    public abstract class Character : ICreature
    {
        // Fields
        public Attribute HitPoints;
        public Attribute Energy;
        public Attribute Stamina;
        public Attribute Rage;

        private int strength;  //shows if the hero is strong enough to wear a specific weapon
        private int agility;  //shows if the hero is agile enough to use specific weapon
        private int inteligence; // shows if the hero is intelligent enough to use a specific spell

        protected bool inCombat;

        // Constructors
        public Character(int strength, int inteligence, int agility)
        {
            this.Inteligence = inteligence;
            this.Strength = strength;
            this.Agility = agility;

            this.HitPoints = new Attribute();
            this.Rage = new Attribute();
            this.Energy = new Attribute();
        }

        // Properties
        //the properties are virtual, so they can be overriden later
        public virtual int Strength 
        {
            get
            {
                return strength;
            }
            set
            {
                this.strength = value;
            }
        }

        public virtual int Agility
        {
            get
            {
                return this.agility;
            }
            set
            {
                this.agility = value;
            }
        }


        public virtual int Inteligence
        {
            get
            {
                return this.inteligence;
            }
            set
            {
                this.inteligence = value;
            }
        }
        // Methods
        //public abstract string Name { get; set; }

        //public abstract double HealthPoints { get; set; }

        //public abstract double ManaPoints { get; set; }

    }
}

