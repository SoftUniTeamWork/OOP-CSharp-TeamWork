namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Chooses;
    using System.Windows;
    using The_Powerful_Game.CoreLogic;

    public class Player : Entity
    {
        private int resoursePoints;
        private EntityResourceType resourceType;

        public Player(string name, double x, double y, int healthPoints, int armorPoints, int damage, int resoursePoints, EntityResourceType resourceType, Image img)
            : base(name, x, y, healthPoints, armorPoints, damage, img)
        {
            this.ResoursePoints = resoursePoints;
            this.ResourceType = resourceType;
        }

        public int ResoursePoints { get; set; }

        public EntityResourceType ResourceType { get; set; }

        public override void Update()
        {
            if (this.HealthPoints == 0)
            {
                this.isAlive = false;
            }
            KeyListener();
        }

        public override void Render()
        {
            Canvas.SetLeft(this.Image, this.X);
            Canvas.SetTop(this.Image, this.Y);
        }

        public void Flee(Enemy enemy)
        {
            this.X = enemy.X - 50;
        }

        public string Attack(Enemy enemy)
        {
            Random fightSituation = new Random();
            int fightCase = fightSituation.Next(1, 10);

            string combatLogResult = "";

            switch (fightCase)
            {
                case 1:
                case 2:
                    // Deal 100% damage
                    this.ProcessDamageTaken(this.Damage);
                    combatLogResult = "You deal " + this.Damage + " damage.\n";

                    break;
                case 3:
                case 4:
                    // Deal 120% damage
                    this.ProcessDamageTaken((int)Math.Round(this.Damage * 6 / 5.0));
                    combatLogResult = "You strike for " + this.Damage + " damage.\n";
                    break;
                case 5:
                case 6:
                    // Deal 80% damage

                    this.ProcessDamageTaken((int)Math.Round(this.Damage * 4 / 5.0));
                    combatLogResult = "You hit for " + this.Damage + " damage.\n";
                    break;
                case 7:
                    // Deal Critical 200% damage
                    this.ProcessDamageTaken(this.Damage * 2);
                    combatLogResult = "You attack with a massive blow for " + this.Damage + " damage.\n";
                    break;
                case 8:
                    // Miss
                    combatLogResult = "You miss your enemy.\n";
                    break;
                case 9:
                    // Stun for 1 turn and 50% damage
                    this.ProcessDamageTaken(this.Damage / 2);
                    combatLogResult = "With a fierce strike you deal " + this.Damage + " damage and stun your opponent for 1 round.\n";
                    break;
                case 10:
                    // 
                    break;
            }

            return combatLogResult;
        }

        private void KeyListener()
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                this.Y -= Constants.PlayerMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                this.Y += Constants.PlayerMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                this.X -= Constants.PlayerMoveSpeed;
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                this.X += Constants.PlayerMoveSpeed;
            }
        }
    }
}
