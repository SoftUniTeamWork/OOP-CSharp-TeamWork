namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using The_Powerful_Game.Entities;

    public class Engine
    {
        private const int NumberOfEnemies = 3;
        private Character player;

        public readonly List<Enemy> EnemiesList = new List<Enemy>(NumberOfEnemies);

        public Engine()
        {
            Initialize();
        }

        public void Run(object sender, EventArgs args)
        {
            if (this.player.isAlive)
            {
                this.player.Update();
                EnemiesList.ForEach(e =>
                {
                    CollisionHandler.HandleEnemyCollision(this.player, e);
                    e.Update();
                });

                this.player.Render();
                EnemiesList.ForEach(e => e.Render());
            }
        }

        private void Initialize()
        {
            this.player = EntityGenerator.GeneratePlayer();
            Random enemyPosition = new Random();

            for (var i = 0; i < NumberOfEnemies; i++)
            {
                this.EnemiesList.Add(EntityGenerator.GenerateEnemy(enemyPosition.Next(0, Constants.MapWidth - 150),
                    enemyPosition.Next(Constants.EnemyHeight, Constants.MapHeight - Constants.EnemyHeight)));
            }

            // Should build the map here.
        }
    }
}