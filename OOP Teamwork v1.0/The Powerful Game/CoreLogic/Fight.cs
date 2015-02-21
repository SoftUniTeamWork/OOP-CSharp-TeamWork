using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using The_Powerful_Game.Entities;

namespace The_Powerful_Game.CoreLogic
{
    class Fight
    {
        private Player player;
        private Enemy enemy;
        private bool fightOver;

        public Fight(Player player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
        }

        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public bool FightOver { get; set; }
        public void EnemyTurn()
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 10);
            string result = "";
            int damage = enemy.Damage;
            switch (fightCase)
            {
                case 1:
                case 2:
                    // Enemy deals 100% damage
                    Player.HealthPoints = Player.HealthPoints - (damage - Player.ArmorPoints);
                    result = "The Enemy hits you, dealing " + damage + " damage.";
                    break;
                case 3:
                case 4:
                    // Enemy deals 120% damage
                    damage = (int)Math.Round(damage * 6 / 5.0); // 120% dmg
                    Player.HealthPoints -= Player.HealthPoints - (damage - Player.ArmorPoints);
                    
                    result = "The Enemy attacks you with relentless strike dealing " + damage + " damage.";
                    break;
                case 5:
                case 6:
                    // Enemy deals 80% damage
                    damage = (int)Math.Round(damage * 4 / 5.0); // 80% dmg
                    Player.HealthPoints -= Player.HealthPoints - (damage - Player.ArmorPoints);
                    result = "The Enemy attack`s for " + damage + " damage.";
                    break;
                case 7:
                    // Enemy crits for 200% damage
                    damage = damage * 2; // 200% dmg crit
                    Player.HealthPoints -= Player.HealthPoints - (damage - Player.ArmorPoints);
                    result = "The Enemy delivers a deadly strike for " + damage + "damage.";
                    break;
                case 8:
                    // Enemy misses
                    result = "You dodge your enemy`s attack.";
                    break;
                case 9:
                    // Enemy stuns you and deals 50% damage
                    damage = (int)Math.Round(damage/2.0);
                    result = "The enemy dashes you knocking you on the ground. You lose your turn and " + damage + " Health Points.";
                    break;
                case 10:
                    // Enemy flees from battle droping an item behind
                    fightOver = true;
                    result = "Your enemy has fled from the battle dropping a " + " behind.";
                    break;
            }

            // Result for message box
            FightOverCheck();
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
                        Enemy.HealthPoints = Enemy.HealthPoints - (damage - Enemy.ArmorPoints);
                        result = "You deal " + damage + " damage.";
                        break;
                    case 3:
                    case 4:
                        // Deal 120% damage
                        damage = (int)Math.Round(damage * 6 / 5.0); // 120% dmg
                        Enemy.HealthPoints = Enemy.HealthPoints - (damage - Enemy.ArmorPoints);
                        result = "You strike for " + damage + " damage.";
                        break;
                    case 5:
                    case 6:
                        // Deal 80% damage
                        damage = (int)Math.Round(damage * 4 / 5.0); // 80% dmg
                        Enemy.HealthPoints = Enemy.HealthPoints - (damage - Enemy.ArmorPoints);
                        result = "You hit for " + damage + " damage.";
                        break;
                    case 7:
                        // Deal Critical 200% damage
                        damage = damage * 2; // 200% dmg
                        Enemy.HealthPoints = Enemy.HealthPoints - (damage - Enemy.ArmorPoints);
                        result = "You attack with a massive blow for " + damage + " damage.";
                        break;
                    case 8:
                        // Miss
                        result = "You miss your enemy.";
                        break;
                    case 9:
                        // Stun for 1 turn and 50% damage
                        damage = damage / 2; // 50% dmg
                        Enemy.HealthPoints = Enemy.HealthPoints - (damage - Enemy.ArmorPoints);
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

            // Result for message box
            FightOverCheck();
        }

        public void FightOverCheck()
        {
            if (Player.HealthPoints <= 0 || Enemy.HealthPoints <= 0)
            {
                if (Player.HealthPoints <= 0)
                {
                    // You are dead
                }
                else if (Enemy.HealthPoints <= 0)
                {
                    // You killed your enemy gain xp and reward
                }
                FightOver = true;
            }
        }
    }
}
