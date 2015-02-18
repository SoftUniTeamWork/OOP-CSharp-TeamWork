using OOP_Teamwork.Items.Gear.Weapons;

namespace OOP_Teamwork
{
    public abstract class RangedWeapon : Weapon
    {
        // Fields
        // Constructors
        // Properties
        // Methods
        protected RangedWeapon(string name, int sellPrice, int minDmg, int maxDmg) : base(name, sellPrice, minDmg, maxDmg)
        {
        }
    }
}
