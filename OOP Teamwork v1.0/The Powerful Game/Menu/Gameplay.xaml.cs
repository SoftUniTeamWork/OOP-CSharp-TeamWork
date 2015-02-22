namespace The_Powerful_Game.Menu
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using The_Powerful_Game.CoreLogic;

    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : UserControl, ISwitchable
    {
        public static Canvas Root { get;private set; }

        public static Engine MainEngine { get; private set; }

        public static UserControl Control { get; private set; }

        public Gameplay()
        {
            InitializeComponent();

            Control = this;
            Root = GameplayLayoutRoot;
            MainEngine = new Engine();

            CompositionTarget.Rendering += Gameplay.MainEngine.Run;
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
