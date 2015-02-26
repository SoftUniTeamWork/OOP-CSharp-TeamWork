namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using Chooses;
    using System.Windows;

    public class Warrior : Character
    {
        public Warrior(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image img, int strength,
            int inteligence, int agility, AttributePair resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, img, strength, inteligence, agility, resourcePoints, resourceType)
        {
            // Doubles player damage for the next attack.
            this.offensiveAbillity = new Abillity("God Strength", 50, this.Damage);
            // Increases player's armour points by 50%.
            this.defensiveAbillity = new Abillity("Taunt", 40, this.ArmorPoints);
        }

        public override bool DeffensiveBuff { get; set; }

        public override string Attack(Enemy enemy)
        {
            Random fightSituation = new Random();

            int fightCase = fightSituation.Next(1, 101);

            string combatLogResult = "";

            // Passive - 20% more damage with normal attacks
            int normalAttackDamage = (int)Math.Round(Damage * 6 / 5.0);

            if (fightCase <= 30)
            {
                // Deal 100% damage
                int damage = enemy.ProcessDamageTaken(normalAttackDamage);
                combatLogResult = "You deal " + damage + " damage.\n";
            }
            else if (fightCase > 30 && fightCase <= 55)
            {
                // Deal 120% damage
                int damage = enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 6 / 5.0));
                combatLogResult = "You strike for " + damage + " damage.\n";
            }
            else if (fightCase > 55 && fightCase <= 80)
            {
                // Deal 80% damage
                int damage = enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 4 / 5.0));
                combatLogResult = "You hit for " + damage + " damage.\n";
            }
            else if (fightCase > 80 && fightCase <= 90)
            {
                // Stun for 1 turn and 50% damage
                int damage = enemy.ProcessDamageTaken(normalAttackDamage / 2);
                combatLogResult = "With a fierce strike you deal " + damage + " damage and stun your opponent for 1 round.\n";
            }
            else if (fightCase > 90 && fightCase <= 95)
            {
                // Deal Critical 150% damage
                int damage = enemy.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 3 / 2.0));
                combatLogResult = "You attack with a massive blow for " + damage + " damage.\n";
            }
            else if (fightCase > 95)
            {
                // Miss
                combatLogResult = "You miss your enemy.\n";
            }

            this.RegenerateResource();
            return combatLogResult;
        }

        public override string CastOffensiveSpell(Enemy enemy)
        {
            string combatLogResult = "";
            if (this.ResourcePoints.CurrentValue >= this.offensiveAbillity.Cost)
            {
                this.ResourcePoints = this.ResourcePoints.Decrease(this.offensiveAbillity.Cost);
                enemy.ProcessDamageTaken(this.Damage + this.offensiveAbillity.EffectValue);
                combatLogResult = string.Format("You strike with the {1} for {0}.\n",
                    this.Damage + this.offensiveAbillity.EffectValue, this.offensiveAbillity.Name);
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
                this.ArmorPoints += this.defensiveAbillity.EffectValue;
                this.DeffensiveBuff = true;
                combatLogResult = string.Format("Taunting the enemy grants you double armor points for their attack.\n");
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
            this.ResourcePoints = this.ResourcePoints.Increase(10);
        }
    }
}
