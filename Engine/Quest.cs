using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public Quest()
        {
            //constructor
        }

        public Quest(int id, string name, string description, int exp, int gold)
        {
            _ID = id;
            _name = name;
            _description = description;
            _rewardEXP = exp;
            _rewardGold = gold;
            QuestCompletionItems = new List<QuestCompletionItem>();
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

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
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

        public Item RewardItem
        {
            get
            {
                return _rewardItem;
            }
            set
            {
                _rewardItem = value;
            }
        }



        //PRIVATE
        private int _ID;
        private string _name;
        private string _description;
        private int _rewardEXP;
        private int _rewardGold;
        private Item _rewardItem;

        public List<QuestCompletionItem> QuestCompletionItems { get; set; }
    }
}
