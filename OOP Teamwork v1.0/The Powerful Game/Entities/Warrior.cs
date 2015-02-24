using The_Powerful_Game.Contracts;

namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using Chooses;
    using System.Windows;

    public class Warrior : Character
    {
        public Warrior(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image img, int strength, int inteligence, int agility, AttributePair resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, img, strength, inteligence, agility, resourcePoints, resourceType)
        {
            // Doubles player damage for the next attack.
            this.offensiveAbillity = new Abillity("God Strength", 50, this.Damage);
            // Increases player's armour points by 50%.
            this.defensiveAbillity = new Abillity("Taunt", 40, this.ArmorPoints / 2);
        }

        public override string Attack(Enemy enemy)
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 10);

            string combatLogResult = "";

            switch (fightCase)
            {
                case 1:
                case 2:
                    // Deal 100% damage
                    enemy.ProcessDamageTaken(this.Damage);
                    combatLogResult = "You deal " + this.Damage + " damage.\n";

                    break;
                case 3:
                case 4:
                    // Deal 120% damage
                    enemy.ProcessDamageTaken((int)Math.Round(this.Damage * 6 / 5.0));
                    combatLogResult = "You strike for " + this.Damage + " damage.\n";
                    break;
                case 5:
                case 6:
                    // Deal 80% damage

                    enemy.ProcessDamageTaken((int)Math.Round(this.Damage * 4 / 5.0));
                    combatLogResult = "You hit for " + this.Damage + " damage.\n";
                    break;
                case 7:
                    // Deal Critical 200% damage
                    enemy.ProcessDamageTaken(this.Damage * 2);
                    combatLogResult = "You attack with a massive blow for " + this.Damage + " damage.\n";
                    break;
                case 8:
                    // Miss
                    combatLogResult = "You miss your enemy.\n";
                    break;
                case 9:
                    // Stun for 1 turn and 50% damage
                    enemy.ProcessDamageTaken(this.Damage / 2);
                    combatLogResult = "With a fierce strike you deal " + this.Damage + " damage and stun your opponent for 1 round.\n";
                    break;
                case 10:
                    // 
                    break;
            }

            this.GenerateRage();
            return combatLogResult;
        }

        public override string CastOffensiveSpell(Enemy enemy)
        {
            string combatLogResult = "";
            if (this.ResourcePoints.CurrentValue >= this.offensiveAbillity.Cost)
            {
                this.ResourcePoints = this.ResourcePoints.Decrease(this.offensiveAbillity.Cost);
                enemy.ProcessDamageTaken(this.Damage + this.offensiveAbillity.EffectValue);
                combatLogResult = string.Format("You strike with the Gods' strength for {0}.\n", this.Damage + this.offensiveAbillity.EffectValue);
            }
            else
            {
                MessageBox.Show("Not enough resources!");
            }
            return combatLogResult;
        }

        public override string CastDeffensiveSpell(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void GenerateRage()
        {
            this.ResourcePoints = this.ResourcePoints.Increase(10);
        }
    }
}
