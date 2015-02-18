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
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : UserControl, ISwitchable
    {
        public Gameplay()
        {
            InitializeComponent();
            CompositionTarget.Rendering += HandleKeyPress;
        }

        // Should be in Player class
        private void HandleKeyPress(object sender, EventArgs e)
        {
            var target = gameplayLayoutRoot.Children[0];

            double x = Canvas.GetLeft(target);
            double y = Canvas.GetTop(target);

            if (Keyboard.IsKeyDown(Key.Up))
            {
                Canvas.SetTop(target, y - 2);
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                Canvas.SetTop(target, y + 2);
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                Canvas.SetLeft(target, x - 2);
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                Canvas.SetLeft(target, x + 2);
            }
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
