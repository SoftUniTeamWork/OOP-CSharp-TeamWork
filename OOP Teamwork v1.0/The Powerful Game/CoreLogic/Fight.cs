namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Windows.Media;
    using The_Powerful_Game.Menu;
    using The_Powerful_Game.Entities;
    using MessageBox = System.Windows.MessageBox;

    public class Fight
    {
        public Fight(Player player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
        }

        private Player Player { get; set; }

        private Enemy Enemy { get; set; }

        public string EnemyTurn()
        {
            string combatLogResult = this.Enemy.Attack();
            FightOverCheck();
            return combatLogResult;
        }

        public string PlayerTurn(string choice)
        {
            string combatLogResult = "";

            switch (choice)
            {
                case "Attack":
                    combatLogResult = this.Player.Attack(this.Enemy);
                    break;
                case "Spell1":
                    //combatLogResult = this.Player.CastSpell(this.Enemy);
                    break;
                case "Spell2":
                    //combatLogResult = this.Player.CastSpell2(this.Enemy);
                    break;
            }

            FightOverCheck();
            return combatLogResult;
        }

        private void FightOverCheck()
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
                    this.Enemy.isAlive = false;
                    this.Enemy.Update();
                }

                CompositionTarget.Rendering += Gameplay.MainEngine.Run;
                Switcher.Switch(Gameplay.Control);
            }
        }
    }
}
