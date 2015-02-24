namespace The_Powerful_Game.CoreLogic
{
    using System.Windows.Media;
    using The_Powerful_Game.Menu;
    using The_Powerful_Game.Entities;
    using MessageBox = System.Windows.MessageBox;

    public class Fight
    {
        public Fight(Character player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            this.PlayerTookTurn = false;
        }

        private Character Player { get; set; }

        private Enemy Enemy { get; set; }

        public bool PlayerTookTurn { get; private set; }

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
                case "Offensive Skill":
                    combatLogResult = this.Player.CastOffensiveSpell(this.Enemy);
                    if (string.IsNullOrEmpty(combatLogResult))
                    {
                        this.PlayerTookTurn = true;
                        
                    }
                    break;
                case "Deffensive Skill":
                    //combatLogResult = this.Player.CastSpell2(this.Enemy);

                    break;
            }

            FightOverCheck();
            return combatLogResult;
        }

        private void FightOverCheck()
        {
            if (Player.HealthPoints.CurrentValue == 0 || Enemy.HealthPoints.CurrentValue == 0)
            {
                if (Player.HealthPoints.CurrentValue == 0)
                {
                    MessageBox.Show("You died!");
                }
                else if (Enemy.HealthPoints.CurrentValue == 0)
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
