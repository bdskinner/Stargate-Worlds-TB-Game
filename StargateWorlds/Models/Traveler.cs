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
            MajorInjury = -3,
            ModerateInjury = -2,
            MinorInjury = -1,
            FullHealing = 3,
            PartialHealing = 2
        }

        #endregion

        #region FIELDS

        private string _currentPlanet;
        private int _goldCoins;
        private TravelerHealth _health;
        private bool _isOnNewWorld;
        private bool _isQuick;
        private string _rank;
        private List<TravelerObject> _travelerInventory;
        private Dictionary<string, string> _worldsVisited;
        
        #endregion

        #region PROPERTIES

        public string CurrentPlanet
        {
            get { return _currentPlanet; }
            set { _currentPlanet = value; }
        }

        public int GoldCoins
        {
            get { return _goldCoins; }
            set { _goldCoins = value; }
        }

        public TravelerHealth Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public bool IsOnNewWorld
        {
            get { return _isOnNewWorld; }
            set { _isOnNewWorld = value; }
        }

        public bool IsQuick
        {
            get { return _isQuick; }
            set { _isQuick = value; }
        }

        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public List<TravelerObject> TravelerInventory
        {
            get { return _travelerInventory; }
            set { _travelerInventory = value; }
        }

        public Dictionary<string, string> WorldsVisited
        {
            get { return _worldsVisited; }
            //set { _worldsVisited = value; }
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
