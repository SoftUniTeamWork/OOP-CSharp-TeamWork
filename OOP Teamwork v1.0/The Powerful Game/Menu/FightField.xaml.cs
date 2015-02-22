using System.Windows;
using System.Windows.Forms;
using The_Powerful_Game.CoreLogic;
using The_Powerful_Game.Entities;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace The_Powerful_Game.Menu
{
    /// <summary>
    /// Interaction logic for Fight.xaml
    /// </summary>
    public partial class FightField : UserControl
    {
        private Player player;
        private Enemy enemy;
        private Fight fighting;
        public FightField(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
            this.fighting = new Fight(player, enemy);
            InitializeComponent();
        }

        private void ButtonFledOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = (DialogResult) MessageBox.Show("Are you sure you want to fled?", "Are you sure?", MessageBoxButton.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Whew! You fled from The Orc Revenger!");
                Switcher.Switch(new Gameplay());
            }
        }

        private void ButtonAttackOnClick(object sender, RoutedEventArgs e)
        {
            this.CombatLog.Text += "\nYou attacked " + this.enemy.Name + " with " + this.player.Damage + " dmg.";
            //this.fighting.PlayerTurn("Attack");
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
