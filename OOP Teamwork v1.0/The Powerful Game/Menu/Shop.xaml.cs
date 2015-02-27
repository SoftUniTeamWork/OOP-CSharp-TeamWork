namespace The_Powerful_Game.Menu
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using The_Powerful_Game.CoreLogic;
    using The_Powerful_Game.Entities;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Shop : UserControl
    {
        public Shop(Character player, Merchant merchant)
        {
            this.Player = player;
            this.Merchant = merchant;
            this.Trade = new Trade(player, merchant);

            this.DataContext = this;

            this.InitializeComponent();
        }

        public Character Player { get; private set; }

        public Merchant Merchant { get; private set; }

        public Trade Trade { get; private set; }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += Gameplay.MainEngine.Run;
            this.Player.Flee(this.Merchant);
            Switcher.Switch(Gameplay.Control);
        }
    }
}
