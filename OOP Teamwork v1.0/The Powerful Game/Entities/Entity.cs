using System;
using System.Text;
using Entities.Chooses;
using Validations;

namespace Entities
{
    public abstract class Entity
    {
        private string entityName;
        private EntityResourceType entityResource;
        private int entityDamage;

        /// <summary>
        /// This constructor is parental with several data. Name, Resource, Damage. Data is completely validated.
        /// </summary>
        /// <param name="entityName">This will be Player, Enemy or Non-Enemy Creature name.</param>
        /// <param name="entityResource">This will be the Entity resouce of type: Mana, Energy, Rage or whatever.</param>
        /// <param name="entityDamage">This is damage that creature will be took. It will be calculate in method CalcDamage. Read more at CalcDamage method.</param>
        public Entity(string entityName, EntityResourceType entityResource, int entityDamage)
        {
            this.EntityName = entityName;
            this.EntityResource = entityResource;
            this.EntityDamage = entityDamage;
        }

        public virtual string EntityName
        {
            get { return this.entityName; }
            set { this.entityName = EntityValidator.NameValidating(value); }
        }

        public virtual EntityResourceType EntityResource
        {
            get { return this.entityResource; }
            set { this.entityResource = value; }
        }

        public int EntityDamage
        {
            get { return this.entityDamage; }
            set { this.entityDamage = EntityValidator.DamageValidating(value); }
        }

        /// <summary>
        /// Converts Entity to string.
        /// </summary>
        /// <returns>By default returns Enemy name, enemy resource type and average damage.</returns>
        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendLine("Entity with name " + this.entityName);
            toString.AppendLine("Entity uses " + this.entityResource);
            toString.AppendLine("Entity average damage is " + this.entityDamage);

            return toString.ToString();
        }

        /// <summary>
        /// This method calculates damage range. Formula by default is current entity damage divide by 2 bottom border, entity damage mulriplicate by 2 upper border. 
        /// </summary>
        /// <returns>Returns random damage to be taken</returns>
        protected virtual int CalcDamage()
        {
            Random getDamage = new Random();
            int minDmgFormula = this.EntityDamage >> 1; //Equals to divide. E.g. 10/2 == 10 >> 1. This is twice faster than dividing.
            int maxDmgFormula = this.EntityDamage << 1; //Example 10 * 2 == 10 << 1; Twice faster than multiplication.
            int damageDone = getDamage.Next(minDmgFormula, maxDmgFormula);
            return 0;
        }

        /// <summary>
        /// This method takes damage that Entity done. 
        /// </summary>
        /// <returns>Returns damage taken</returns>
        public abstract int DamageDone();
    }
}
