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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_Powerful_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HashSet<Key> keysPressed = new HashSet<Key>();
        public static Canvas root;

        public MainWindow()
        {
            InitializeComponent();
            InitializeNavigation();
            root = this.Content as Canvas;

            // Adding an image dynamically
            //Image img = new Image();
            //img.Width = 60;
            //img.Height = 60;
            //img.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/WoodElf.png"));
        }

        private void InitializeNavigation()
        {
            KeyDown += delegate(object sender, KeyEventArgs args)
            {
                this.keysPressed.Add(args.Key);
            };

            KeyUp += delegate(object sender, KeyEventArgs args)
            {
                this.keysPressed.Remove(args.Key);
            };
            CompositionTarget.Rendering += ProcessKeysPressed;
        }

        private void ProcessKeysPressed(object sender, EventArgs e)
        {
            var target = root.Children[0];

            double x = Canvas.GetLeft(target);
            double y = Canvas.GetTop(target);

            foreach (Key key in this.keysPressed)
            {
                switch (key)
                {
                    case Key.Up:
                        Canvas.SetTop(target, y - 2);
                        break;
                    case Key.Down:
                        Canvas.SetTop(target, y + 2);
                        break;
                    case Key.Left:
                        Canvas.SetLeft(target, x - 2);
                        break;
                    case Key.Right:
                        Canvas.SetLeft(target, x + 2);
                        break;
                }
            }
        }
    }
}
