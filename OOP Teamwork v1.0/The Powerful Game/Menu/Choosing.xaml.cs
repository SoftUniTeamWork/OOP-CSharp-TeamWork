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
        public static ClassType ClassType;

        public Choosing()
        {
            this.InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void HunterButton_Click(object sender, RoutedEventArgs e)
        {
            ClassType = ClassType.Hunter;
            Switcher.Switch(new Gameplay());
        }

        private void MageButton_Click(object sender, RoutedEventArgs e)
        {
            ClassType = ClassType.Mage;
            Switcher.Switch(new Gameplay());
        }

        private void WarriorButton_Click(object sender, RoutedEventArgs e)
        {
            ClassType = ClassType.Warrior;
            Switcher.Switch(new Gameplay());
        }
    }
}
