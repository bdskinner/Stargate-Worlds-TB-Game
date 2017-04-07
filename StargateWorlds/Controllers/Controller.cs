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

                //Get the player's menu choice.
                //travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                {
                    //travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                    else
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                }
                else if(ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                {
                    //travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                    else
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.TravelMenu)
                {
                    //travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TravelMenu);
                    if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                    else
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TravelMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.InventoryMenu)
                {
                    //travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InventoryMenu);
                    if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                    else
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InventoryMenu);
                }

                //Choose an action based on the user's menu choice.
                switch (travelerActionChoice)
                {
                    case TravelerAction.DisplayInventory:
                        //Displays the traveler's current inventory in the Message Box are of the screen.
                        _gameConsoleView.DisplayTravelerInventory();
                        break;
                    case TravelerAction.Exit:
                        //Display the closing screen in the Message Box area of the screen and exit the game.
                        _playingGame = false;
                        _gameConsoleView.DisplayClosingScreen();
                        break;
                    case TravelerAction.ListGameObjects:
                        //Display a list of all game objects in the Message Box area of the screen.
                        _gameConsoleView.DisplayListOfGameObjects();
                        break;
                    case TravelerAction.ListWorlds:
                        //Display a list of all the worlds in the universe in the Message Box area of the screen.
                        _gameConsoleView.DislayListOfWorlds();
                        break;
                    case TravelerAction.LookAround:
                        //Display name and description of the current planet the player is on in the Message Box area of the screen.
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case TravelerAction.LookAtObject:
                        //Display the information for a specific object in the player's current location.
                        _gameConsoleView.DisplayGameObjectInfo();
                        break;
                    case TravelerAction.PutDownObject:
                        //Pick up a game object and put it into inventory.
                        _gameUniverse.PutDownItem(_gameUniverse, _gameTraveler, _gameConsoleView);
                        break;
                    case TravelerAction.PickUpObject:
                        //Take a game object out of inventory and leave it on the current world.
                        _gameUniverse.PickupItem(_gameUniverse, _gameTraveler, _gameConsoleView);
                        break;
                    case TravelerAction.Travel:
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
                    case TravelerAction.TravelerEdit:
                        //Allow the player to edit some of the traveler information.
                        ReInitializeTraveler();
                        break;
                    case TravelerAction.TravelerInfo:
                        //Display the traveler's information in the Message Box area of the screen.
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.TravelerLocationsVisited:
                        //Display a list of worlds the traveler has visited in the Message Box area of the screen.
                        _gameConsoleView.DisplayWorldsVisited();
                        break;  
                    case TravelerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;
                    case TravelerAction.InventoryMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.InventoryMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Inventory Menu", "Select an operation from the menu.", ActionMenu.InventoryMenu, "");
                        break;
                    case TravelerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        //_gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_gameUniverse.GetWorldByID(_gameTraveler.CurrentPlanet)), ActionMenu.MainMenu, "");
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_gameUniverse.GetWorldByID(_gameTraveler.CurrentPlanet)) + " " + Text.GetWorldGameObjects(_gameUniverse.GetGameObjectsByWorld(_gameTraveler.CurrentPlanet)), ActionMenu.MainMenu, "");
                        break;
                    case TravelerAction.TravelMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.TravelMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Travel Menu", "Select an operation from the menu.", ActionMenu.TravelMenu, "");
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
                    case "P8X-362":   //Chulak (P8X-362)
                        if(_gameTraveler.IsQuick == true)
                        {
                            _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.MinorInjury);
                        }
                        else
                        {
                            _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.MajorInjury);
                        }
                        break;
                    case "P5C-768":   //Edora (P5C-768)
                        if (_gameTraveler.IsLucky == true)
                        {
                            _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.MinorInjury);
                        }
                        else
                        {
                            _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.MajorInjury);
                        }
                        break;
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

            //If the player is dead end the game.
            if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
            {
                _gameConsoleView.DisplayGamePlayScreen("Game Over", "Game Over.  Thank you for playing.", ActionMenu.InitializeMission, "");
                _playingGame = false;
            }
        }

        #endregion
    }
}
