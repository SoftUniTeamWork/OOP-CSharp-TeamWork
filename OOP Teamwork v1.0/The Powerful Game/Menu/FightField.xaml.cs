namespace The_Powerful_Game.Menu
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Media;
    using The_Powerful_Game.CoreLogic;
    using The_Powerful_Game.Entities;
    using The_Powerful_Game.Items;   
    using MessageBox = System.Windows.MessageBox;
    using UserControl = System.Windows.Controls.UserControl;

    public partial class FightField : UserControl
    {
        public FightField(Character player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            this.Fight = new Fight(player, enemy);

            this.DataContext = this;

            this.InitializeComponent();
        }

        public Character Player { get; private set; }

        public Enemy Enemy { get; private set; }

        public Fight Fight { get; private set; }

        private void ButtonFleeOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = (DialogResult)MessageBox.Show("Are you sure you want to flee?", "Are you sure?", MessageBoxButton.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Whew! You fled from The Orc Revenger!");
                CompositionTarget.Rendering += Gameplay.MainEngine.Run;
                this.Player.Flee(this.Enemy);
                Switcher.Switch(Gameplay.Control);
            }
        }

        private void ButtonAttackOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text = this.Fight.PlayerTurn("Attack") + this.CombatLog.Text;
            if (this.Enemy.IsAlive)
            {
                this.CombatLog.Text = this.Fight.EnemyTurn() + this.CombatLog.Text;
            }
        }

        private void ButtonOffensiveSpellOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text = this.Fight.PlayerTurn("Offensive Skill") + this.CombatLog.Text;
            if (this.Fight.PlayerTookTurn && this.Enemy.IsAlive)
            {
                this.CombatLog.Text = this.Fight.EnemyTurn() + this.CombatLog.Text;
            }
        }

        private void ButtonDeffensiveSpellOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text = this.Fight.PlayerTurn("Deffensive Skill") + this.CombatLog.Text;
            if (this.Fight.PlayerTookTurn)
            {
                this.CombatLog.Text = this.Fight.EnemyTurn() + this.CombatLog.Text;
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
