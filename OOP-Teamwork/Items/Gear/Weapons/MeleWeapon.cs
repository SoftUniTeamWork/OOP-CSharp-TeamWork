using OOP_Teamwork.Items.Gear.Weapons;

namespace OOP_Teamwork
{
    public abstract class MeleWeapon : Weapon
    {
        // Fields
        // Constructors
        // Properties
        // Methods
        protected MeleWeapon(string name, int sellPrice, int minDmg, int maxDmg) : base(name, sellPrice, minDmg, maxDmg)
        {
        }
    }
}
