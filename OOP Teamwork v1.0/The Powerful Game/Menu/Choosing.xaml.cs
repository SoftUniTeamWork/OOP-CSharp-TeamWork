namespace The_Powerful_Game.Menu
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using The_Powerful_Game.Enums;

    /// <summary>
    /// Interaction logic for Choosing.xaml
    /// </summary>
    public partial class Choosing : UserControl, ISwitchable
    {
        public static ClassType classType;
        public Choosing()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void hunterButton_Click(object sender, RoutedEventArgs e)
        {
            classType = ClassType.Hunter;
            Switcher.Switch(new Gameplay());
        }

        private void mageButton_Click(object sender, RoutedEventArgs e)
        {
            classType = ClassType.Mage;
            Switcher.Switch(new Gameplay());
        }

        private void warriorButton_Click(object sender, RoutedEventArgs e)
        {
            classType = ClassType.Warrior;
            Switcher.Switch(new Gameplay());
        }
    }
}
