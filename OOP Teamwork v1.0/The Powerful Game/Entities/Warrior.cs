using The_Powerful_Game.Contracts;

namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Chooses;
    using System.Windows;
    using The_Powerful_Game.CoreLogic;

    public class Warrior : Character
    {
        public Warrior(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image img, int strength, int inteligence, int agility, int resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, img, strength, inteligence, agility, resourcePoints, resourceType)
        {
        }

        public string Attack(Enemy enemy)
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 10);

            string combatLogResult = "";

            switch (fightCase)
            {
                case 1:
                case 2:
                    // Deal 100% damage
                    this.ProcessDamageTaken(this.Damage);
                    combatLogResult = "You deal " + this.Damage + " damage.\n";

                    break;
                case 3:
                case 4:
                    // Deal 120% damage
                    this.ProcessDamageTaken((int)Math.Round(this.Damage * 6 / 5.0));
                    combatLogResult = "You strike for " + this.Damage + " damage.\n";
                    break;
                case 5:
                case 6:
                    // Deal 80% damage

                    this.ProcessDamageTaken((int)Math.Round(this.Damage * 4 / 5.0));
                    combatLogResult = "You hit for " + this.Damage + " damage.\n";
                    break;
                case 7:
                    // Deal Critical 200% damage
                    this.ProcessDamageTaken(this.Damage * 2);
                    combatLogResult = "You attack with a massive blow for " + this.Damage + " damage.\n";
                    break;
                case 8:
                    // Miss
                    combatLogResult = "You miss your enemy.\n";
                    break;
                case 9:
                    // Stun for 1 turn and 50% damage
                    this.ProcessDamageTaken(this.Damage / 2);
                    combatLogResult = "With a fierce strike you deal " + this.Damage + " damage and stun your opponent for 1 round.\n";
                    break;
                case 10:
                    // 
                    break;
            }

            return combatLogResult;
        }
    }
}
