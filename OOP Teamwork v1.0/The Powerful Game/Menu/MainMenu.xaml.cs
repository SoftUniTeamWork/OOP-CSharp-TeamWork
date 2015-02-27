namespace The_Powerful_Game.Menu
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            this.InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void NewGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new Choosing());
        }

        private void OptionButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new Option());
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Credits());
        }
    }
}
