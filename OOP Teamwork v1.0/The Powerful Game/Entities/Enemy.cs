using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Powerful_Game.Entities
{
    class Enemy : Entity
    {
        public Enemy(string name, int hitPts, int armor, int entityDamage, double attackSpeed) 
            : base(name, hitPts, armor, entityDamage, attackSpeed)
        {
        }
    }
}
