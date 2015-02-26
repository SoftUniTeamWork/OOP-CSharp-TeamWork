﻿using System.Windows;
using System.Windows.Input;

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

            if (distance <= player.Image.Width * 2 / 3 &&
                distance <= enemy.Image.Height * 3 / 2)
            {
                CompositionTarget.Rendering -= Gameplay.MainEngine.Run;
                Switcher.Switch(new FightField(player, enemy));
            }
        }

        public static bool HandleMapObjectCollision(int futureX, int futureY)
        {
            int x = (int)futureX / Constants.TileSize;
            int y = (int)futureY / Constants.TileSize;

            if (!(futureY - Constants.PlayerHeight / 2 > 0) || !(futureY < Constants.MapHeight - Constants.PlayerHeight * 3 / 2 ))
            {
                return false;
            }

            if (!(futureX - Constants.PlayerWidth / 2 > 0) || !(futureX < Constants.MapWidth - Constants.PlayerWidth / 2))
            {
                return false;
            }

            if (Gameplay.numMap[y][x] == 2 || Gameplay.numMap[y][x] == 1)
            {
                return false;
            }

            return true;
        }
    }
}
