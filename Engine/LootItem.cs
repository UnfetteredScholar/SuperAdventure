using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public LootItem(Item details, int dropPercentage, bool isDefaultItem)
        {
            _details = details;
            _dropPercentage = dropPercentage;
            _isDefaultItem = isDefaultItem;
        }


        //PUBLIC
        public Item Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
            }
        }

        public int DropPercentage
        {
            get
            {
                return _dropPercentage;
            }
            set
            {
                _dropPercentage = value;
            }
        }

        public bool IsDefaultItem
        {
            get
            {
                return _isDefaultItem;
            }
            set
            {
                _isDefaultItem = value;
            }
        }

        //PRIVATE
        private Item _details;
        private int _dropPercentage;
        private bool _isDefaultItem;
    }
}
