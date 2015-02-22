using System.Windows;
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

        public Player Player { get; set; }

        public Enemy Enemy { get; set; }

        public bool IsFightOver { get; set; }

        public bool IsEnemyTurn { get; private set; }

        public void EnemyTurn()
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
                    result = "The Enemy hits you, dealing " + damage + " damage.";
                    break;
                case 3:
                case 4:
                    // Enemy deals 120% damage
                    damage = (int)Math.Round(damage * 6 / 5.0); // 120% dmg
                    PlayerProcessDamageTaken(damage);
                    result = "The Enemy attacks you with relentless strike dealing " + damage + " damage.";
                    break;
                case 5:
                case 6:
                    // Enemy deals 80% damage
                    damage = (int)Math.Round(damage * 4 / 5.0); // 80% dmg
                    PlayerProcessDamageTaken(damage);
                    result = "The Enemy attack`s for " + damage + " damage.";
                    break;
                case 7:
                    // Enemy crits for 200% damage
                    damage = damage * 2; // 200% dmg crit
                    PlayerProcessDamageTaken(damage);
                    result = "The Enemy delivers a deadly strike for " + damage + "damage.";
                    break;
                case 8:
                    // Enemy misses
                    result = "You dodge your enemy`s attack.";
                    break;
                case 9:
                    // Enemy stuns you and deals 50% damage
                    damage = (int)Math.Round(damage / 2.0);
                    result = "The enemy dashes you knocking you on the ground. You lose your turn and " + damage + " Health Points.";
                    break;
                case 10:
                    // Enemy flees from battle droping an item behind
                    this.IsFightOver = true;
                    result = "Your enemy has fled from the battle dropping a " + " behind.";
                    break;
            }

            FightOverCheck();
            IsEnemyTurn = false;
        }

        public void PlayerTurn(string userChoice)
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
                        result = "You deal " + damage + " damage.";

                        break;
                    case 3:
                    case 4:
                        // Deal 120% damage
                        damage = (int)Math.Round(damage * 6 / 5.0); // 120% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "You strike for " + damage + " damage.";
                        break;
                    case 5:
                    case 6:
                        // Deal 80% damage
                        damage = (int)Math.Round(damage * 4 / 5.0); // 80% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "You hit for " + damage + " damage.";
                        break;
                    case 7:
                        // Deal Critical 200% damage
                        damage = damage * 2; // 200% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "You attack with a massive blow for " + damage + " damage.";
                        break;
                    case 8:
                        // Miss
                        result = "You miss your enemy.";
                        break;
                    case 9:
                        // Stun for 1 turn and 50% damage
                        damage = damage / 2; // 50% dmg
                        EnemyProcessDamageTaken(damage);
                        result = "With a fierce strike you deal " + damage + " damage and stun your opponent for 1 round.";
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
            IsEnemyTurn = true;
        }

        private void EnemyProcessDamageTaken(int damage)
        {
            if (this.Enemy.HealthPoints - (damage - this.Enemy.ArmorPoints) >= 0)
            {
                this.Enemy.HealthPoints = this.Enemy.HealthPoints - (damage - this.Enemy.ArmorPoints);
            }
            this.Enemy.HealthPoints = 0;
        }

        private void PlayerProcessDamageTaken(int damage)
        {
            if (this.Player.HealthPoints - (damage - this.Player.ArmorPoints) >= 0)
            {
                this.Player.HealthPoints = this.Player.HealthPoints - (damage - this.Player.ArmorPoints);
            }
            this.Player.HealthPoints = 0;
        }

        public void FightOverCheck()
        {
            if (Player.HealthPoints == 0 || Enemy.HealthPoints == 0)
            {
                if (Player.HealthPoints == 0)
                {
                    MessageBox.Show("You died!");
                    Gameplay.Root.Children.Remove(Enemy.Image);
                    Gameplay.MainEngine.EnemiesList.Remove(Enemy);
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
