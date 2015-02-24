namespace The_Powerful_Game.Entities
{
    public class Abillity
    {
        private string name;
        private int cost;
        private int duration;
        private int effectValue;

        public Abillity(string name, int cost, int duration, int effectValue)
        {
            this.Name = name;
            this.Cost = cost;
            this.Duration = duration;
            this.EffectValue = effectValue;
        }

        public string Name { get; private set; }

        public int Cost { get; private set; }

        public int Duration { get; private set; }

        public int EffectValue { get; private set; }

        internal string ApplyOffensiveEffect(Enemy enemy)
        {
            enemy.HealthPoints.Decrease(this.EffectValue);
            return null;
        }

        internal string ApplyDefensiveEffect(Character player)
        {
            player.ArmorPoints += this.EffectValue;
            return null;
        }
    }
}
