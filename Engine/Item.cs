using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public Item()
        {
            //constructor
        }

        public Item(int id, string name, string namePlural)
        {
            _ID = id;
            _name = name;
            _namePlural = namePlural;
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

        //PRIVATE
        private int _ID;
        private string _name;
        private string _namePlural;
    }
}
