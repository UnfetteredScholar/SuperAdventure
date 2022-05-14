using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LivingCreature
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public LivingCreature()
        {
            //constructor
        }

        public LivingCreature(int cHP, int mHP)
        {
            _currentHP = cHP;
            _maxHP = mHP;
        }

        public int CurrentHitPoints
        {
            //Getter for _currentHP 
            get
            {
                return this._currentHP;
            }
            //Setter for _currentHP
            set
            {
                this._currentHP = value;
            }
        }

        public int MaxHitPoints
        {
            //Getter for _maxHP 
            get
            {
                return this._maxHP;
            }
            //Setter for _maxHP
            set
            {
                this._maxHP = value;
            }
        }

        //PRIVATE 
        private int _currentHP;
        private int _maxHP;
    }
}
