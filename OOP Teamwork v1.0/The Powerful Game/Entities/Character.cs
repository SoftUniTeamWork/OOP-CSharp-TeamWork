using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using The_Powerful_Game.Entities.Chooses;

namespace The_Powerful_Game.Entities
{
    public abstract class Character : Entity
    {
        private int strength;
        private int inteligence;
        private int agility;

        private int strengthModifier;
        private int inteligenceModifier;
        private int agilityModifier;

        private int level;
        private int experience;

        private int resourcePoints;
        private EntityResourceType resourceType;


        protected Character(string name, double x, double y, AttributePair healthPoints,
            int armorPoints, int damage, Image image, int strength, int inteligence, int agility, int resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, image)
        {
            this.Strength = strength;
            this.Inteligence = inteligence;
            this.Agility = agility;
            this.ResourcePoints = resourcePoints;
            this.ResourceType = resourceType;
        }

        public int Strength
        {
            get { return this.strength + this.strengthModifier; }
            set { this.strength = value; }
        }

        public int Inteligence
        {
            get { return this.inteligence + this.inteligenceModifier; }
            protected set { this.inteligence = value; }
        }


        public int Agility
        {
            get { return this.agility + this.agilityModifier; }
            set { this.agility = value; }
        }

        public int ResourcePoints { get; set; }

        public EntityResourceType ResourceType { get; set; }

        public int Level
        {
            get { return this.level; }
            protected set { this.level = value; }
        }

        public int Experience
        {
            get { return this.experience; }
            set { this.experience = value; }
        }

        internal string Attack(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        internal void Flee(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}
