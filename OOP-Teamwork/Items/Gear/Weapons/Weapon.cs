﻿namespace OOP_Teamwork.Items.Gear.Weapons
{
    using System;
    using System.Linq;

    public abstract class Weapon : GearItem
    {
        // Fields
        private int minDamage;
        private int maxDamage;

        // Constructors
        protected Weapon(string name, int sellPrice, int minDmg, int maxDmg)
            : base(name, sellPrice)
        {
            this.MinimalDamage = minDmg;
            this.MaximalDamage = maxDmg;
        }
        
        // Properties
        public int MinimalDamage { get; set; }
        public int MaximalDamage { get; set; }

        // Methods
        public override void Equip()
        {
            // player.MinDamage += this.MinimalDamage;
            // player.MaxDamage += this.MaximalDamage;
        }

        public override void Unequip()
        {
            // player.MinDamage -= this.MinimalDamage;
            // player.MaxDamage -= this.MaximalDamage;
        }
    }
}
