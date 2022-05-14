using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class PlayerQuest
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public PlayerQuest(Quest details)
        {
            _details = details;
            _isCompleted = false;
        }

        //PUBLIC
        public Quest Details
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

        public bool IsCompleted 
        {
            get
            {
                return _isCompleted;
            }
            set
            {
                _isCompleted = value;
            }
        }

        //PRIVATE
        private Quest _details;
        private bool _isCompleted;
    }
}
