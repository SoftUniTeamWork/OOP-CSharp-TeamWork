namespace The_Powerful_Game.Menu
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using The_Powerful_Game.CoreLogic;

    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : UserControl, ISwitchable
    {
        public static Canvas root;

        public Gameplay()
        {
            InitializeComponent();

            root = GameplayLayoutRoot;

            Engine engine = new Engine();
            CompositionTarget.Rendering += engine.Run;
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
