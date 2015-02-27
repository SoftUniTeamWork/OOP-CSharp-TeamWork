namespace The_Powerful_Game.Contracts
{
    using Entities;

    interface IControllable
    {
        void Move();

        void Flee(Enemy enemy);
    }
}
