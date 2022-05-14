using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public Weapon()
        {
            //constructor 
        }

        public Weapon(int id, string name, string namePlural, int minDamage, int maxDamage):base(id,name,namePlural)
        {
            _minimumDamage = minDamage;
            _maximumDamage = maxDamage;
        }

        //PUBLIC
        public int MinimumDamage
        {
            get
            {
                return this._minimumDamage;
            }
            set
            {
                this._minimumDamage = value;
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

        //PRIVATE
        private int _minimumDamage;
        private int _maximumDamage;
            
    }
}
