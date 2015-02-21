using System;
using The_Powerful_Game.CoreLogic;

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

        private void KeyListener()
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Point p = Mouse.GetPosition(null);

                double horizontalDistance = p.X - this.X - this.Image.Width / 2;
                double verticalDistance = p.Y - this.Y - this.Image.Height / 2;

                double distance = Math.Sqrt(Math.Abs(p.X - this.X) + Math.Abs(p.Y - this.Y));

                double horSpeed = horizontalDistance / distance / 10;
                double vertSpeed = verticalDistance / distance / 10;

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
