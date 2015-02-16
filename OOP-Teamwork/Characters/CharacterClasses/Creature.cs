namespace OOP_Teamwork.Models
{
    using OOP_Teamwork.Models.CharacterClasses;
    using OOP_Teamwork.Contracts;

    public abstract class Character : ICreature
    {
        //Fields and Properties

        public AttributePair HitPoints;
        public AttributePair Energy;
        public AttributePair Stamina;
        public AttributePair Rage;

        protected int strength;  //shows if the hero is strong enough to wear a specific weapon
        protected int agility;  //shows if the hero is agile enough to use specific weapon
        protected int inteligence; // shows if the hero is intelligent enough to use a specific spell

        protected bool inCombat;

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

        public Character(int strength, int inteligence, int agility)
        {
            this.Inteligence = inteligence;
            this.Strength = strength;
            this.Agility = agility;

            this.HitPoints = new AttributePair();
            this.Rage = new AttributePair();
            this.Energy = new AttributePair();
        }
    }
}
    