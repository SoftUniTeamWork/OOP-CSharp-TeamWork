namespace The_Powerful_Game.Entities
{
    public class Abillity
    {
        public Abillity(string name, int cost, int effectValue)
        {
            this.Name = name;
            this.Cost = cost;
            this.EffectValue = effectValue;
        }

        public string Name { get; private set; }

        public int Cost { get; private set; }

        public int EffectValue { get; private set; }

        public string ApplyOffensiveEffect(Enemy enemy)
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
