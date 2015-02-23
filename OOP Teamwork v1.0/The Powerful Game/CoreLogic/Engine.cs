using System.Windows.Media;

namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using The_Powerful_Game.Entities;
    using The_Powerful_Game.Entities.Chooses;
    using The_Powerful_Game.Menu;

    public class Engine
    {
        private const int NumberOfEnemies = 3;
        private Player player;

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
            this.player = GeneratePlayer();
            Random enemyPosition = new Random();

            for (var i = 0; i < NumberOfEnemies; i++)
            {
                GenerateEnemy(
                    enemyPosition.Next(0, Constants.MapWidth - 150),
                    enemyPosition.Next(0, Constants.MapHeight) - Constants.EnemyHeight);
            }

            // Should build the map here.
        }

        private Player GeneratePlayer()
        {
            string playerName = "Player";
            var img = GenerateImage(playerName, Constants.EnemyWidth, Constants.EnemyHeight, Constants.PlayerImage);

            var player = new Player(
                playerName,
                100,
                100,
                Constants.PlayerHealthPoints,
                Constants.PlayerArmorPoints,
                Constants.PlayerDamagePoints,
                Constants.PlayerResourcePoints,
                EntityResourceType.Energy,
                img);

            Gameplay.Root.Children.Add(img);
            return player;
        }

        private void GenerateEnemy(int x, int y)
        {
            Random newRandom = new Random();
            
            string enemyName = "Enemy";
            var img = GenerateImage(enemyName, Constants.PlayerWidth, Constants.PlayerHeight, Constants.EnemyImage);

            var enemy = new Enemy(
                enemyName,
                x,
                y,
                Constants.EnemyHealthPoints,
                Constants.EnemyArmorPoints,
                Constants.EnemyDamagePoints,
                img);

            Gameplay.Root.Children.Add(img);
            EnemiesList.Add(enemy);
        }

        private Image GenerateImage(string name, int width, int height, string source)
        {
            var img = new Image();
            img.Name = name;
            img.Source = new BitmapImage(new Uri(source));
            img.Width = width;
            img.Height = height;

            return img;
        }
    }
}