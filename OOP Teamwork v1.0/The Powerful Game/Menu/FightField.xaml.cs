namespace The_Powerful_Game.Menu
{
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Media;
    using System.Linq;
    using The_Powerful_Game.Items;
    using The_Powerful_Game.CoreLogic;
    using The_Powerful_Game.Entities;
    using MessageBox = System.Windows.MessageBox;
    using UserControl = System.Windows.Controls.UserControl;

    public partial class FightField : UserControl
    {
        public Character Player { get; private set; }

        public Enemy Enemy { get; private set; }

        public Fight Fighting { get; private set; }

        public FightField(Character player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            this.Fighting = new Fight(player, enemy);

            InitializeComponent();
        }

        private void ButtonFleeOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = (DialogResult)MessageBox.Show("Are you sure you want to flee?", "Are you sure?", MessageBoxButton.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Whew! You fled from The Orc Revenger!");
                CompositionTarget.Rendering += Gameplay.MainEngine.Run;
                Player.Flee(this.Enemy);
                Switcher.Switch(Gameplay.Control);
            }
        }

        private void ButtonAttackOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text = this.Fighting.PlayerTurn("Attack") + this.CombatLog.Text;
            if (this.Enemy.isAlive)
            {
                this.CombatLog.Text = this.Fighting.EnemyTurn() + this.CombatLog.Text;
            }
        }

        private void ButtonOffensiveSpellOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text = this.Fighting.PlayerTurn("Offensive Skill") + this.CombatLog.Text;
            if (this.Fighting.PlayerTookTurn && this.Enemy.isAlive)
            {
                this.CombatLog.Text = this.Fighting.EnemyTurn() + this.CombatLog.Text;
            }
        }

        private void ButtonDeffensiveSpellOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text = this.Fighting.PlayerTurn("Deffensive Skill") + this.CombatLog.Text;
            if (this.Fighting.PlayerTookTurn)
            {
                this.CombatLog.Text = this.Fighting.EnemyTurn() + this.CombatLog.Text;
                this.Player.ArmorPoints -= this.Player.ArmorPoints / 2;
            }
        }

        private void ButtonDrinkHealthPotionOnClick(object sender, RoutedEventArgs e)
        {
            var potion = (HealthPotion)this.Player.Inventory.FirstOrDefault(i => i is HealthPotion);
            if (potion != null)
            {
                this.CombatLog.Text = this.Player.DrinkHealthPotion(potion) + this.CombatLog.Text;
            }
            else
            {
                MessageBox.Show("No Health Potions available.");
            }
        }

        private void ButtonDrinkResourcePotionOnClick(object sender, RoutedEventArgs e)
        {
            var potion = (ResourcePotion)this.Player.Inventory.FirstOrDefault(i => i is ResourcePotion);
            if (potion != null)
            {
                this.CombatLog.Text = this.Player.DrinkResourcePotion(potion) + this.CombatLog.Text;
            }
            else
            {
                MessageBox.Show("No Resource Potions available.");
            }
        }
    }
}
