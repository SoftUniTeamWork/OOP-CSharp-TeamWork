using The_Powerful_Game.Enums;

namespace The_Powerful_Game.Items
{
    using System.Collections.Generic;

    public static class ItemList
    {
        public static readonly List<Item> EquipableItems = new List<Item>()
        {
            new Weapon("Crownsmasher", ItemType.Weapon, 200, 250, 0, 0, 0),
            new Weapon("Extermination", ItemType.Weapon, 225, 30, 0, 0, 0),
            new Weapon("The Needle", ItemType.Weapon, 125, 10, 0, 0, 0),
            new Weapon("Goliat", ItemType.Weapon, 150, 12, 0, 0, 0),
            new Weapon("The Zealot", ItemType.Weapon, 175, 18, 0, 0, 0),
            new Weapon("Smugler", ItemType.Weapon, 150, 15, 0, 0, 0),

            new Armor("Kings crown", ItemType.Armor, 150, 15, 0, 0, 0),
            new Armor("Heavy Platemail", ItemType.Armor, 250, 25, 0, 0, 0),
            new Armor("Metal boots", ItemType.Armor, 125, 12, 0, 0, 0),
            new Armor("Chainmail pants", ItemType.Armor, 200, 20, 0, 0, 0),
            new Armor("Leather belt", ItemType.Armor, 125, 10, 0, 0, 0),
            new Armor("Glorious shoulderpads", ItemType.Armor, 200, 18, 0, 0, 0),
        };

        public static readonly List<Item> ConsumableItems = new List<Item>()
        {
            new HealthPotion("Health Potion", ItemType.Consumable, 20, 100),
            new ResourcePotion("Resource Potion", ItemType.Consumable, 20, 75),
        };
    }
}
