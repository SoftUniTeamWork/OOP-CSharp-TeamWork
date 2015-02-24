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

        public override string Attack(Enemy enemy)        {
            Random fightSituation = new Random();
            
            int fightCase = fightSituation.Next(1, 101);

            string combatLogResult = "";

            
            // Passive - 20% more damage with normal attacks
            int normalAttackDamage = (int)Math.Round(Damage * 6 / 5.0);

            if (fightCase <= 30)
            {

                // Deal 100% damage
                this.ProcessDamageTaken(normalAttackDamage);
                combatLogResult = "You deal " + normalAttackDamage + " damage.\n";
            }
            else if (fightCase > 30 && fightCase <= 55)
            {
                // Deal 120% damage
                this.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 6 / 5.0));
                combatLogResult = "You strike for " + (int)Math.Round(normalAttackDamage * 6 / 5.0) + " damage.\n";
            }
            else if (fightCase > 55 && fightCase <= 80)
            {
                // Deal 80% damage
                this.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 4 / 5.0));
                combatLogResult = "You hit for " + (int)Math.Round(normalAttackDamage * 4 / 5.0) + " damage.\n";
            }
            else if (fightCase > 80 && fightCase <= 90)
            {
                // Stun for 1 turn and 50% damage
                this.ProcessDamageTaken(normalAttackDamage / 2);
                combatLogResult = "With a fierce strike you deal " + normalAttackDamage / 2 + " damage and stun your opponent for 1 round.\n";
            }
            else if (fightCase > 90 && fightCase <= 95) 
            {
                // Deal Critical 150% damage
                this.ProcessDamageTaken((int)Math.Round(normalAttackDamage * 3 / 2.0));
                combatLogResult = "You attack with a massive blow for " + normalAttackDamage * 3 / 2.0 + " damage.\n";
            }
            else if (fightCase > 95)
            {
                // Miss
                combatLogResult = "You miss your enemy.\n";
            }

            return combatLogResult;
        }

        internal override string Spell(Enemy enemy)
        {
            Abillity courage = new Abillity("Mortal Strike", 20, 0, this.Damage * 2);
            
            string combatLogResult = courage.ApplyOffensiveEffect(enemy);
            

            return combatLogResult;
        }
    }
}
