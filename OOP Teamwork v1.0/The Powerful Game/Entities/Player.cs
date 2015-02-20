using System;

namespace The_Powerful_Game.Entities
{
    using System.Windows.Controls;
    using System.Windows.Input;
    using Chooses;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public class Player : Entity
    {
        private int resoursePoints;
        private EntityResourceType resourceType;

        public Player(string name, double x, double y, int healthPoints, int armorPoints, int damage, double attackSpeed, int resoursePoints, EntityResourceType resourceType, Image img)
            : base(name, x, y, healthPoints, armorPoints, damage, attackSpeed, img)
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

        private void KeyListener()
        {
            //if (Mouse.RightButton == MouseButtonState.Pressed)
            //{
            //    Point p = Mouse.GetPosition(null);

            //    double horizontalDistance = p.X - this.X;
            //    double verticalDistance = p.Y - this.Y;

            //    double distance = Math.Sqrt(Math.Abs(p.X - this.X) + Math.Abs(p.Y - this.Y));

            //    if (this.X != p.X)
            //    {
            //        this.X += (horizontalDistance / distance) / 10;
            //    }

            //    if (this.Y != p.Y)
            //    {
            //        this.Y += (verticalDistance / distance) / 10;
            //    }
            //}

            if (Keyboard.IsKeyDown(Key.Up))
            {
                if (this.Y != 0)
                {
                    this.Y--;
                }
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                if (this.Y != 571)
                {
                    this.Y++;
                }
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                if (this.X != 0)
                {
                    this.X--;
                }
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                if (this.X != 638)
                {
                    this.X++;
                }
            }
        }
    }
}
