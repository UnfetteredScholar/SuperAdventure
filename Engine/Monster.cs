using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : LivingCreature
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public Monster()
        {
            //constructor
        }

        public Monster(int id, string name, int maxDamage, int rewardEXP, int rewardGold, int cHP, int mHP): base(cHP, mHP)
        {
            _ID=id;
            _name=name;
            _maximumDamage=maxDamage;
            _rewardEXP=rewardEXP;
            _rewardGold=rewardGold;
            LootTable = new List<LootItem>();
        }

        //PUBLIC
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public int MaximumDamage
        {
            get
            {
                return this._maximumDamage;
            }
            set
            {
                this._maximumDamage = value;
            }
        }

        public int RewardEXP
        {
            get
            {
                return this._rewardEXP;
            }
            set
            {
                this._rewardEXP = value;
            }
        }

        public int RewardGold
        {
            get
            {
                return this._rewardGold;
            }
            set
            {
                this._rewardGold = value;
            }
        }

        public int LastDamage
        {
            get
            {
                return this._lastDamage;
            }
            set
            {
                this._lastDamage = value;
            }
        }

        public void DamagePlayer(Player player)
        {
            int monsterDamage = 0;
           
            //calculate damage
            monsterDamage = RandomNumberGenerator.NumberBetween(0, this._maximumDamage);
            _lastDamage = monsterDamage;

            //reduce player's health
            player.CurrentHitPoints -= monsterDamage;
        }

        //PRIVATE
        private int _ID;
        private string _name;
        private int _maximumDamage;
        private int _rewardEXP;
        private int _rewardGold;
        private int _lastDamage;

        public List<LootItem> LootTable { get; set; }
    }
}
