namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using The_Powerful_Game.Entities;

    public class Engine
    {
        public readonly List<Enemy> EnemiesList = new List<Enemy>(NumberOfEnemies);

        private const int NumberOfEnemies = 10;
        private Character player;
        private Merchant merchant;

        public Engine()
        {
            this.Initialize();
        }

        public void Run(object sender, EventArgs args)
        {
            if (this.player.IsAlive)
            {
                this.player.Update();
                this.EnemiesList.ForEach(e =>
                {
                    CollisionHandler.HandleEnemyCollision(this.player, e);
                    e.Update();
                });

                CollisionHandler.HandleMerchantCollision(this.player, this.merchant);

                this.merchant.Render();
                this.player.Render();
                this.EnemiesList.ForEach(e => e.Render());
            }
        }

        private void Initialize()
        {
            Random posRandom = new Random();

            this.player = EntityGenerator.GeneratePlayer();
            this.merchant = EntityGenerator.GenerateMerchant(150, 450);

            while (this.EnemiesList.Count < NumberOfEnemies)
            {
                int possibleX = posRandom.Next(0, Constants.MapWidth - Constants.EnemyWidth);
                int possibleY = posRandom.Next(0, Constants.MapHeight - Constants.EnemyHeight);

                if (CollisionHandler.HandleMapObjectCollision(
                    possibleX + Constants.EnemyWidth / 2, possibleY + Constants.EnemyHeight / 2))
                {
                    this.EnemiesList.Add(EntityGenerator.GenerateEnemy(possibleX, possibleY));
                }
            }
        }
    }
}