using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using The_Powerful_Game.Menu;

namespace The_Powerful_Game.CoreLogic
{
    using System;
    using The_Powerful_Game.Entities;
    using MessageBox = System.Windows.MessageBox;
    using UserControl = System.Windows.Controls.UserControl;

    public class Fight
    {
        public Fight(Player player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
        }

        public Player Player { get; private set; }

        public Enemy Enemy { get; private set; }

        public bool IsFightOver { get; private set; }

        public string EnemyTurn()
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 10);
            string result = "";
            int damage = this.Enemy.Damage;
            switch (fightCase)
            {
                case 1:
                case 2:
                    // Enemy deals 100% damage
                    PlayerProcessDamageTaken(damage);
                    result = "\nThe Enemy hits you, dealing " + damage + " damage.";
                    break;
                case 3:
                case 4:
                    // Enemy deals 120% damage
                    damage = (int)Math.Round(damage * 6 / 5.0); // 120% dmg
                    PlayerProcessDamageTaken(damage);
                    result = "\nThe Enemy attacks you with relentless strike dealing " + damage + " damage.";
                    break;
                case 5:
                case 6:
                    // Enemy deals 80% damage
                    damage = (int)Math.Round(damage * 4 / 5.0); // 80% dmg
                    PlayerProcessDamageTaken(damage);
                    result = "\nThe Enemy attack`s for " + damage + " damage.";
                    break;
                case 7:
                    // Enemy crits for 200% damage
                    damage = damage * 2; // 200% dmg crit
                    PlayerProcessDamageTaken(damage);
                    result = "\nThe Enemy delivers a deadly strike for " + damage + "damage.";
                    break;
                case 8:
                    // Enemy misses
                    result = "\nYou dodge your enemy`s attack.";
                    break;
                case 9:
                    // Enemy stuns you and deals 50% damage
                    damage = (int)Math.Round(damage / 2.0);
                    result = "\nThe enemy dashes you knocking you on the ground. You lose your turn and " + damage + " Health Points.";
                    break;
                case 10:
                    // Enemy flees from battle droping an item behind
                    this.IsFightOver = true;
                    result = "\nYour enemy has fled from the battle dropping a " + " behind.";
                    break;
            }

            FightOverCheck();
            return result;
        }

        public string PlayerTurn(string userChoice)
        {
            Random fightSituation = new Random();
            string result = "";
            int damage = Player.Damage;

            if (userChoice == "Attack")
            {
                int fightCase = fightSituation.Next(1, 10);
                switch (fightCase)
                {
                    case 1:
                    case 2:
                        // Deal 100% damage
                        EnemyProcessDamageTaken(damage);
                        result = "\nYou deal " + damage + " damage.";

                        break;
                    case 3:
                    case 4:
                        // Deal 120% damage
                        damage = (int)Math.Round(damage * 6 / 5.0); // 120% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "\nYou strike for " + damage + " damage.";
                        break;
                    case 5:
                    case 6:
                        // Deal 80% damage
                        damage = (int)Math.Round(damage * 4 / 5.0); // 80% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "\nYou hit for " + damage + " damage.";
                        break;
                    case 7:
                        // Deal Critical 200% damage
                        damage = damage * 2; // 200% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "\nYou attack with a massive blow for " + damage + " damage.";
                        break;
                    case 8:
                        // Miss
                        result = "\nYou miss your enemy.";
                        break;
                    case 9:
                        // Stun for 1 turn and 50% damage
                        damage = damage / 2; // 50% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "\nWith a fierce strike you deal " + damage + " damage and stun your opponent for 1 round.";
                        break;
                    case 10:
                        // 
                        break;
                }

            }
            else if (userChoice == "Spell 1")
            {

            }
            else if (userChoice == "Spell 2")
            {

            }

            FightOverCheck();
            return result;
        }

        private void EnemyProcessDamageTaken(int damage)
        {
            int healthLeft = this.Enemy.HealthPoints - (damage - this.Enemy.ArmorPoints);
            if (healthLeft >= 0)
            {
                this.Enemy.HealthPoints = healthLeft;
            }
            else
            {
                this.Enemy.HealthPoints = 0;
            }
        }

        private void PlayerProcessDamageTaken(int damage)
        {
            int healthLeft = this.Player.HealthPoints - (damage - this.Player.ArmorPoints);
            if (healthLeft >= 0)
            {
                this.Player.HealthPoints = healthLeft;
            }
            else
            {
                this.Player.HealthPoints = 0;
            }
        }

        public void FightOverCheck()
        {
            if (Player.HealthPoints == 0 || Enemy.HealthPoints == 0)
            {
                if (Player.HealthPoints == 0)
                {
                    MessageBox.Show("You died!");
                }
                else if (Enemy.HealthPoints == 0)
                {
                    MessageBox.Show("You killed your enemy gain xp and reward.");
                    Gameplay.Root.Children.Remove(Enemy.Image);
                    Gameplay.MainEngine.EnemiesList.Remove(Enemy);
                }
                IsFightOver = true;
                CompositionTarget.Rendering += Gameplay.MainEngine.Run;
                Switcher.Switch(Gameplay.Control);
            }
        }
    }
}
