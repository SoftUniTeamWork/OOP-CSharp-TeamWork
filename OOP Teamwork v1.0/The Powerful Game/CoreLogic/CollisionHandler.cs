using System.Windows;

namespace The_Powerful_Game.CoreLogic
{
    using System;
    using System.Windows.Media;
    using The_Powerful_Game.Entities;
    using The_Powerful_Game.Menu;

    public static class CollisionHandler
    {
        public static void HandleEnemyCollision(Character player, Enemy enemy)
        {
            double playerX = player.X + player.Image.Width / 2;
            double playerY = player.Y + player.Image.Height / 2;

            double enemyX = enemy.X + enemy.Image.Width / 2;
            double enemyY = enemy.Y + enemy.Image.Height / 2;

            double distance = Math.Sqrt(Math.Pow(playerX - enemyX, 2) + Math.Pow(playerY - enemyY, 2));

            if (distance <= player.Image.Width / 2 &&
                distance <= enemy.Image.Height / 2)
            {
                CompositionTarget.Rendering -= Gameplay.MainEngine.Run;
                Switcher.Switch(new FightField(player, enemy));
            }
        }

        //public static void HandleObstacleCollision(Player player, Obstacle obstacle)
        //{
            
        //}
    }
}
