using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using The_Powerful_Game.Entities.Chooses;

namespace The_Powerful_Game.Entities
{
    public class Hunter : Character
    {
        public Hunter(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image image, int strength, int inteligence, int agility, int resourcePoints, EntityResourceType resourceType) : base(name, x, y, healthPoints, armorPoints, damage, image, strength, inteligence, agility, resourcePoints, resourceType)
        {
        }

        public override string Attack(Enemy enemy)
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 101);

            string combatLogResult = "";

            // Passive - 20% more damage with normal attacks
            int normalAttackDamage = Damage;

            if (fightCase <= 25)
            {
                // Deal 100% damage
                this.ProcessDamageTaken(Damage);
                combatLogResult = "You deal " + Damage + " damage.\n";
            }
            else if (fightCase > 25 && fightCase <= 50)
            {
                // Deal 120% damage
                this.ProcessDamageTaken((int)Math.Round(Damage * 6 / 5.0));
                combatLogResult = "You strike for " + (int)Math.Round(Damage * 6 / 5.0) + " damage.\n";
            }
            else if (fightCase > 50 && fightCase <= 75)
            {
                // Deal 80% damage
                this.ProcessDamageTaken((int)Math.Round(Damage * 4 / 5.0));
                combatLogResult = "You hit for " + (int)Math.Round(Damage * 4 / 5.0) + " damage.\n";
            }
            else if (fightCase > 75 && fightCase <= 85)
            {
                // Stun for 1 turn and 50% damage
                this.ProcessDamageTaken(Damage / 2);
                combatLogResult = "With a fierce strike you deal " + Damage / 2 + " damage and stun your opponent for 1 round.\n";
            }
            else if (fightCase > 85 && fightCase <= 95) // Passive - 10% critical strike chance (instead of 5%)
            {
                // Deal Critical 150% damage
                this.ProcessDamageTaken((int)Math.Round(Damage * 3 / 2.0));
                combatLogResult = "You attack with a massive blow for " + Damage * 3 / 2.0 + " damage.\n";
            }
            else if (fightCase > 95)
            {
                // Miss
                combatLogResult = "You miss your enemy.\n";
            }

            return combatLogResult;
        }

        internal override string Attack(Enemy enemy)
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

        internal override string Spell(Enemy enemy)
        {
            string combatLogResult = "";



            return combatLogResult;
        }
    }
}
