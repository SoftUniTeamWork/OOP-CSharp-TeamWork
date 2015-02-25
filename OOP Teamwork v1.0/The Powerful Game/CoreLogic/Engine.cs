﻿namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using The_Powerful_Game.Entities;
    using The_Powerful_Game.Entities.Chooses;
    using The_Powerful_Game.Enums;
    using The_Powerful_Game.Menu;

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

        private Character GeneratePlayer()
        {
            string playerName = "Player";

            AttributePair health;
            Image playerImage = null;
            Character player = null;
            switch (Choosing.classType)
            {
                case ClassType.Warrior:
                    health = new AttributePair(Constants.WarriorHealthPoints, Constants.WarriorHealthPoints);
                    playerImage = GenerateImage(playerName, Constants.EnemyWidth, Constants.EnemyHeight, Constants.WarriorImage);
                    player = new Warrior(playerName, 100, 100, health, Constants.WarriorArmorPoints,
                        Constants.WarriorDamagePoints, playerImage, 2, 1, 1, new AttributePair(Constants.CharacterResourcePoints, Constants.CharacterResourcePoints),
                        EntityResourceType.Rage);
                    break;
                case ClassType.Mage:
                    health = new AttributePair(Constants.MageHealthPoints, Constants.MageHealthPoints);
                    playerImage = GenerateImage(playerName, Constants.EnemyWidth, Constants.EnemyHeight, Constants.MageImage);
                    player = new Mage(playerName, 100, 100, health, Constants.MageArmorPoints,
                        Constants.MageDamagePoints, playerImage, 2, 1, 1, new AttributePair(Constants.CharacterResourcePoints, Constants.CharacterResourcePoints),
                        EntityResourceType.Mana);
                    break;
                case ClassType.Hunter:
                    health = new AttributePair(Constants.HunterHealthPoints, Constants.HunterHealthPoints);
                    playerImage = GenerateImage(playerName, Constants.EnemyWidth, Constants.EnemyHeight, Constants.HunterImage);
                    player = new Hunter(playerName, 100, 100, health, Constants.HunterArmorPoints,
                        Constants.HunterDamagePoints, playerImage, 2, 1, 1, new AttributePair(Constants.CharacterResourcePoints, Constants.CharacterResourcePoints),
                        EntityResourceType.Energy);
                    break;

            }
            Gameplay.Root.Children.Add(playerImage);
            return player;
        }

        private void GenerateEnemy(int x, int y)
        {
            Random newRandom = new Random();

            string enemyName = "Enemy";
            var img = GenerateImage(enemyName, Constants.PlayerWidth, Constants.PlayerHeight, Constants.EnemyImage);
            var health = new AttributePair(Constants.EnemyHealthPoints, Constants.EnemyHealthPoints);
            var enemy = new Enemy(
                enemyName,
                x,
                y,
                health,
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