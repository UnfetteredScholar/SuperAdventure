using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HealingPotion : Item 
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public HealingPotion()
        {
            //constructor
        }

        public HealingPotion(int id, string name, string namePlural, int amountHeal) :base(id, name, namePlural)
        {
            //ID = id;
            //Name = name;
            //NamePlural = namePlural;
            _amountToHeal = amountHeal;
        }

        //PUBLIC      
        public int AmountToHeal
        {
            get
            {
                return this._amountToHeal;
            }
            set
            {
                this._amountToHeal = value;
            }
        }

        //PRIVATE
        private int _amountToHeal;
    }
}


/*
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

        public string NamePlural
        {
            get
            {
                return this._namePlural;
            }
            set
            {
                this._namePlural = value;
            }
        }

 */