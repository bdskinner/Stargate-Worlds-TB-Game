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
            None,
            VeryGood,
            Good,
            Moderate,
            Poor,
            VeryPoor,
            Dead
        }

        #endregion

        #region FIELDS

        private string _currentPlanet;
        private int _goldCoins;
        private TravelerHealth _health;
        private bool _isQuick;
        private string _rank;
        
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

        #endregion
        
        #region CONSTRUCTORS

        public Traveler()
        {

        }

        public Traveler(string rank)
        {
            _rank = rank;
            _health = TravelerHealth.VeryGood;
            _goldCoins = 10;
        }

        #endregion

        #region METHODS

        public override void Attack()
        {
            Console.WriteLine("The traveler is attacking the enemy.");
        }

        public override void Run()
        {
            Console.WriteLine("The traveler is running.");
        }

        public override void Walk()
        {
            Console.WriteLine("The traveler is walking.");
        }

        #endregion
    }
}
