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
        private string _currentPlanet;
        private string _firstName;
        private HeightLevel _height;
        private bool _isLucky;
        private string _lastName;

        #endregion

        #region PROPERTIES

        public int Age   //The age of the traveler.
        {
            get { return _age; }
            set { _age = value; }
        }
        
        public string CurrentPlanet   //The world the traveler is currently on.
        {
            get { return _currentPlanet; }
            set { _currentPlanet = value; }
        }
        
        public string FirstName   //The traveler's first name.
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public HeightLevel Height   //The traveler's height.
        {
            get { return _height; }
            set { _height = value; }
        }

        public bool IsLucky   //Determines whether the traveler is lucky or not.
        {
            get { return _isLucky; }
            set { _isLucky = value; }
        }

        public string LastName   //The traveler's last name.
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

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
