namespace The_Powerful_Game
{
    using System.Windows.Controls;
    using The_Powerful_Game.Menu;

    public static class Switcher
    {
        public static PageSwitcher PageSwitcher;

        public static void Switch(UserControl newPage)
        {
            PageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            PageSwitcher.Navigate(newPage, state);
        }
    }
}
