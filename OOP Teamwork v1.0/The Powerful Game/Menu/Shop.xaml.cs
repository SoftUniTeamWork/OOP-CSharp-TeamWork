namespace The_Powerful_Game.Menu
{
    using System.Windows.Controls;
    using The_Powerful_Game.CoreLogic;
    using The_Powerful_Game.Entities;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Shop : UserControl
    {
        public Character Player { get; private set; }

        public Merchant Merchant { get; private set; }

        public Trade Trade { get; private set; }

        public Shop(Character player, Merchant merchant)
        {
            this.Player = player;
            this.Merchant = merchant;
            this.Trade = new Trade(player, merchant);

            InitializeComponent();
        }
    }
}
