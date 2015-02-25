namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using System.Windows;
    using System.Windows.Media;
    using The_Powerful_Game.Menu;

    public class Enemy : Entity
    {
        public Enemy(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image img)
            : base(name, x, y, healthPoints, armorPoints, damage, img)
        {
        }

        public bool Fled { get; set; }

        public string Attack(Character player)
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 101);

            if (player is Warrior && player.DeffensiveBuff)
            {
                fightCase = 105;
                player.DeffensiveBuff = false;
            }
            else if (player is Mage && player.DeffensiveBuff)
            {
                fightCase = 106;
            }
            if (player is Hunter && player.DeffensiveBuff)
            {
                fightCase = 107;
            }

            string combatLogResult = "";

            if (fightCase <= 30)
            {
                // Enemy deals 100% damage
                int damageDealt = player.ProcessDamageTaken(this.Damage);
                combatLogResult = "The Enemy hits you, dealing " + damageDealt + " damage.\n";
            }
            else if (fightCase > 30 && fightCase <= 55)
            {
                // Enemy deals 120% damage
                int damageDealt = player.ProcessDamageTaken((int)Math.Round(this.Damage * 6 / 5.0));
                combatLogResult = "The Enemy attacks you with relentless strike dealing " + damageDealt + " damage.\n";
            }
            else if (fightCase > 55 && fightCase <= 80)
            {
                // Enemy deals 80% damage
                int damageDealt = player.ProcessDamageTaken((int)Math.Round(this.Damage * 4 / 5.0));
                combatLogResult = "The Enemy attack`s for " + damageDealt + " damage.\n";
            }
            else if (fightCase > 80 && fightCase <= 90)
            {
                // Enemy stuns you and deals 50% damage
                int damageDealt = player.ProcessDamageTaken((int)Math.Round(this.Damage / 2.0));
                combatLogResult = "The enemy dashes you knocking you on the ground. You lose your turn and "
                    + damageDealt + " Health Points.\n";
            }
            else if (fightCase > 90 && fightCase <= 94)
            {
                // Enemy crits for 150% damage
                int damageDealt = player.ProcessDamageTaken((int)Math.Round(this.Damage * 3 / 2.0));
                combatLogResult = "The Enemy delivers a deadly strike for " + damageDealt + " damage.\n";
            }
            else if (fightCase > 94 && fightCase <= 99)
            {
                // Enemy misses
                combatLogResult = "You dodge your enemy`s attack.\n";
            }
            else if (fightCase > 99 && fightCase < 101)
            {
                // Enemy flees from battle droping an item behind
                this.Fled = true;
            }
            else if (fightCase == 105)
            {
                // Enemy is TAUNTED dealing less damage
                int damageDealt = player.ProcessDamageTaken(this.Damage);
                combatLogResult = string.Format("The Enemy hits you while Taunted dealing {0}.\n", damageDealt);
                player.DeffensiveBuff = false;
            }
            else if (fightCase == 106)
            {
                player.ResourcePoints = player.ResourcePoints.Increase((int)this.Damage * 3 / 5);
                int damageDealt = player.ProcessDamageTaken(this.Damage * 1 / 3);
                combatLogResult = string.Format("The Enemy hits your mana shield dealing {0} and restoring {1} mana.\n", damageDealt, (int)this.Damage * 3 / 5);
                player.DeffensiveBuff = false;
            }
            else if (fightCase == 107)
            {
                combatLogResult = string.Format("The Enemy reaches to hit you but you Avoid.\n");
                player.DeffensiveBuff = false;
            }

            return combatLogResult;
        }

        public override void Update()
        {
            if (!this.isAlive)
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
