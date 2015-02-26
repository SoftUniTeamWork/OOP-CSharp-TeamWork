namespace The_Powerful_Game.Entities
{
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Collections.Generic;   
    using The_Powerful_Game.Enums;
    using The_Powerful_Game.Items;
    using The_Powerful_Game.Contracts;
    using The_Powerful_Game.CoreLogic;
    using The_Powerful_Game.Entities.Chooses;

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
        private int gold = 0;

        private AttributePair resourcePoints;
        private EntityResourceType resourceType;

        public readonly List<Item> Inventory = new List<Item>();

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

            this.EquipItem(new HealthPotion("Health Potion", ItemType.Consumable, 20, 100));
            this.EquipItem(new ResourcePotion("Resource Potion", ItemType.Consumable, 20, 75));
        }

        public int Strength
        {
            get { return this.strength + this.strengthModifier; }
            set { this.strength = value; }
        }

        public int Inteligence
        {
            get { return this.inteligence + this.inteligenceModifier; }
            set { this.inteligence = value; }
        }

        public int Agility
        {
            get { return this.agility + this.agilityModifier; }
            set { this.agility = value; }
        }

        public int Gold
        {
            get { return this.gold; }
            set { this.gold = value; }
        }

        public AttributePair ResourcePoints { get; internal set; }

        public EntityResourceType ResourceType { get; set; }

        public abstract bool DeffensiveBuff { get; set; }

        public abstract string Attack(Enemy enemy);

        public abstract string CastOffensiveSpell(Enemy enemy);

        public abstract string CastDeffensiveSpell(Enemy enemy);

        public abstract void RegenerateResource();

        public override void Update()
        {
            if (this.HealthPoints.CurrentValue == 0)
            {
                this.isAlive = false;
            }
            CollisionHandler.HandleMapObjectCollision(this);
            Move();
        }

        public override void Render()
        {
            Canvas.SetLeft(this.Image, this.X);
            Canvas.SetTop(this.Image, this.Y);
        }

        public void Move()
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                this.Y -= Constants.CharacterMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                this.Y += Constants.CharacterMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                this.X -= Constants.CharacterMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                this.X += Constants.CharacterMoveSpeed;
            }
        }

        public void EquipItem(Item item)
        {
            if (item != null)
            {
                this.Inventory.Add(item);
                if (item is GearItem)
                {
                    this.ApplyItemModifiers(item as GearItem);
                }
            }
        }

        public void ApplyItemModifiers(GearItem item)
        {
            if (item is Weapon)
            {
                this.Damage += (item as Weapon).DamageModifier;
            }
            else if (item is Armor)
            {
                this.ArmorPoints += (item as Armor).ArmorModifier;
            }
            this.Strength += item.StrengthModifier;
            this.Inteligence += item.IntelectModifier;
            this.Agility += item.AgilityModifier;
        }

        public void RevertItemModifiers(GearItem item)
        {
            if (item is Weapon)
            {
                this.Damage -= (item as Weapon).DamageModifier;
            }
            else if (item is Armor)
            {
                this.ArmorPoints -= (item as Armor).ArmorModifier;
            }
            this.Strength -= item.StrengthModifier;
            this.Inteligence -= item.IntelectModifier;
            this.Agility -= item.AgilityModifier;
        }

        public void SellItemToMerchant(Item item)
        {
            this.Inventory.Remove(item);
            if (item is GearItem)
            {
                this.RevertItemModifiers(item as GearItem);
            }
            
            this.Gold += item.Price;
            ItemList.EquipableItems.Add(item);
        }

        public string DrinkHealthPotion(HealthPotion healthPotion)
        {
            this.HealthPoints = this.HealthPoints.Increase(healthPotion.ConsumptionValue);
            this.Inventory.Remove(healthPotion);
            return "You drink a Health Potion. Your Health is now " + this.HealthPoints.CurrentValue + "\n";
        }

        public string DrinkResourcePotion(ResourcePotion resourcePotion)
        {
            this.ResourcePoints = this.ResourcePoints.Increase(resourcePotion.ConsumptionValue);
            this.Inventory.Remove(resourcePotion);
            return "You drink a Resource Potion. Your " + this.ResourceType
                + " Points are now " + this.ResourcePoints.CurrentValue + "\n";
        }

        public void Flee(Enemy enemy)
        {
            this.X = enemy.X - 50;
        }
    }
}
