namespace The_Powerful_Game.Contracts
{
    using The_Powerful_Game.Entities;

    interface IControllable
    {
        void Move();

        void Flee(Enemy enemy);
    }
}
