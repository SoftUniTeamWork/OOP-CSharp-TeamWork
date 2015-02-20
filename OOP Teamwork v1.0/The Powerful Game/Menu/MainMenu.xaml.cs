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
            Switcher.Switch(new Gameplay());
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
