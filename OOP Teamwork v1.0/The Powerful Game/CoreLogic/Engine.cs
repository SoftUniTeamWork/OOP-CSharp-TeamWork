using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using The_Powerful_Game.Entities;
using The_Powerful_Game.Entities.Chooses;
using The_Powerful_Game.Menu;

namespace The_Powerful_Game.CoreLogic
{
    public class Engine
    {
        private const int NumberOfEnemies = 3;
        private const string EnemyImageSource = @"pack://application:,,,/Resources/3D-Orc.png";
        private const string PlayerImageSource = @"pack://application:,,,/Resources/WoodElf.png";
        private readonly List<Enemy> enemiesList = new List<Enemy>(NumberOfEnemies);
        private Player player;

        public Engine()
        {
            Initialize();
        }

        public void Run(object sender, EventArgs args)
        {
            if (this.player.isAlive)
            {
                this.player.Update();
                enemiesList.ForEach(e =>
                {
                    Collision(this.player, e);
                    e.Update();
                });

                this.player.Render();
                enemiesList.ForEach(e => e.Render());
            }
        }

        private void Initialize()
        {
            this.player = GeneratePlayer();
            for (var i = 0; i < NumberOfEnemies; i++)
            {
                GenerateEnemy();
            }

            // Should build the map here.
        }

        private Player GeneratePlayer()
        {
            string playerName = "Player";
            var img = GenerateImage(playerName, Constants.EnemyWidth, Constants.EnemyHeight, PlayerImageSource);

            var player = new Player(
                playerName,
                0,
                0,
                Constants.PlayerHealthPoints,
                Constants.PlayerArmorPoints,
                Constants.PlayerDamagePoints,
                Constants.PlayerAttackSpeed,
                Constants.PlayerResourcePoints,
                EntityResourceType.Energy,
                img);

            Gameplay.root.Children.Add(img);
            return player;
        }

        private void GenerateEnemy()
        {
            string enemyName = "Enemy1";
            var img = GenerateImage(enemyName, Constants.PlayerWidth, Constants.PlayerHeight, EnemyImageSource);

            var enemy = new Enemy(
                enemyName,
                200,
                100,
                Constants.EnemyHealthPoints,
                Constants.EnemyArmorPoints,
                Constants.EnemyDamagePoints,
                Constants.EnemyAttackSpeed,
                img);

            Gameplay.root.Children.Add(img);
            enemiesList.Add(enemy);
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

        private void Collision(Player player, Enemy enemy)
        {
            if ((player.X + 13 >= enemy.X && player.X + 4  <= enemy.X + 18) && (player.Y + 23 >= enemy.Y && player.Y + 23 <= enemy.Y + 49))
            {
                player.X = 0;
                player.Y = 0;
            }
        }
    }
}