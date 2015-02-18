using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Chooses;

namespace The_Powerful_Game.Entities.Chooses
{
    class Player : Entity
    {
        private int resoursePoints;
        private EntityResourceType resourceType;

        public Player(string name, int hitPts, int armor, int entityDamage, double attackSpeed, int resoursePts, EntityResourceType resourceType)
            : base(name, hitPts, armor, entityDamage, attackSpeed)
        {
            this.ResoursePoints = resoursePts;
            this.ResourceType = resourceType;
        }
        public int ResoursePoints { get; set; }
        public EntityResourceType ResourceType { get; set; }
    }
}
