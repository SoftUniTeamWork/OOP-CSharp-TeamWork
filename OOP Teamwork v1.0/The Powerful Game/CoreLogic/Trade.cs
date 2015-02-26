using The_Powerful_Game.Entities;

namespace The_Powerful_Game.CoreLogic
{
    public class Trade
    {
        public Trade(Character player, Merchant merchant)
        {
            this.Player = player;
            this.Merchant = merchant;
        }

        public Character Player { get; set; }

        public Merchant Merchant { get; set; }

    }
}
