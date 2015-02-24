using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using The_Powerful_Game.Enums;

namespace The_Powerful_Game.Menu
{
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

        private void warriorButton_Click(object sender, RoutedEventArgs e)
        {
            classType = ClassType.Warrior;;
            Switcher.Switch(new Gameplay());
        }

        private void mageButton_Click(object sender, RoutedEventArgs e)
        {
            classType = ClassType.Mage;
            Switcher.Switch(new Gameplay());
        }

        private void hunterButton_Click(object sender, RoutedEventArgs e)
        {
            classType = ClassType.Hunter;
            Switcher.Switch(new Gameplay());
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        
    }
}
