namespace The_Powerful_Game.Entities
{
    using System.Windows.Controls;
    using System.Windows.Input;
    using Chooses;

    public class Player : Entity
    {
        private int resoursePoints;
        private EntityResourceType resourceType;

        public Player(string name, int x, int y, int healthPoints, int armorPoints, int damage, double attackSpeed, int resoursePoints, EntityResourceType resourceType, Image img)
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
