using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Traveler : Character
    {
        #region ENUMERABLES

        public enum TravelerHealth
        {
            None = 0,
            VeryGood = 6,
            Good = 5,
            Moderate = 4,
            Poor = 3,
            VeryPoor = 2,
            Dead = 1
        }

        public enum HealthChange
        {
            None = 0,
            MajorInjury = -3,
            ModerateInjury = -2,
            MinorInjury = -1,
            FullHealing = 3,
            PartialHealing = 2
        }

        #endregion

        #region FIELDS

        //private string _currentPlanet;
        private int _goldCoins;
        private TravelerHealth _health;
        private bool _isOnNewWorld;
        private bool _isQuick;
        private string _rank;
        private List<TravelerObject> _travelerInventory;
        private Dictionary<string, string> _worldsVisited;
        
        #endregion

        #region PROPERTIES

        public int GoldCoins   //The amount of money (in gold coins) that the traveler has on hand.
        {
            get { return _goldCoins; }
            set { _goldCoins = value; }
        }

        public TravelerHealth Health   //The traveler's current health status.
        {
            get { return _health; }
            set { _health = value; }
        }

        public bool IsOnNewWorld   //Is true when the travels changes worlds.
        {
            get { return _isOnNewWorld; }
            set { _isOnNewWorld = value; }
        }

        public bool IsQuick   //Determines whether or not the traveler is quick.
        {
            get { return _isQuick; }
            set { _isQuick = value; }
        }

        public string Rank   //The traveler's military rank.
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public List<TravelerObject> TravelerInventory   //A list of objects the traveler has in their possession.
        {
            get { return _travelerInventory; }
            set { _travelerInventory = value; }
        }

        public Dictionary<string, string> WorldsVisited   //A list of the worlds the traveler has visited (Will not contain any duplicate values).
        {
            get { return _worldsVisited; }
        }

        #endregion

        #region CONSTRUCTORS

        public Traveler()
        {
            _health = TravelerHealth.VeryGood;
            _goldCoins = 10;
            _travelerInventory = new List<TravelerObject>();
            _worldsVisited = new Dictionary<string, string>();
        }

        public Traveler(string rank)
        {
            _rank = rank;
            _health = TravelerHealth.VeryGood;
            _goldCoins = 10;
            _travelerInventory = new List<TravelerObject>();
            _worldsVisited = new Dictionary<string, string>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Adds the planet designation and common name to the WorldsVisied dictionary class.
        /// </summary>
        /// <param name="planetDesignation"></param>
        /// <param name="commonName"></param>
        public void AddVisitedWorld(string planetDesignation, string commonName)
        {
            //Check the existing list to see if the world has already been added.
            if(!_worldsVisited.Keys.Contains(planetDesignation) || _worldsVisited == null)
            {
                //Add the values to the list of visited worlds.
                _worldsVisited.Add(planetDesignation, commonName);
            }
        }
        
        public override void Attack()
        {
            Console.WriteLine("The traveler is attacking the enemy.");
        }

        /// <summary>
        /// Determines whether or not the traveler has enough currency to buy a game object.
        /// </summary>
        /// <param name="objectValue"></param>
        /// <returns></returns>
        public bool IsEnoughCurrency(int objectValue)
        {
            //Compare the game object's value with the currency the traveler has.
            if (_goldCoins >= objectValue)
            {
                //Enough to buy...
                return true;
            }
            else
            {
                //Not enough to buy...
                return false;
            }
        }

        public override void Run()
        {
            Console.WriteLine("The traveler is running.");
        }

        /// <summary>
        /// Updates the traveler's health based on whether the change presented.
        /// </summary>
        /// <param name="healthChange"></param>
        public void UpdateTravelerHealth(HealthChange healthChange)
        {
            //Add the index value of the health change to the traveler's health (Injuries add a negative int, healing = adds a positive int).
            _health += (int)healthChange;

            //Check the upper and lower bounds of the traveler's health to make sure it is in range.
            if ((int)_health <= (int)TravelerHealth.Dead) _health = TravelerHealth.Dead;
            if ((int)_health >= (int)TravelerHealth.VeryGood) _health = TravelerHealth.VeryGood;
        }

        public override void Walk()
        {
            Console.WriteLine("The traveler is walking.");
        }

        #endregion
    }
}
