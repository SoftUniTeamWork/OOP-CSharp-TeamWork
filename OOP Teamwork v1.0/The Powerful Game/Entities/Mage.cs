namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using Enums;
    using Validations;

    public class Mage : Character
    {
        public Mage(
            string name,
            double x,
            double y, 
            AttributePair healthPoints, 
            int armorPoints, 
            int damage,
            Image image,
            int strength,
            int inteligence, 
            int agility,
            AttributePair resourcePoints, 
            EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, image, strength, inteligence, agility, resourcePoints, resourceType)
        {
            // Deals 80 damage to the enemy
            this.offensiveAbillity = new Abillity("Frost Nova", 30, 70);

            // Absorbs 50 points of enemy damage using the players mana.
            this.defensiveAbillity = new Abillity("Mana Shield", 0, 50);
        }

        // Increase damage for every inteligence point you have
        public override int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = EntityValidator.DamageValidating(value + this.Inteligence);
            }
        }

        public override bool DeffensiveBuff { get; set; }

        public override string Attack(Enemy enemy)
        {
            Random fightSituation = new Random();

            int fightCase = fightSituation.Next(1, 101);

            string combatLogResult = string.Empty;

            // Passive - 10% chance to cast aditional offensive spell.
            int normalAttackDamage = this.Damage;
            if (fightCase <= 10)
            {
                enemy.ProcessDamageTaken(normalAttackDamage);
                combatLogResult = "You slam the enemy with a staff, dealing " + normalAttackDamage + " damage.\n";
                this.CastDeffensiveSpell(enemy);
            }
            else if (fightCase > 10 && fightCase <= 30)
            {
                // Deal 100% damage
                enemy.ProcessDamageTaken(normalAttackDamage);
                combatLogResult = "You slam the enemy with a staff, dealing " + normalAttackDamage + " damage.\n";
            }
            else if (fightCase > 30 && fightCase <= 55)
            {
                // Deal 120% damage
                enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 6 / 5.0));
                combatLogResult = "A fiery strike to the head for " + (int)Math.Round(normalAttackDamage * 6 / 5.0) + " damage.\n";
            }
            else if (fightCase > 55 && fightCase <= 80)
            {
                // Deal 80% damage
                enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 4 / 5.0));
                combatLogResult = "You make the ground beneath your enemy burn dealing " + (int)Math.Round(normalAttackDamage * 4 / 5.0) + " damage.\n";
            }
            else if (fightCase > 80 && fightCase <= 90)
            {
                // Stun for 1 turn and 50% damage
                enemy.ProcessDamageTaken(normalAttackDamage / 2);
                combatLogResult = "Freezing the enemy legs for " + normalAttackDamage / 2 + " damage and stun your opponent for 1 round.\n";
            }
            else if (fightCase > 90 && fightCase <= 95)
            {
                // Deal Critical 150% damage
                enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 3 / 2.0));
                combatLogResult = "A powerful wind fist smashes your enemy for " + normalAttackDamage * 3 / 2.0 + " damage.\n";
            }
            else if (fightCase > 95)
            {
                // Miss
                combatLogResult = "You miss your enemy.\n";
            }

            return combatLogResult;
        }

        public override string CastOffensiveSpell(Enemy enemy)
        {
            string combatLogResult = string.Empty;
            if (this.ResourcePoints.CurrentValue > this.offensiveAbillity.Cost)
            {
                this.ResourcePoints = this.ResourcePoints.Decrease(this.offensiveAbillity.Cost);
                enemy.ProcessDamageTaken(this.offensiveAbillity.EffectValue);
                combatLogResult = string.Format(
                    "You cast unescapable {0} freezing everything in its path and dealing {1}.\n",
                    this.offensiveAbillity.Name, 
                    this.offensiveAbillity.EffectValue);
            }
            else
            {
                MessageBox.Show(string.Format("Not enough {0} for {1}!", this.ResourceType.ToString(), this.offensiveAbillity.Name));
            }

            return combatLogResult;
        }

        public override string CastDeffensiveSpell(Enemy enemy)
        {
            string combatLogResult = string.Empty;
            if (this.ResourcePoints.CurrentValue > this.defensiveAbillity.Cost)
            {
                this.ResourcePoints = this.ResourcePoints.Decrease(this.defensiveAbillity.Cost);
                this.DeffensiveBuff = true;
                combatLogResult = string.Format("Your own mana shields you absorbing damage and restoring mana.\n");
            }
            else
            {
                MessageBox.Show(string.Format("Not enough {0} for {1}!", this.ResourceType.ToString(), this.defensiveAbillity.Name));
            }

            return combatLogResult;
        }

        public override void RegenerateResource()
        {
            this.ResourcePoints = this.ResourcePoints.Increase(70);
        }
    }
}