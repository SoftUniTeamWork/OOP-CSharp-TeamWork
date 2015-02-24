using System.Windows.Controls;
using The_Powerful_Game.Entities.Chooses;

namespace The_Powerful_Game.Entities
{
    public class Mage : Character
    {
        public Mage(string name, double x, double y, AttributePair healthPoints, 
            int armorPoints, int damage, Image image, int strength,
            int inteligence, int agility, int resourcePoints, EntityResourceType resourceType)
            : base(name, x, y, healthPoints, armorPoints, damage, image,
            strength, inteligence, agility, resourcePoints, resourceType)
        {
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void Render()
        {
            throw new System.NotImplementedException();
        }
    }
}