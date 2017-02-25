using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum HeightLevel
        {
            None,
            Tall,
            Average,
            Short
        }

        #endregion

        #region FIELDS

        private int _age; 
        private string _firstName;
        private HeightLevel _height;
        private bool _isLucky;
        private string _lastName;

        #endregion

        #region PROPERTIES

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public HeightLevel Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public bool IsLucky
        {
            get { return _isLucky; }
            set { _isLucky = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        //public Character(string name, RaceType race, int spaceTimeLocationID)
        //{
        //    _name = name;
        //    _race = race;
        //    _spaceTimeLocationID = spaceTimeLocationID;
        //}

        public Character(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        #endregion

        #region METHODS

        public virtual void Attack()
        {
            Console.WriteLine("The character is attacking the enemy.");
        }

        public virtual void Run()
        {
            Console.WriteLine("The character is running.");
        }

        public virtual void Walk()
        {
            Console.WriteLine("The character is walking.");
        }

        #endregion
    }
}
