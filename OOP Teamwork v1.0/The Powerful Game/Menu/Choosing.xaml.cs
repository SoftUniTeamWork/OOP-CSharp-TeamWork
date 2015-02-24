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

namespace The_Powerful_Game.Menu
{
    /// <summary>
    /// Interaction logic for Choosing.xaml
    /// </summary>
    public partial class Choosing : UserControl, ISwitchable
    {
        public Choosing()
        {
            InitializeComponent();
        }

        private void warriorButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay());
        }

        private void mageButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay());
        }

        private void hunterButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Gameplay());
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        
    }
}
