using System.Windows;
using The_Powerful_Game.Menu;

namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;

    public class Enemy : Entity
    {
        public Enemy(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image img)
            : base(name, x, y, healthPoints, armorPoints, damage, img)
        {
        }

        public string Attack()
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 10);
            string combatLogResult = "";

            if (fightCase <= 30)
            {
                // Enemy deals 100% damage
                ProcessDamageTaken(this.Damage);
                combatLogResult = "The Enemy hits you, dealing " + this.Damage + " damage.\n";
            }
            else if (fightCase > 30 && fightCase <= 55)
            {
                // Enemy deals 120% damage
                ProcessDamageTaken((int)Math.Round(this.Damage * 6 / 5.0));
                combatLogResult = "The Enemy attacks you with relentless strike dealing " + this.Damage + " damage.\n";
            }
            else if (fightCase > 55 && fightCase <= 80)
            {
                // Enemy deals 80% damage
                ProcessDamageTaken((int)Math.Round(this.Damage * 4 / 5.0));
                combatLogResult = "The Enemy attack`s for " + this.Damage + " damage.\n";
            }
            else if (fightCase > 80 && fightCase <= 90)
            {
                // Enemy stuns you and deals 50% damage
                ProcessDamageTaken((int)Math.Round(this.Damage / 2.0));
                combatLogResult = "The enemy dashes you knocking you on the ground. You lose your turn and " + this.Damage + " Health Points.\n";
            }
            else if (fightCase > 90 && fightCase <= 94)
            {
                // Enemy crits for 150% damage
                ProcessDamageTaken((int)Math.Round(this.Damage * 3 / 2.0));
                combatLogResult = "The Enemy delivers a deadly strike for " + this.Damage + "damage.\n";
            }
            else if (fightCase > 94 && fightCase <= 99)
            {
                // Enemy misses
                combatLogResult = "You dodge your enemy`s attack.\n";
            }
            else if (fightCase > 99)
            {
                // Enemy flees from battle droping an item behind
                this.isAlive = false;
                combatLogResult = "Your enemy has fled from the battle dropping a " + " behind.\n";
            }

            return combatLogResult;
        }

        public override void Update()
        {
            if (this.isAlive == false)
            {
                Gameplay.Root.Children.Remove(this.Image);
                Gameplay.MainEngine.EnemiesList.Remove(this);
            }
        }

        public override void Render()
        {
            Canvas.SetLeft(this.Image, this.X);
            Canvas.SetTop(this.Image, this.Y);
        }
    }
}
