using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public Player()
        {
            //constructor
        }

        public Player(int cHP, int mHP, int gold, int cEXP) : base(cHP, mHP)
        {
            _gold = gold;
            _currentEXP = cEXP;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        

        //PROPERTIES
        public int Gold
        {
            //Getter for _gold 
            get
            {
                return this._gold;
            }
            //Setter for _gold
            set
            {
                this._gold = value;
            }
        }

        public int CurrentEXP
        {
            //Getter for _currentEXP
            get
            {
                return this._currentEXP;
            }
            //Setter for __currentEXP
            private set
            {
                this._currentEXP = value;
            }
        }

        public int CurrentLevel
        {
            //Getter for _currentLevel
            get
            {
                return (this._currentEXP/100 +1);
            }        
        }

        public Location CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value;
            }
        }

        //METHODS
        public void AddItemToInventory(InventoryItem item)
        {
            bool alreadyHas = false;

            foreach (InventoryItem inventoryItem in Inventory)
            {
                if (inventoryItem.Details.ID == item.Details.ID)
                {
                    inventoryItem.Quantity += item.Quantity;
                    alreadyHas = true;
                    break;
                }
            }

            if (alreadyHas == false)
            {
                Inventory.Add(new InventoryItem(item.Details, item.Quantity));
            }
        }

        public void AddEXP(int expToAdd)
        {
            this.CurrentEXP += expToAdd;
            this.MaxHitPoints = (this.CurrentLevel * 10);
        }

        public void ChangeLocation(CardinalPoint direction)
        {
            switch(direction)
            {
                case CardinalPoint.NORTH:
                    _currentLocation = _currentLocation.LocationToNorth;
                    break;
                case CardinalPoint.SOUTH:
                    _currentLocation = _currentLocation.LocationToSouth;
                    break;
                case CardinalPoint.EAST:
                    _currentLocation = _currentLocation.LocationToEast;
                    break;
                case CardinalPoint.WEST:
                    _currentLocation = _currentLocation.LocationToWest;
                    break;
                default:
                    break;
            }
        }
   
        public void ClaimRewards(Quest quest)
        {
            bool validation;
            PlayerQuest cQuest = GetQuest(quest);

            if (cQuest.IsCompleted == true)
            {
                //give player quest rewards
                _currentEXP += cQuest.Details.RewardEXP;
                _gold += cQuest.Details.RewardGold;

                //give quest item
                validation = false;
                //check if the player has that kind in their inventory
                foreach (InventoryItem inventoryItem in Inventory)
                {
                    //if player has item type increase quantity by 1
                    if (inventoryItem.Details.ID == cQuest.Details.RewardItem.ID)
                    {
                        inventoryItem.Quantity++;
                        validation = true;
                        break;
                    }
                }
                //if item not found add to inventory
                if (validation == false)
                {
                    Inventory.Add(new InventoryItem(cQuest.Details.RewardItem, 1));
                }

            }
        }

        public bool CompleteQuest(Quest quest)
        {
            bool hasQuestItems = HasItems(quest); //HasQuestItems(quest);
            PlayerQuest currentQuest = GetQuest(quest);

            if (hasQuestItems == true)
            {
                //remove quest items from inventory
                RemoveQuestItems(quest);
                //Mark quest as completed
                currentQuest.IsCompleted = true;
            }


            return currentQuest.IsCompleted;
        }

        public int DamageMonster(Monster monster)
        {
            //calculate damage
            int playerDamage = RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);

            //apply damage to monster
            monster.CurrentHitPoints -= playerDamage;

            return playerDamage;
        }

        public Location DestinationInDirection(CardinalPoint direction)
        {
            switch(direction)
            {
                case CardinalPoint.NORTH:
                    return _currentLocation.LocationToNorth;
                case CardinalPoint.SOUTH:
                    return _currentLocation.LocationToSouth;
                case CardinalPoint.EAST:
                    return _currentLocation.LocationToEast;
                case CardinalPoint.WEST:
                    return _currentLocation.LocationToWest;
                default:
                    return _currentLocation;
            }
        }

        public PlayerQuest GetQuest(Quest quest)
        {
            PlayerQuest rQuest = null;

            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    rQuest = playerQuest;
                    return rQuest;
                }
            }

            return null;
        }

        public bool HasQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    //if quest is found return true
                    return true;
                }
            }

            //if no quest is found return false
            return false;
        }

        public bool HasCompletedQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if ((playerQuest.Details.ID == quest.ID) && (playerQuest.IsCompleted == true))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasQuestItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public bool HasItems(Quest quest)
        {
            bool allItemsFound = false;

            foreach (QuestCompletionItem item in quest.QuestCompletionItems)
            {
                allItemsFound = false;

                foreach (InventoryItem inventoryItem in this.Inventory)
                {
                    if (item.Details.ID == inventoryItem.Details.ID)
                    {
                        if (inventoryItem.Quantity >= item.Quantity)
                        {
                            allItemsFound = true;
                            break;
                        }

                    }
                }
            }

            return allItemsFound;

        }

        public bool HasRequiredEntryItem(CardinalPoint direction)
        {
            Location destination = DestinationInDirection(direction);

            if (destination.ItemRequiredToEnter != null)
            {
                //search inventory for item
                foreach (InventoryItem inventoryItem in Inventory)
                {
                    if (inventoryItem.Details.ID == destination.ItemRequiredToEnter.ID)
                    {
                        //if the item is found return true
                        return true;
                    }
                }
            }
            else
            {
                //item is not needed so return true
                return true;
            }

            return false;
        }

        public bool HasRequiredEntryItem(Location destination)
        {
            if (destination.ItemRequiredToEnter != null)
            {
                //search inventory for item
                foreach (InventoryItem inventoryItem in Inventory)
                {
                    if (inventoryItem.Details.ID == destination.ItemRequiredToEnter.ID)
                    {
                        //if the item is found return true
                        return true;
                    }
                }
            }
            else
            {
                //item is not needed so return true
                return true;
            }

            return false;

        }

        public void HealMax()
        {
            this.CurrentHitPoints = this.MaxHitPoints;
        }

        public void Heal(HealingPotion healthPotion)
        {
            //add ammount to current HP
            this.CurrentHitPoints += healthPotion.AmountToHeal;

            //check if health exceeds max
            if (this.CurrentHitPoints > this.MaxHitPoints)
            {
                //if it exceeds the max, set to max
                this.CurrentHitPoints = this.MaxHitPoints;
            }
        }

        public List<InventoryItem> LootMonster(Monster monster)
        {
            List<InventoryItem> lootedItems = new List<InventoryItem>();  //holds looted items

            //reward EXP
            this.AddEXP(monster.RewardEXP);

            //reward Gold
            this.Gold += monster.RewardGold;

            //give loot items

            foreach (LootItem lootItem in monster.LootTable)
            {
                if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                }
            }

            //if no items were dropped: give default item
            if (lootedItems.Count == 0)
            {
                foreach (LootItem lootItem in monster.LootTable)
                {
                    if (lootItem.IsDefaultItem == true)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }
            }

            //add loot to player inventory
            foreach (InventoryItem lootItem in lootedItems)
            {
                //_player.Inventory.Add(lootItem.Details);
                this.AddItemToInventory(lootItem);
            }

            return lootedItems;
        }

        private void RemoveQuestItems(Quest quest)
        {
            PlayerQuest currentQuest = GetQuest(quest);

            //remove quest items from inventory
            foreach (QuestCompletionItem questItem in currentQuest.Details.QuestCompletionItems)
            {
                foreach (InventoryItem item in Inventory)
                {
                    if (item.Details.ID == questItem.Details.ID)
                    {
                        item.Quantity -= questItem.Quantity;
                        break;
                    }
                }
            }
        }


        public void RemoveItemFromInventory(Item removalItem)
        {
            foreach(InventoryItem inventoryItem in this.Inventory)
            {
                if(inventoryItem.Details.ID==removalItem.ID)
                {
                    inventoryItem.Quantity--;
                    break;
                }
            }
        }
      

      
        //Member Variables
        private int _gold;
        private int _currentEXP;
        //private int _currentLevel;
        private Location _currentLocation;
        public Weapon CurrentWeapon;
        
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
    }
}
