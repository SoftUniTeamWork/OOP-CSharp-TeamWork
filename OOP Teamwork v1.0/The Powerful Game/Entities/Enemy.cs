namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;

    public class Enemy : Entity
    {
        public Enemy(string name, double x, double y, int healthPoints, int armorPoints, int damage, Image img)
            : base(name, x, y, healthPoints, armorPoints, damage, img)
        {
        }

        public string Attack()
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 10);
            string combatLogResult = "";

            switch (fightCase)
            {
                case 1:
                case 2:
                    // Enemy deals 100% damage
                    ProcessDamageTaken(this.Damage);
                    combatLogResult = "The Enemy hits you, dealing " + this.Damage + " damage.\n";
                    break;
                case 3:
                case 4:
                    // Enemy deals 120% damage
                    this.Damage = (int)Math.Round(this.Damage * 6 / 5.0); // 120% dmg
                    ProcessDamageTaken(this.Damage);
                    combatLogResult = "The Enemy attacks you with relentless strike dealing " + this.Damage + " damage.\n";
                    break;
                case 5:
                case 6:
                    // Enemy deals 80% damage
                    this.Damage = (int)Math.Round(this.Damage * 4 / 5.0); // 80% dmg
                    ProcessDamageTaken(this.Damage);
                    combatLogResult = "The Enemy attack`s for " + this.Damage + " damage.\n";
                    break;
                case 7:
                    // Enemy crits for 200% damage
                    this.Damage = this.Damage * 2; // 200% dmg crit
                    ProcessDamageTaken(this.Damage);
                    combatLogResult = "The Enemy delivers a deadly strike for " + this.Damage + "damage.\n";
                    break;
                case 8:
                    // Enemy misses
                    combatLogResult = "You dodge your enemy`s attack.\n";
                    break;
                case 9:
                    // Enemy stuns you and deals 50% damage
                    this.Damage = (int)Math.Round(this.Damage / 2.0);
                    combatLogResult = "The enemy dashes you knocking you on the ground. You lose your turn and " + this.Damage + " Health Points.\n";
                    break;
                case 10:
                    // Enemy flees from battle droping an item behind
                    combatLogResult = "Your enemy has fled from the battle dropping a " + " behind.\n";
                    break;
            }

            return combatLogResult;
        }

        public override void Update()
        {
            if (this.HealthPoints == 0)
            {
                this.isAlive = false;
            }
        }

        public override void Render()
        {
            Canvas.SetLeft(this.Image, this.X);
            Canvas.SetTop(this.Image, this.Y);
        }
    }
}
