using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace The_Powerful_Game.CoreLogic
{
    public static class Constants
    {
        public static readonly string GameName = "";   //TODO
        public static readonly int MapWidth = 800;
        public static readonly int MapHeight = 600;

        public static readonly int CharacterResourcePoints = 100;
        public static readonly int CharacterMoveSpeed = 2;

        public static readonly int WarriorHealthPoints = 400;
        public static readonly int WarriorArmorPoints = 25;
        public static readonly int WarriorDamagePoints = 30;

        public static readonly int HunterHealthPoints = 350;
        public static readonly int HunterArmorPoints = 22;
        public static readonly int HunterDamagePoints = 45;

        public static readonly int MageHealthPoints = 300;
        public static readonly int MageArmorPoints = 10;
        public static readonly int MageDamagePoints = 25;

        public static readonly string WarriorImage = @"pack://application:,,,/Resources/Classes/Warrior.png";
        public static readonly string HunterImage = @"pack://application:,,,/Resources/Classes/Hunter.png";
        public static readonly string MageImage = @"pack://application:,,,/Resources/Classes/Mage.png";

        public static readonly int EnemyHealthPoints = 200;
        public static readonly int EnemyArmorPoints = 15;
        public static readonly int EnemyDamagePoints = 40;

        public static readonly string EnemyImage = @"pack://application:,,,/Resources/3D-Orc.png";

        public static readonly int PlayerWidth = 40;
        public static readonly int PlayerHeight = 40;

        public static readonly int EnemyWidth = 40;
        public static readonly int EnemyHeight = 40;
    }
}
