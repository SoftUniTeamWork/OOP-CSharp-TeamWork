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
