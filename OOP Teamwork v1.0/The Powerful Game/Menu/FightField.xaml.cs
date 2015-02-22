using System.Windows.Controls;

namespace The_Powerful_Game.Menu
{
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Media;
    using The_Powerful_Game.CoreLogic;
    using The_Powerful_Game.Entities;
    using MessageBox = System.Windows.MessageBox;
    using TextBox = System.Windows.Controls.TextBox;
    using UserControl = System.Windows.Controls.UserControl;

    /// <summary>
    /// Interaction logic for Fight.xaml
    /// </summary>
    public partial class FightField : UserControl
    {
        public Player Player { get; private set; }

        public Enemy Enemy { get; private set; }

        public Fight Fighting { get; private set; }

        public FightField(Player player, Enemy enemy)
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
            this.CombatLog.Text += "\nYou attacked " + this.Enemy.Name + " with " + this.Player.Damage + " dmg.";
            this.Fighting.PlayerTurn("Attack");
        }

        private void ButtonSpellOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You cursed the enemy.");
        }

        private void ButtonDrinkPotionOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = (DialogResult)MessageBox.Show("Press yes for health potion, no for mana or cancel for not?", "Drink potion?", MessageBoxButton.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                this.CombatLog.Text += "\nYou used health potion";
            }
            else if (dialogResult == DialogResult.No)
            {
                this.CombatLog.Text += "\nYou used mana potion";
            }
        }
    }
}
