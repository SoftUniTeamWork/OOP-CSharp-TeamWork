namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using The_Powerful_Game.Entities;

    public class Engine
    {
        private const int NumberOfEnemies = 10;
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

            while (this.EnemiesList.Count < NumberOfEnemies)
            {
                int possibleX = enemyPosition.Next(0, Constants.MapWidth - Constants.EnemyWidth);
                int possibleY = enemyPosition.Next(0, Constants.MapHeight - Constants.EnemyHeight);

                if (CollisionHandler.HandleMapObjectCollision(
                    possibleX + Constants.EnemyWidth / 2, possibleY + Constants.EnemyHeight / 2))
                {
                    this.EnemiesList.Add(EntityGenerator.GenerateEnemy(possibleX, possibleY));
                }
            }
        }
    }
}