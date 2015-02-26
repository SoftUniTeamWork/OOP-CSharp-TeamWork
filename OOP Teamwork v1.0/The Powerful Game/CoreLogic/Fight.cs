namespace The_Powerful_Game.CoreLogic
{
    using System;
    using The_Powerful_Game.Items;
    using System.Windows.Media;
    using The_Powerful_Game.Menu;
    using The_Powerful_Game.Entities;
    using MessageBox = System.Windows.MessageBox;

    public class Fight
    {
        public Fight(Character player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            this.PlayerTookTurn = false;
        }

        private Character Player { get; set; }

        private Enemy Enemy { get; set; }

        public bool PlayerTookTurn { get; private set; }

        public string EnemyTurn()
        {
            string combatLogResult = this.Enemy.Attack(this.Player);
            PlayerDeadCheck();
            FightOverCheck();
            return combatLogResult;
        }

        public string PlayerTurn(string choice)
        {
            string combatLogResult = "";

            switch (choice)
            {
                case "Attack":
                    combatLogResult = this.Player.Attack(this.Enemy);
                    break;
                case "Offensive Skill":
                    combatLogResult = this.Player.CastOffensiveSpell(this.Enemy);
                    break;
                case "Deffensive Skill":
                    combatLogResult = this.Player.CastDeffensiveSpell(this.Enemy);
                    break;
            }

            this.PlayerTookTurn = !string.IsNullOrEmpty(combatLogResult);
            FightOverCheck();

            return combatLogResult;
        }

        private void PlayerDeadCheck()
        {
            if (this.Player.HealthPoints.CurrentValue == 0)
            {
                MessageBox.Show("You died!");
                Switcher.Switch(Gameplay.Control);
            }
        }

        private void FightOverCheck()
        {
            if (this.Enemy.Fled)
            {
                MessageBox.Show("The enemy fled the battlefield like a coward.\n");
                this.Enemy.isAlive = false;
                this.Enemy.Update();
                CompositionTarget.Rendering += Gameplay.MainEngine.Run;
                Switcher.Switch(Gameplay.Control);

                if (this.Player is Mage)
                {
                    this.Player.RegenerateResource();
                }
            }
            else if (this.Enemy.HealthPoints.CurrentValue == 0)
            {
                MessageBox.Show("Glorious Victory!");
                this.Enemy.isAlive = false;
                this.Enemy.Update();
                this.Player.EquipItem(this.DropItem());

                CompositionTarget.Rendering += Gameplay.MainEngine.Run;
                Switcher.Switch(Gameplay.Control);

                if (this.Player is Mage)
                {
                    this.Player.RegenerateResource();
                }
            }
        }

        private Item DropItem()
        {
            Item droppedItem = null;
            if (this.Player.Inventory.Count < 6)
            {
                Random itemRandomizer = new Random();
                int gearOrConsumable = itemRandomizer.Next(0, 100);

                if (gearOrConsumable < 30)
                {
                    int weaponOrGear = itemRandomizer.Next(0, 100);
                    if (weaponOrGear > 50)
                    {
                        droppedItem = ItemList.EquipableItems[itemRandomizer.Next(6, ItemList.EquipableItems.Count + 1)];
                    }
                    else
                    {
                        droppedItem = ItemList.EquipableItems[itemRandomizer.Next(0, (ItemList.EquipableItems.Count / 2) + 1)];
                    }

                    ItemList.EquipableItems.Remove(droppedItem);
                    MessageBox.Show(string.Format("The enemy dropped {0} - {1}.", droppedItem.Type, droppedItem.Name));
                }
                else if (gearOrConsumable >= 30 && gearOrConsumable < 80)
                {
                    droppedItem = ItemList.ConsumableItems[itemRandomizer.Next(0, ItemList.ConsumableItems.Count)];
                    MessageBox.Show(string.Format("The enemy dropped {0}.", droppedItem.Name));
                }
            }

            return droppedItem;
        }
    }
}
