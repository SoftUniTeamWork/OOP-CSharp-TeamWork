using System.Windows.Controls;

namespace The_Powerful_Game.Menu
{
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Media;
    using The_Powerful_Game.CoreLogic;
    using The_Powerful_Game.Entities;
    using MessageBox = System.Windows.MessageBox;
    using UserControl = System.Windows.Controls.UserControl;

    /// <summary>
    /// Interaction logic for Fight.xaml
    /// </summary>
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

        private void ButtonFledOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = (DialogResult)MessageBox.Show("Are you sure you want to fled?", "Are you sure?", MessageBoxButton.YesNo);
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
            this.CombatLog.Text = this.Fighting.EnemyTurn() + this.CombatLog.Text;
        }

        private void ButtonSpellOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text = this.Fighting.PlayerTurn("Offensive Skill") + this.CombatLog.Text;
            if (!this.Fighting.PlayerTookTurn)
            {
                this.CombatLog.Text = this.Fighting.EnemyTurn() + this.CombatLog.Text;
            }
        }

        private void ButtonDrinkPotionOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = (DialogResult)MessageBox.Show("Press yes for health potion, no for mana or cancel for not?", "Drink potion?", MessageBoxButton.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                this.CombatLog.Text += "You used health potion\n";
            }
            else if (dialogResult == DialogResult.No)
            {
                this.CombatLog.Text += "You used mana potion\n";
            }
        }
    }
}
