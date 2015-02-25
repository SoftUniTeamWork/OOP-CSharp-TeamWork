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
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new Choosing());
        }

        private void optionButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new Option());
        }
        private void creditsButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Credits());
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

       
        #endregion
    }
}
