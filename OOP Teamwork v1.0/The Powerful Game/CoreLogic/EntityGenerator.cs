namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using The_Powerful_Game.Entities;
    using The_Powerful_Game.Entities.Chooses;
    using The_Powerful_Game.Enums;
    using The_Powerful_Game.Menu;

    public static class EntityGenerator
    {
        public static Character GeneratePlayer()
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
                        Constants.WarriorDamagePoints, playerImage, 2, 1, 1, new AttributePair(Constants.WarriorResourcePoints, Constants.CharacterResourcePoints),
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

        private static Image GenerateImage(string name, int width, int height, string source)
        {
            var img = new Image();
            img.Name = name;
            img.Source = new BitmapImage(new Uri(source));
            img.Width = width;
            img.Height = height;

            return img;
        }

        public static Enemy GenerateEnemy(int x, int y)
        {
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
            return enemy;
        }
    }
}
