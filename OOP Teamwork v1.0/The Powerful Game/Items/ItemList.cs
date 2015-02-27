namespace The_Powerful_Game.Items
{
    using System.Collections.Generic;
    using Enums;

    public static class ItemList
    {
        public static readonly List<Item> EquipableItems = new List<Item>()
        {
            new Weapon("Crownsmasher", ItemType.Weapon, 200, 5, 0, 0, 20),
            new Weapon("Extermination", ItemType.Weapon, 225, 3, 0, 2, 15),
            new Weapon("The Needle", ItemType.Weapon, 125, 2, 0, 5, 15),
            new Weapon("Goliat", ItemType.Weapon, 150, 2, 2, 2, 5),
            new Weapon("The Zealot", ItemType.Weapon, 175, 0, 2, 7, 10),
            new Weapon("Smugler", ItemType.Weapon, 150, 0, 4, 4, 5),

            new Armor("Kings crown", ItemType.Armor, 150, 2, 1, 0, 5),
            new Armor("Heavy Platemail", ItemType.Armor, 250, 5, 0, 0, 7),
            new Armor("Metal boots", ItemType.Armor, 125, 0, 0, 2, 3),
            new Armor("Chainmail pants", ItemType.Armor, 200, 1, 1, 1, 4),
            new Armor("Leather belt", ItemType.Armor, 125, 0, 0, 1, 3),
            new Armor("Glorious shoulderpads", ItemType.Armor, 200, 1, 0, 0, 4),
        };

        public static readonly List<Item> ConsumableItems = new List<Item>()
        {
            new HealthPotion("Health Potion", ItemType.Consumable, 20, 100),
            new ResourcePotion("Resource Potion", ItemType.Consumable, 20, 75),
        };
    }
}
