namespace The_Powerful_Game.Entities
{
    using System.Windows.Controls;

    public class Enemy : Entity
    {
        public Enemy(string name, double x, double y, int healthPoints, int armorPoints, int damage, Image img)
            : base(name, x, y, healthPoints, armorPoints, damage, img)
        {
        }

        public override void Update()
        {
            if (this.HealthPoints == 0)
            {
                this.isAlive = false;
            }
        }

        public override void Render()
        {
            Canvas.SetLeft(this.Image, this.X);
            Canvas.SetTop(this.Image, this.Y);
        }
    }
}
