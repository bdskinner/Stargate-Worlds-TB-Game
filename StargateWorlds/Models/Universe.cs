using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all space-time locations
        //
        private List<World> _worlds;

        public List<World> Worlds
        {
            get { return _worlds; }
            set { _worlds = value; }
        }

        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // add all of the universe objects to the game
            // 
            IntializeUniverse();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverse()
        {
            _worlds = UniverseObjects.Worlds as List<World>;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// get a SpaceTimeLocation object using an ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public World GetWorldByID(string ID)
        {
            World worldLocation = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (World location in _worlds)
            {
                if (location.PlanetDesignation == ID)
                {
                    worldLocation = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (worldLocation == null)
            {
                string feedbackMessage = $"The planet {ID} does not exist in the current Universe.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return worldLocation;
        }

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="spaceTimeLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(string planetDesignation)
        {
            World world = GetWorldByID(planetDesignation);
            if (world.Accessable == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the planet designation provided to make sure it is valid.
        /// </summary>
        /// <param name="planetDesignation"></param>
        /// <returns></returns>
        public bool IsValidPlanetDesignation(string planetDesignation)
        {
            List<string> planeetDesignations = new List<string>();

            //
            // create a list of space-time location ids
            //
            foreach (World stl in _worlds)
            {
                planeetDesignations.Add(stl.PlanetDesignation);
            }

            //
            // determine if the space-time location id is a valid id and return the result
            //
            if (planeetDesignations.Contains(planetDesignation))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Changes whether or not a specific planet is accessible to the player.
        /// </summary>
        /// <param name="planetDesignation"></param>
        public void SetPlanetAccessibility(string planetDesignation)
        {

        }

        #endregion
    }
}
