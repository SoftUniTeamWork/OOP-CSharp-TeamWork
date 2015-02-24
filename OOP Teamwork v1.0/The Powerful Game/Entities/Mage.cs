using System;
using System.Windows.Controls;
using The_Powerful_Game.Entities.Chooses;

namespace The_Powerful_Game.Entities
{
    public class Mage : Character
    {
        public Mage(string name, double x, double y, AttributePair healthPoints,
            int armorPoints, int damage, Image image, int strength,
            int inteligence, int agility, AttributePair resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, image,
            strength, inteligence, agility, resourcePoints, resourceType)
        {
            // Deals 70 damage to the enemy
            this.offensiveAbillity = new Abillity("Frost Nova", 60, 70);
            // Absorbs 50 points of enemy damage using the players mana.
            this.defensiveAbillity = new Abillity("Mana Shield", 20, 50);
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

            return combatLogResult;
        }

        public override string CastOffensiveSpell(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public override string CastDeffensiveSpell(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}