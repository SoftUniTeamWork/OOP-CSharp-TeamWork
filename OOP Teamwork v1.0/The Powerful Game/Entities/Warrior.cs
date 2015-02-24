namespace The_Powerful_Game.Entities
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Chooses;
    using System.Windows;
    using The_Powerful_Game.CoreLogic;

    public class Warrior : Entity
    {
        private AttributePair rage;

        public Warrior(string name, double x, double y, AttributePair healthPoints, int armorPoints, int damage, Image img, AttributePair rage)
            : base(name, x, y, healthPoints, armorPoints, damage, img)
        {
            this.Rage = rage;
        }

        public AttributePair Rage
        {
            get { return this.rage; }
            protected set { this.rage = value; }
        }

        public override void Update()
        {
            if (this.HealthPoints.CurrentValue == 0)
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
                    this.Damage = (int)Math.Round(this.Damage * 6 / 5.0);
                    this.ProcessDamageTaken(this.Damage);
                    combatLogResult = "You strike for " + this.Damage + " damage.\n";
                    break;
                case 5:
                case 6:
                    // Deal 80% damage
                    this.Damage = (int)Math.Round(this.Damage * 4 / 5.0);
                    this.ProcessDamageTaken(this.Damage);
                    combatLogResult = "You hit for " + this.Damage + " damage.\n";
                    break;
                case 7:
                    // Deal Critical 200% damage
                    this.Damage = this.Damage * 2;
                    this.ProcessDamageTaken(this.Damage);
                    combatLogResult = "You attack with a massive blow for " + this.Damage + " damage.\n";
                    break;
                case 8:
                    // Miss
                    combatLogResult = "You miss your enemy.\n";
                    break;
                case 9:
                    // Stun for 1 turn and 50% damage
                    this.Damage = this.Damage / 2;
                    this.ProcessDamageTaken(this.Damage);
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
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Point p = Mouse.GetPosition(null);

                double horizontalDistance = p.X - this.X - this.Image.Width / 2;
                double verticalDistance = p.Y - this.Y - this.Image.Height / 2;

                double distance = Math.Sqrt(Math.Abs(p.X - this.X) + Math.Abs(p.Y - this.Y));

                if (this.X != p.X && this.Y != p.X)
                {
                    if (p.X >= 0 && p.X < Constants.MapWidth - 150 &&
                        p.Y >= 0 && p.Y < Constants.MapHeight)
                    {
                        this.X += horizontalDistance / distance / 10;
                        this.Y += verticalDistance / distance / 10;
                    }
                }
            }
        }

        
    }
}
