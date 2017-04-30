using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
                switch (ActionMenu.currentMenu)
                {
                    case ActionMenu.CurrentMenu.AdminMenu:
                        if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                        }
                        else
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                        }
                        break;
                    case ActionMenu.CurrentMenu.InventoryMenu:
                        if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                        }
                        else
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InventoryMenu);
                        }
                        break;
                    case ActionMenu.CurrentMenu.MainMenu:
                        if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                        }
                        else
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                        }
                        break;
                    case ActionMenu.CurrentMenu.NpcMenu:
                        if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                        }
                        else
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                        }
                        break;
                    case ActionMenu.CurrentMenu.TravelMenu:
                        if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InitializeMission);
                        }
                        else
                        {
                            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TravelMenu);
                        }
                        break;
                    default:
                        break;
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
                    case TravelerAction.ListNonplayerCharacters:
                        //Display a list of all npc objects in the Message Box area of the screen.
                        _gameConsoleView.DisplayListOfNpcObjects();
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
                    case TravelerAction.NpcInformation:
                        //Display an npc's information in the Message Box area of the screen.
                        _gameConsoleView.DisplayNpcInformation();
                        break;
                    case TravelerAction.PutDownObject:
                        //Pick up a game object and put it into inventory.
                        _gameUniverse.PutDownItem(_gameUniverse, _gameTraveler, _gameConsoleView);
                        break;
                    case TravelerAction.PickUpObject:
                        //Take a game object out of inventory and leave it on the current world.
                        _gameUniverse.PickupItem(_gameUniverse, _gameTraveler, _gameConsoleView);
                        break;
                    case TravelerAction.TalkToNpc:
                        //Talk to a npc on the current world.
                        _gameUniverse.TalkToNpc(_gameTraveler, _gameConsoleView);
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
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_gameUniverse.GetWorldByID(_gameTraveler.CurrentPlanet)) + " " + Text.GetWorldGameObjects(_gameUniverse.GetGameObjectsByWorld(_gameTraveler.CurrentPlanet)) + " \n" + Text.GetWorldNpcObjects(_gameUniverse.GetNpcsByWorld(_gameTraveler.CurrentPlanet)), ActionMenu.MainMenu, "");
                        break;
                    case TravelerAction.TravelMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.TravelMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Travel Menu", "Select an operation from the menu.", ActionMenu.TravelMenu, "");
                        break;
                    case TravelerAction.NpcMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
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
        }                

        /// <summary>
        /// Updates information about the player's character during the game.
        /// </summary>
        private void UpdateTravelerStats()
        {
            //Variable Declarations.
            GameObject trinium;
            GameObject bombSpecs;
            List<GameObject> gameObjects;
            Random rnd = new Random();
            string rndPlanetDesignation = "";
            int rndworldNbr = UtilityLibrary.Misc.GetRandomInt(1, _gameUniverse.Worlds.Count);
            Warrior jaffaNpc = new Warrior();

            //Clear the traveler stats in the Status Box.
            _gameConsoleView.ClearStatusBox();

            //Check to see if the traveler has gone to a new world.
            if (_gameTraveler.IsOnNewWorld == true)
            {
                switch (_gameTraveler.CurrentPlanet)
                {
                    case "P8X-362":   //Chulak (P8X-362)
                        _gameConsoleView.DisplayGamePlayScreen("Ambush", "You have been ambushed by a small group of Jaffa soldiers not mentioned in the Tok'ra intelligence.  You manage to subdue the soldiers and continue into the installation.", ActionMenu.TravelMenu, "");

                        //Loop through the list of npc's to find the jaffa soldiers npc.
                        foreach (Npc gameNpc in _gameUniverse.Npc)
                        {
                            if (gameNpc is Warrior)
                            {
                                jaffaNpc = gameNpc as Warrior;
                            }
                        }

                        //Clear the traveler stats in the Status Box.
                        _gameConsoleView.ClearStatusBox();

                        //Battle the traveler.
                        _gameTraveler.UpdateTravelerHealth(jaffaNpc.Battle(_gameTraveler));
                        break;
                    case "P3X-974":   //Cimmeria (P3X-974)
                        //Take the traveler to a random world.
                        rndPlanetDesignation = _gameUniverse.Worlds[rndworldNbr].PlanetDesignation;
                        _gameTraveler.CurrentPlanet = rndPlanetDesignation;
                        _gameConsoleView.DisplayLookAround();
                        _gameTraveler.AddVisitedWorld(rndPlanetDesignation, _gameUniverse.Worlds[rndworldNbr].CommonName);
                        _gameTraveler.IsOnNewWorld = true;

                        //Clear the traveler stats in the Status Box.
                        _gameConsoleView.ClearStatusBox();

                        //Add 15 gold coins.
                        _gameTraveler.GoldCoins += 15;

                        //Update the traveler's health.
                        _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.MinorInjury);
                        break;
                    case "P2X-3YZ":   //Earth (P2X-3YZ)

                        //Update the traveler's health.
                        _gameTraveler.UpdateTravelerHealth(Traveler.HealthChange.FullHealing);
                        break;
                    case "P5C-768":   //Edora (P5C-768)
                        //Setup a timer for the player's cloaking device failing.
                        Timer cloakFailTmr = new Timer();
                        cloakFailTmr.Interval = 1500;   //1.5 seconds
                        cloakFailTmr.AutoReset = false;
                        cloakFailTmr.Elapsed += OnTimedEventCloak;
                        cloakFailTmr.Start();

                        //Setup a timer for the player being attacked.
                        Timer attackTmr = new Timer();
                        attackTmr.Interval = 10000;   //10 seconds
                        attackTmr.AutoReset = false;
                        attackTmr.Elapsed += OnTimedEventAttack;
                        attackTmr.Start();

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

            //Check for game objects that allow the player to win the game...
            //Get a list of game objects for Earth.
            gameObjects = _gameUniverse.GetGameObjectsByWorld("P2X-3YZ");

            //Get the object information for Trinium and the Bomb Specs.
            trinium = _gameUniverse.GetGameObjectByID(8);
            bombSpecs = _gameUniverse.GetGameObjectByID(9);

            //Check the game objects for Earth to see if the player has acquired the trinium and bomb specs.
            if (gameObjects.Contains(trinium) && gameObjects.Contains(bombSpecs))
            {
                _gameConsoleView.DisplayGamePlayScreen("Game Over", "You Win!!  You have successfully retrieved the information and materials neccessary to save Earth!", ActionMenu.InitializeMission, "");
                _playingGame = false;
            }

            //Check to see if the player is dead...
            //If the player is dead end the game.
            if (_gameTraveler.Health == Traveler.TravelerHealth.Dead)
            {
                _gameConsoleView.DisplayGamePlayScreen("Game Over", "You have died (a.k.a. Game Over).  Thank you for playing.", ActionMenu.InitializeMission, "");
                _playingGame = false;
            }
        }

        #endregion

        #region EVENTS

        private void OnTimedEventCloak(Object source, System.Timers.ElapsedEventArgs e)
        {
            _gameConsoleView.DisplayGamePlayScreen("Equipment Failure", "Your cloaking device has failed (one of the hazards of buying second hand equipment).  You are now visible to all in the power station.", ActionMenu.TravelMenu, "");

        }

        private void OnTimedEventAttack(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Variable Declarations.
            Warrior jaffaNpc = new Warrior();

            //Display a message in the Message Box area of the screen telling the player they have been attacked.
            _gameConsoleView.DisplayGamePlayScreen("Ambush", "You have been ambushed by a small group of Jaffa soldiers that help guard the power station.  You manage to subdue the soldiers and continue to where the Naquadria is stored.", ActionMenu.TravelMenu, "");

            //Clear the traveler stats in the Status Box.
            _gameConsoleView.ClearStatusBox();

            //Loop through the list of npc's to find the jaffa soldiers npc.
            foreach (Npc gameNpc in _gameUniverse.Npc)
            {
                if (gameNpc is Warrior)
                {
                    jaffaNpc = gameNpc as Warrior;
                }
            }

            //Battle the traveler.
            _gameTraveler.UpdateTravelerHealth(jaffaNpc.Battle(_gameTraveler));
            _gameConsoleView.DisplayStatusBox();
        }

        #endregion
    }
}
