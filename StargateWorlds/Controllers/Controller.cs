using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Universe _gameUniverse;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameTraveler = new Traveler();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);
            _playingGame = true;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// initialize the player info.
        /// </summary>
        private void InitializeMission()
        {
            //Variable Declarations.
            Traveler traveler = _gameConsoleView.GetInitialTravelerInfo();

            //Set the traveler info. entered by the user to the appropriate property.
            _gameTraveler.FirstName = traveler.FirstName;
            _gameTraveler.LastName = traveler.LastName;
            _gameTraveler.Age = traveler.Age;

            _gameTraveler.Height = traveler.Height;
            _gameTraveler.CurrentPlanet = traveler.CurrentPlanet;

            _gameTraveler.Rank = traveler.Rank;
            _gameTraveler.Health = traveler.Health;
            _gameTraveler.GoldCoins = traveler.GoldCoins;
            _gameTraveler.IsLucky = traveler.IsLucky;
            _gameTraveler.IsQuick = traveler.IsQuick;
            _gameTraveler.IsOnNewWorld = false;

        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            //Variable Declarations.
            World currentWorld = new World();
            string planetDesignation = "";
            TravelerAction travelerActionChoice = TravelerAction.None;
            
            //Display splash screen.
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //Player chooses to quit.
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //Display introductory message.
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            // initialize the mission traveler.
            InitializeMission();

            //Prepare game play screen.
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");

            //Game loop.
            while (_playingGame)
            {
                //Process all flags, events, and stats.
                UpdateTravelerStats();

                //Variable Declarations.
                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //Choose an action based on the user's menu choice.
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;

                    case TravelerAction.TravelerInfo:
                        //Display the traveler's information in the Message Box area of the screen.
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.TravelerEdit:
                        //Allow the player to edit some of the traveler information.
                        ReInitializeTraveler();
                        break;
                    case TravelerAction.LookAround:
                        //Display name and description of the current planet the player is on in the Message Box area of the screen.
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case TravelerAction.Travel:
                        //_gameConsoleView.GetWorldToTravelTo();
                        planetDesignation = _gameConsoleView.GetWorldToTravelTo();
                        if (_gameUniverse.IsValidPlanetDesignation(planetDesignation) == true)
                        {
                            //Valid, check planet accessibility.
                            if (_gameUniverse.IsAccessibleLocation(planetDesignation) == true)
                            {
                                //Accessible
                                _gameTraveler.CurrentPlanet = planetDesignation;
                                _gameConsoleView.DisplayLookAround();
                                currentWorld = _gameUniverse.GetWorldByID(planetDesignation);
                                //_gameTraveler.WorldsVisited.Add(planetDesignation, currentWorld.CommonName);
                                _gameTraveler.AddVisitedWorld(planetDesignation, currentWorld.CommonName);
                                _gameTraveler.IsOnNewWorld = true;
                            }
                            else
                            {
                                //Not Accessible
                                _gameConsoleView.DisplayInputErrorMessage("The planet you have choosen is restricted at this time.  Press any key to continue.");
                                Console.ReadKey();
                                _gameConsoleView.DisplayLookAround();
                            }
                        }
                        else
                        {
                            //Not Valid, display an error message.
                            _gameConsoleView.DisplayInputErrorMessage("The planet designation you have entered does not exist.  Press any key to continue.");
                            Console.ReadKey();
                            _gameConsoleView.DisplayLookAround();
                        }
                        break;
                    case TravelerAction.TravelerLocationsVisited:
                        //Display a list of worlds the traveler has visited.
                        _gameConsoleView.DisplayWorldsVisited();
                        break;
                    case TravelerAction.ListWorlds:
                        //Display a list of all the worlds in the universe.
                        _gameConsoleView.DislayListOfWorlds();
                        break;
                    case TravelerAction.Exit:
                        //Display the closing screen in the Message Box area of the screen and exit the game.
                        _playingGame = false;
                        _gameConsoleView.DisplayClosingScreen();
                        break;

                    default:
                        break;
                }
            }

            //Close the application.
            Environment.Exit(1);
        }

        /// <summary>
        /// Saves the edited information for the traveler that was entered by the player.
        /// </summary>
        private void ReInitializeTraveler()
        {
            //Variable Declarations.
            Traveler traveler = _gameConsoleView.EditTravelerInfo();

            //Set the traveler info. entered by the user to the appropriate property.
            _gameTraveler.FirstName = traveler.FirstName;
            _gameTraveler.LastName = traveler.LastName;
            _gameTraveler.Age = traveler.Age;
            _gameTraveler.Height = traveler.Height;
            _gameTraveler.Rank = traveler.Rank;
            //_gameTraveler.Health = traveler.Health;
            //_gameTraveler.GoldCoins = traveler.GoldCoins;
            //_gameTraveler.IsLucky = traveler.IsLucky;
            //_gameTraveler.IsQuick = traveler.IsQuick;

        }                

        /// <summary>
        /// Updates information about the player's character during the game.
        /// </summary>
        private void UpdateTravelerStats()
        {
            //Clear the traveler stats in the Status Box.
            _gameConsoleView.ClearStatusBox();

            //Check to see if the traveler has gone to a new world.
            if (_gameTraveler.IsOnNewWorld == true)
            {
                switch (_gameTraveler.CurrentPlanet)
                {
                    case "P4A-771":   //Jebanna (P4A-771)
                        _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.PartialHealing);
                        break;
                    case "P2Q-463":   //Vyus (P2Q-463)
                        _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.MinorInjury);
                        _gameTraveler.GoldCoins += 5;
                        break;
                    default:
                        break;
                }

                _gameTraveler.IsOnNewWorld = false;
            }

            //Refresh the traveler stats in the Status Box.
            _gameConsoleView.DisplayStatusBox();
        }

        #endregion
    }
}
