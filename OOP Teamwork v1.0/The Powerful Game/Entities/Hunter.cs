namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using The_Powerful_Game.Entities.Chooses;

    public class Hunter : Character
    {
        public Hunter(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image image, int strength, int inteligence, int agility, AttributePair resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, image, strength, inteligence, agility, resourcePoints, resourceType)
        {

            // Deals 80 damage to the enemy target.
            this.offensiveAbillity = new Abillity("Power Shot", 20, 80);
            // Grants the user 50 miss chance.
            this.defensiveAbillity = new Abillity("Avoidance", 30, 50);

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
                enemy.ProcessDamageTaken(Damage);
                combatLogResult = "You deal " + Damage + " damage.\n";
            }
            else if (fightCase > 25 && fightCase <= 50)
            {
                // Deal 120% damage
                enemy.ProcessDamageTaken((int)Math.Round(Damage * 6 / 5.0));
                combatLogResult = "You strike for " + (int)Math.Round(Damage * 6 / 5.0) + " damage.\n";
            }
            else if (fightCase > 50 && fightCase <= 75)
            {
                // Deal 80% damage
                enemy.ProcessDamageTaken((int)Math.Round(Damage * 4 / 5.0));
                combatLogResult = "You hit for " + (int)Math.Round(Damage * 4 / 5.0) + " damage.\n";
            }
            else if (fightCase > 75 && fightCase <= 85)
            {
                // Stun for 1 turn and 50% damage
                enemy.ProcessDamageTaken(Damage / 2);
                combatLogResult = "With a fierce strike you deal " + Damage / 2 + " damage and stun your opponent for 1 round.\n";
            }
            else if (fightCase > 85 && fightCase <= 95) // Passive - 10% critical strike chance (instead of 5%)
            {
                // Deal Critical 150% damage
                enemy.ProcessDamageTaken((int)Math.Round(Damage * 3 / 2.0));
                combatLogResult = "You attack with a massive blow for " + Damage * 3 / 2.0 + " damage.\n";
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
            throw new NotImplementedException();
        }

        public override string CastDeffensiveSpell(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}
