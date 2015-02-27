namespace The_Powerful_Game.Menu
{
    using System;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Option.xaml
    /// </summary>
    public partial class Option : UserControl, ISwitchable
    {
        public Option()
        {
            // Required to initialize variables
            this.InitializeComponent();
        }

        #region ISwitchable Members

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        #endregion
    }
}