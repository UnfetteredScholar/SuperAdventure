using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum CardinalPoint { NORTH, SOUTH, EAST, WEST};

    public class Location
    {
        //CONSTRUCTOR AND DESTRUCTOR
        public Location()
        {
            //constructor 
        }

        public Location(int id, string name, string description, Item itemRequiredtoEnter=null, Quest availableQuest=null, Monster residentMonster=null)
        {
            _ID = id;
            _name = name;
            _description = description;
            _itemRequiredToEnter = itemRequiredtoEnter;
            _questAvailableHere = availableQuest;
            _monsterLivingHere = residentMonster;
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

        public Item ItemRequiredToEnter
        {
            get
            {
                return _itemRequiredToEnter;
            }
            set
            {
                _itemRequiredToEnter = value;
            }
        }

        public Quest QuestAvailableHere
        {
            get
            {
                return _questAvailableHere;
            }
            set
            {
                _questAvailableHere = value;
            }
        }

        public Monster MonsterLivingHere
        {
            get
            {
                return _monsterLivingHere;
            }
            set
            {
                _monsterLivingHere = value;
            }
        }

        public Location LocationToNorth
        {
            get
            {
                return _locationToNorth;
            }
            set
            {
                _locationToNorth = value;
            }
        }

        public Location LocationToEast
        {
            get
            {
                return _locationToEast;
            }
            set
            {
                _locationToEast = value;
            }
        }

        public Location LocationToSouth
        {
            get
            {
                return _locationToSouth;
            }
            set
            {
                _locationToSouth = value;
            }
        }

        public Location LocationToWest
        {
            get
            {
                return _locationToWest;
            }
            set
            {
                _locationToWest = value;
            }
        }


        //PRIVATE
        private int _ID;
        private string _name;
        private string _description;

        private Item _itemRequiredToEnter;
        private Quest _questAvailableHere;
        private Monster _monsterLivingHere;
        private Location _locationToNorth;
        private Location _locationToEast;
        private Location _locationToSouth;
        private Location _locationToWest;

    }
}
