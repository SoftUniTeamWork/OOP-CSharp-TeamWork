namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using Enums;
    using Validations;

    public class Hunter : Character
    {
        public Hunter(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image image, int strength,
            int inteligence, int agility, AttributePair resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, image, strength, inteligence, agility, resourcePoints, resourceType)
        {
            // Deals 80 damage to the enemy target.
            this.offensiveAbillity = new Abillity("Power Shot", 40, 55);
            // Grants the user's enemy 100% miss chance.
            this.defensiveAbillity = new Abillity("Avoidance", 60, 50);
        }

        // Increase damage for every agility point you have
        public override int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = EntityValidator.DamageValidating(value + this.Agility);
            }
        }
        private int RegenerationCounter { get; set; }

        public override bool DeffensiveBuff { get; set; }

        public override string Attack(Enemy enemy)
        {
            Random fightSituation = new Random();

            int fightCase = fightSituation.Next(1, 101);

            string combatLogResult = "";

            // Passive - 10% more Critical Strike chance
            int normalAttackDamage = Damage;

            if (fightCase <= 25)
            {
                // Deal 100% damage
                enemy.ProcessDamageTaken(normalAttackDamage);
                combatLogResult = "You shot your enemy int the leg for " + normalAttackDamage + " damage.\n";
            }
            else if (fightCase > 25 && fightCase <= 35)
            {
                // Deal 120% damage
                enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 6 / 5.0));
                combatLogResult = "An arrow to the shoulder! " + (int)Math.Round(normalAttackDamage * 6 / 5.0) + " damage dealt.\n";
            }
            else if (fightCase > 35 && fightCase <= 50)
            {
                // Deal 80% damage
                enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 4 / 5.0));
                combatLogResult = "A smoothe close range attack for " + (int)Math.Round(normalAttackDamage * 4 / 5.0) + " damage.\n";
            }
            else if (fightCase > 50 && fightCase <= 70)
            {
                // Stun for 1 turn and 50% damage
                enemy.ProcessDamageTaken(normalAttackDamage / 2);
                combatLogResult = "With a fierce strike you deal " + normalAttackDamage / 2 + " damage and stun your opponent for 1 round.\n";
            }
            else if (fightCase > 70 && fightCase <= 95)
            {
                // Deal Critical 150% damage
                enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 3 / 2.0));
                combatLogResult = "You aim at your enemy chest for " + normalAttackDamage * 3 / 2.0 + " damage.\n";
            }
            else if (fightCase > 95)
            {
                // Miss
                combatLogResult = "You miss your enemy.\n";
            }

            this.RegenerationCounter++;
            this.RegenerateResource();
            return combatLogResult;
        }

        public override string CastOffensiveSpell(Enemy enemy)
        {
            string combatLogResult = "";
            if (this.ResourcePoints.CurrentValue >= this.offensiveAbillity.Cost)
            {
                this.ResourcePoints = this.ResourcePoints.Decrease(this.offensiveAbillity.Cost);
                enemy.ProcessDamageTaken(this.offensiveAbillity.EffectValue);
                combatLogResult = string.Format("You shoot a {1} through your enemy for {0}.\n",
                    this.Damage + this.offensiveAbillity.EffectValue, this.offensiveAbillity.Name);
                this.RegenerationCounter++;
            }
            else
            {
                MessageBox.Show(string.Format("Not enough {0} for {1}!", this.ResourceType.ToString(), this.offensiveAbillity.Name));
            }

            this.RegenerateResource();
            return combatLogResult;
        }

        public override string CastDeffensiveSpell(Enemy enemy)
        {
            string combatLogResult = "";
            if (this.ResourcePoints.CurrentValue >= this.defensiveAbillity.Cost)
            {
                this.ResourcePoints = this.ResourcePoints.Decrease(this.defensiveAbillity.Cost);
                this.DeffensiveBuff = true;
                this.RegenerationCounter++;
                combatLogResult = this.Attack(enemy);
            }
            else
            {
                MessageBox.Show(string.Format("Not enough {0} for {1}!", this.ResourceType.ToString(), this.defensiveAbillity.Name));
            }

            this.RegenerateResource();
            return combatLogResult;
        }

        public override void RegenerateResource()
        {
            if (this.RegenerationCounter % 3 == 0)
            {
                this.ResourcePoints = this.ResourcePoints.Increase(25);
            }
        }
    }
}
