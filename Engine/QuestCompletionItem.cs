using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestCompletionItem
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public QuestCompletionItem(Item details, int quantity)
        {
            _details = details;
            _quantity = quantity;
        }


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
