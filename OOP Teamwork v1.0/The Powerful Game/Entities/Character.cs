using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using The_Powerful_Game.Contracts;
using The_Powerful_Game.CoreLogic;
using The_Powerful_Game.Entities.Chooses;

namespace The_Powerful_Game.Entities
{
    public abstract class Character : Entity, IControllable
    {
        private int strength;
        private int inteligence;
        private int agility;

        private int strengthModifier;
        private int inteligenceModifier;
        private int agilityModifier;

        private int level;
        private int experience;

        private AttributePair resourcePoints;
        private EntityResourceType resourceType;

        protected Abillity offensiveAbillity;
        protected Abillity defensiveAbillity;

        protected Character(string name, double x, double y, AttributePair healthPoints,
            int armorPoints, int damage, Image image, int strength, int inteligence, int agility, AttributePair resourcePoints, EntityResourceType resourceType)
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

        public AttributePair ResourcePoints { get; protected set; }

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

        public abstract string Attack(Enemy enemy);

        public abstract string CastOffensiveSpell(Enemy enemy);

        public abstract string CastDeffensiveSpell(Enemy enemy);

        public override void Update()
        {
            if (this.HealthPoints.CurrentValue == 0)
            {
                this.isAlive = false;
            }
            Move();
        }

        public void Move()
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                this.Y -= Constants.PlayerMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                this.Y += Constants.PlayerMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                this.X -= Constants.PlayerMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                this.X += Constants.PlayerMoveSpeed;
            }
        }

        public override void Render()
        {
            Canvas.SetLeft(this.Image, this.X);
            Canvas.SetTop(this.Image, this.Y);
        }

        public void Flee(Enemy enemy)
        {
            this.X = enemy.X - 50;
        }
    }
}
