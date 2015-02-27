namespace The_Powerful_Game.Contracts
{
    using Entities;

    public interface IControllable
    {
        void Move();

        void Flee(Enemy enemy);
    }
}
