namespace The_Powerful_Game.CoreLogic
{
    public static class Constants
    {
        public const int MapWidth = 1000;
        public const int MapHeight = 680;

        public const int CharacterResourcePoints = 100;
        public const int WarriorResourcePoints = 0;

        public const int CharacterMoveSpeed = 2;

        public const int WarriorHealthPoints = 400;
        public const int WarriorArmorPoints = 25;
        public const int WarriorDamagePoints = 30;

        public const int HunterHealthPoints = 350;
        public const int HunterArmorPoints = 22;
        public const int HunterDamagePoints = 45;

        public const int MageHealthPoints = 300;
        public const int MageArmorPoints = 10;
        public const int MageDamagePoints = 25;

        public const int EnemyHealthPoints = 200;
        public const int EnemyArmorPoints = 15;
        public const int EnemyDamagePoints = 40;

        public const int PlayerWidth = 40;
        public const int PlayerHeight = 40;

        public const int EnemyWidth = 40;
        public const int EnemyHeight = 40;

        public const int TileSize = 40;

        public static readonly string GameName = "The Powerful Game";

        public static readonly string EnemyImage = @"pack://application:,,,/Resources/3D-Orc.png";
        public static readonly string MerchantImage = @"pack://application:,,,/Resources/merchant.png";

        public static readonly string WarriorImage = @"pack://application:,,,/Resources/Classes/Warrior.png";
        public static readonly string HunterImage = @"pack://application:,,,/Resources/Classes/Hunter.png";
        public static readonly string MageImage = @"pack://application:,,,/Resources/Classes/Mage.png";
    }
}
