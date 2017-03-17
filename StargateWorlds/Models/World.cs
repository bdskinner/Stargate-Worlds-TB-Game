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
        private string _universalLocation;


        //private int _universalDate;
        //private int _experiencePoints;

        #endregion

        #region PROPERTIES

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public string PlanetDesignation
        {
            get { return _planetDesignation; }
            set { _planetDesignation = value; }
        }

        public string UniversalLocation
        {
            get { return _universalLocation; }
            set { _universalLocation = value; }
        }





        //public int UniversalDate
        //{
        //    get { return _universalDate; }
        //    set { _universalDate = value; }
        //}

        //public int ExperiencePoints
        //{
        //    get { return _experiencePoints; }
        //    set { _experiencePoints = value; }
        //}

        #endregion

        #region CONSTRUCTORS



        #endregion

        #region METHODS

        

        #endregion


    }
}
