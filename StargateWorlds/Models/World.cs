using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// class for the game map locations
    /// </summary>
    public class World
    {
        #region FIELDS

        private bool _accessable;
        private string _commonName;
        private string _description;
        private string _generalContents;
        private string _planetDesignation; // must be a unique value for each object
        private Dictionary<int, bool> _requiredObjects = new Dictionary<int, bool>(); //key = object ID, value = is the game object in inventory(true/false).  Objects(s) required to get this world.
        private string _universalLocation;
        private bool _visible;   //Determines whether the world is visible in the list of worlds displayed when the traveler chooses the "Travel" option from the Travel Menu.
        
        #endregion

        #region PROPERTIES

        public bool Accessable   //Determines whether the world is accessible to the traveler.
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public string CommonName   //The commonly used name of the world.
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public string Description   //A brief description of the world.
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents   //A brief description of what the traveler sees on the world.
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public string PlanetDesignation   //The stargate address of the world.
        {
            get { return _planetDesignation; }
            set { _planetDesignation = value; }
        }

        public Dictionary<int, bool> RequiredObjects   //Required objects to access the world.  Key = game object ID, Value = if the object is in the traveler's inventory(true/false).
        {
            get { return _requiredObjects; }
            set { _requiredObjects = value; }
        }

        public string UniversalLocation   //Cosmological reference to the world from Gregorian star charts.
        {
            get { return _universalLocation; }
            set { _universalLocation = value; }
        }

        public bool Visible   //Determines whether the world is visible on the list that is displayed when the player user "Travel" action in the Travel Menu.
        {
            get { return _visible; }
            set { _visible = value; }
        }

        #endregion

        #region CONSTRUCTORS



        #endregion

        #region METHODS



        #endregion
    }
}
