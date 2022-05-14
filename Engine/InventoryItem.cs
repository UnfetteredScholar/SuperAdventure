using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class InventoryItem
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public InventoryItem(Item details, int quantity)
        {
            _details = details;
            _quantity = quantity;
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
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        //PRIVATE 
        private Item _details;
        private int _quantity;
    }
}
