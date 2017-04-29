using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Traveler _gameTraveler;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES



        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Traveler gameTraveler, Universe gameUniverse)
        {
            _gameTraveler = gameTraveler;
            _gameUniverse = gameUniverse;

            InitializeDisplay();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// Clears the text from the Status Box area of the screen.
        /// </summary>
        public void ClearStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // clear the status box
                //
                Console.ForegroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameTraveler, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// Displays a closing message on the screen.
        /// </summary>
        public void DisplayClosingScreen()
        {
            //Display a closing message on the screen.
            _viewStatus = ViewStatus.TravelerInitialization;
            DisplayGamePlayScreen("Exit Game", Text.ClosingScreen(), ActionMenu.MissionIntro, "");
            GetContinueKey();
        }

        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// Displays the name and description of a specific object selected by the user.
        /// </summary>
        public void DisplayGameObjectInfo()
        {
            //Variable Declarations.
            int objectIDValue = 0;
            GameObject gameObjectToGet;
            List<GameObject> gameObjectList;
            TravelerObject objectToView;

            //Check the number of game objects on the current world.
            gameObjectList = _gameUniverse.GetGameObjectsByWorld(_gameTraveler.CurrentPlanet);
            if(gameObjectList.Count > 0)
            {
                //If there is one or more game object available on the current world for the traveler to pick up...

                //Display a list of game objects.
                DisplayGamePlayScreen("Game Object List", Text.GetWorldGameObjects(gameObjectList), ActionMenu.InventoryMenu, "");

                //Get the object's ID value from the user.
                GetInteger("Enter the Object ID: ", 0, 0, out objectIDValue);
                
                //Check to see if the game object id entered is a valid object on the current world.
                if(_gameUniverse.IsValidGameOBjectByWorldID(objectIDValue, _gameTraveler.CurrentPlanet))
                {
                    //If the game object is available on the current world...

                    //Get the information about the object with the ID value entered by the user.
                    gameObjectToGet = _gameUniverse.GetGameObjectByID(objectIDValue);
                    objectToView = gameObjectToGet as TravelerObject;

                    //Display the object's informaton to the Message Box area of the screen.
                    //DisplayGamePlayScreen("Object Information", Text.GetGameObjectDetail(objectToView), ActionMenu.MainMenu, "");
                    DisplayGamePlayScreen("Object Information", Text.GetGameObjectDetail(objectToView), ActionMenu.InventoryMenu, "");
                }
                else
                {
                    //The object is not on the world...

                    //Display an error message in the Input Box area of the screen.
                    DisplayInputErrorMessage("The object entered is not available on this world.  Press any key to continue.");
                    Console.ReadKey();
                    DisplayGamePlayScreen("Inventory Menu", "Select an operation from the menu.", ActionMenu.InventoryMenu, "");
                }
            }
            else
            {
                //If there are no game objects available on the current world...

                //Display a list of game objects.
                DisplayGamePlayScreen("Game Object List", Text.GetWorldGameObjects(gameObjectList), ActionMenu.InventoryMenu, "");
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Displays a list of all game objects on the screen.
        /// </summary>
        public void DisplayListOfGameObjects()
        {
            //Display a list of all the game objects in the Message Box area of the screen.          
            DisplayGamePlayScreen("List of Game Objects", Text.GetAllGameObjects(_gameUniverse.GameObjects), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// Displays a list of all npc objects on the screen.
        /// </summary>
        public void DisplayListOfNpcObjects()
        {
            //Display a list of all the game objects in the Message Box area of the screen.           
            DisplayGamePlayScreen("List of Non-playable Characters", Text.GetAllNpcObjects(_gameUniverse.Npc), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// Displays a list of all worlds in the Message Box are of the screen.
        /// </summary>
        public void DislayListOfWorlds()
        {
            DisplayGamePlayScreen("List of Worlds", Text.DisplayWorlds(_gameUniverse, _gameTraveler, true), ActionMenu.AdminMenu, "");
        }
        
        /// <summary>
        /// Displays a description of the player's current location on the screen.
        /// </summary>
        public void DisplayLookAround()
        {
            //Variable Declarations.
            string messageText = "";

            //Get the description of the player's current location.
            messageText = Text.LookAround(_gameUniverse.GetWorldByID(_gameTraveler.CurrentPlanet));

            //Get a list of game objects that are in the player's current location.
            messageText += Text.GetWorldGameObjects(_gameUniverse.GetGameObjectsByWorld(_gameTraveler.CurrentPlanet));

            //Get a list of npc objects that are in the player's current location.
            messageText += " \n";
            messageText += Text.GetWorldNpcObjects(_gameUniverse.GetNpcsByWorld(_gameTraveler.CurrentPlanet));

            //Display the description of the player's current location in the Message Box area of the screen.
            DisplayGamePlayScreen("Current Location", messageText, ActionMenu.TravelMenu, "");
        }
        
        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, TravelerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != TravelerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// Displays the NPC information in the Message Box area of the screen.
        /// </summary>
        public void DisplayNpcInformation()
        {
            //Variable Declarations.
            int npcID = 0;
            Npc npcToDisplay;

            //Get the NPC information.
            npcID = GetNpcID();

            //Check to see if the NPC ID value entered by the player is valid.
            if (_gameUniverse.IsValidNpcByWorldID(npcID, _gameTraveler.CurrentPlanet) == true)
            {
                //NPC is valid for the current world...

                //Get the NPC information.
                npcToDisplay = _gameUniverse.GetNpcObjectByID(npcID);

                //Display the NPC information in the Message Box area of the screen.
                DisplayGamePlayScreen("NPC Information", Text.DisplayNpcInformation(npcToDisplay), ActionMenu.NpcMenu, "");
            }
            else
            {
                //NPC is not valid for the current world...

                DisplayInputErrorMessage("The NPC ID value you have entered does not exist.  Press any key to continue.");
                Console.ReadKey();
                DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
            }
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"  _________ __                             __              __      __            .__       .___     ");
            Console.WriteLine(tabSpace + @" /   _____//  |______ _______  _________ _/  |_  ____     /  \    /  \___________|  |    __| _/______");
            Console.WriteLine(tabSpace + @" \_____  \\   __\__  \\_  __ \/ ___\__  \\   __\/ __ \    \   \/\/   /  _ \_  __ \  |   / __ |/  ___/");
            Console.WriteLine(tabSpace + @" /        \|  |  / __ \|  | \/ /_/  > __ \|  | \  ___/     \        (  <_> )  | \/  |__/ /_/ |\___ \ ");
            Console.WriteLine(tabSpace + @"/_______  /|__| (____  /__|  \___  (____  /__|  \___  >     \__/\  / \____/|__|  |____/\____ /____  >");
            Console.WriteLine(tabSpace + @"        \/           \/     /_____/     \/          \/           \/                         \/    \/ ");
            Console.WriteLine(tabSpace + @"");
            Console.WriteLine(tabSpace + @"");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameTraveler, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// Displays the traveler's current inventory in the Message Box area of the screen.
        /// </summary>
        public void DisplayTravelerInventory()
        {
            //Variable Declarations.
            List<TravelerObject> travelerInventory = new List<TravelerObject>();
            
            //Look through the game objects and add any with a zero(0) planet designation to the traveler's inventory list.
            foreach (GameObject gameObject in _gameUniverse.GameObjects)
            {
                if (gameObject.PlanetDesignation == "0")
                {
                    travelerInventory.Add((TravelerObject)gameObject);
                }
            }

            //Display the object's informaton to the Message Box area of the screen.
            DisplayGamePlayScreen("Traveler Inventory", Text.GetCurrentInventory(travelerInventory), ActionMenu.InventoryMenu, ""); 
        }

        /// <summary>
        /// Displays a list of worlds that the traveler has visited in the Message Box area of the screen.
        /// </summary>
        /// <returns></returns>
        public void DisplayWorldsVisited()
        {
            //Display the list of worlds that the player has visited.
            DisplayGamePlayScreen("Worlds Visited", Text.WorldsVisited(_gameUniverse, _gameTraveler), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public TravelerAction GetActionMenuChoice(Menu menu)
        {
            //Variable Declarations.
            TravelerAction choosenAction = TravelerAction.None;
            Console.CursorVisible = false;

            //Create an array of valid keys from the menu dictionary.
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //Validate key pressed as in MenuChoices dictionary.
            char keyPressed;
            do
            {
                ConsoleKeyInfo KeyPressedInfo = Console.ReadKey(true);
                keyPressed = KeyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            //Get the menu choice based on the valid option entered by the player.
            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            //Return the menu choice.
            return choosenAction;
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the player to enter their height (based on list generated from an enum).
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public Character.HeightLevel GetHeight(string prompt)
        {
            //Variable Declarations.
            Character.HeightLevel height;

            //Validate the height of the traveler entered by the user.
            while (!Enum.TryParse<Character.HeightLevel>(Console.ReadLine(), out height))
            {
                ClearInputBox();
                DisplayInputErrorMessage($"You must enter a value from the list above.  Please try again.");
                DisplayInputBoxPrompt(prompt);
            }

            //Return the height value.
            return height;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Traveler GetInitialTravelerInfo()
        {
            //Variable Declarations.
            Traveler traveler = new Traveler();
            Random rnd = new Random();
            int lucky = rnd.Next(1, 11);
            int quick = rnd.Next(1, 11);

            //
            // intro
            //
            DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get traveler's first name
            //
            DisplayGamePlayScreen("Mission Initialization - First Name", Text.InitializeMissionGetTravelerFirstName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your first name: ");
            traveler.FirstName = GetString();

            //
            // get traveler's last name
            //
            DisplayGamePlayScreen("Mission Initialization - Last Name", Text.InitializeMissionGetTravelerLastName(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your last name: ");
            traveler.LastName = GetString();

            //
            // get traveler's age
            //
            DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetTravelerAge(traveler), ActionMenu.MissionIntro, "");
            int gameTravelerAge;

            GetInteger($"Enter your age {traveler.FirstName}: ", 0, 100, out gameTravelerAge);
            traveler.Age = gameTravelerAge;

            //
            // get traveler's height level
            //
            DisplayGamePlayScreen("Mission Initialization - Height", Text.InitializeMissionGetTravelerHeight(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your height {traveler.FirstName}: ");
            traveler.Height = GetHeight($"Enter your height {traveler.FirstName}: ");

            //
            // get traveler's rank.
            //
            DisplayGamePlayScreen("Mission Initialization - Rank", Text.InitializeMissionGetTravelerRank(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your rank: ");
            traveler.Rank = GetString();

            //Set traveler's health and currency amount.
            traveler.Health = Traveler.TravelerHealth.VeryGood;
            traveler.GoldCoins = 10;

            //Set the traveler's luck and quick properties.
            if (lucky % 2 == 0)
                traveler.IsLucky = true;
            else
                traveler.IsLucky = false;

            if (quick % 2 == 0)
                traveler.IsQuick = true;
            else
                traveler.IsQuick = false;

            //Set the traveler's current planet (Earth).
            traveler.CurrentPlanet = "P2X-3YZ";

            //
            // echo the traveler's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTravelerInfo(traveler), ActionMenu.MissionIntro, "");
            GetContinueKey();

            _viewStatus = ViewStatus.PlayingGame;

            //Return the traveler's information.
            return traveler;
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            //Variable Declarations.
            integerChoice = 0;
            bool validateRange = false;
            bool validResponse = false;

            //If the min and max values are not zero, validate the range.
            //validateRange = (minimumValue != 0 && maximumValue != 0);
            if (minimumValue == 0 && maximumValue == 0)
            {
                //Validate Range...
                validateRange = false;
            }
            else
            {
                validateRange = true;
            }

            //Prompt the user to enter an integer value.
            DisplayInputBoxPrompt(prompt);

            //Validate the user's response.
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    //The value entered is a valid integer...

                    if (validateRange == true)
                    {
                        //Check to make sure the integer entered is within the specified range...

                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            //The integer entered is within the specified range...

                            validResponse = true;
                        }
                        else
                        {
                            //The integer entered is not within the specified range...

                            //Display an error message in the Input Box area of the screen.
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        //Do not check to make sure the integer entered is within the specified range...

                        validResponse = true;
                    }
                }
                else
                {
                    //Not a valid integer...

                    //Display an error message in the Input Box area of the screen.
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter a valid integer. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// Prompt the player for the id value of the npc they want to get informatio about.
        /// </summary>
        /// <returns></returns>
        public int GetNpcID()
        {
            //Varaible Declarations.
            int npcID = 0;

            //Display the list of all NPC's on the current world.
            DisplayGamePlayScreen("Travel to World", Text.GetNpcInformation(_gameTraveler.CurrentPlanet, _gameUniverse), ActionMenu.NpcMenu, "");
            DisplayInputBoxPrompt("Enter NPC ID: ");

            //Get the ID value for the NPC the player wants to get more information about.
            DisplayInputBoxPrompt("Enter NPC ID: ");

            //Return the planet designation of the world choosen by the user.
            GetInteger("Enter NPC ID: ", 0, 0, out npcID);
            return npcID;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets the world the player would like to go to next.
        /// </summary>
        public string GetWorldToTravelTo()
        {
            //Display the list of worlds.
            DisplayGamePlayScreen("Travel to World", Text.TravelToWorld(_gameUniverse, _gameTraveler), ActionMenu.TravelMenu, "");
            DisplayInputBoxPrompt($"Enter Number for World: ");

            //Get the planet designation of the world the player wants to travel to.
            //GetInteger("Enter Number of World: ", 1, _gameUniverse.Worlds.Count, out worldChoice);
            DisplayInputBoxPrompt("Enter the Designation: ");
            
            //Return the planet designation of the world choosen by the user.
            return GetString();
        }
        
        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Stargate Worlds";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        

        

        

        

        

        

        

        

        

        

        #region ----- display responses to menu action choices -----

        /// <summary>
        /// Displays the traveler's information in the Message Box area of the screen.
        /// </summary>
        public void DisplayTravelerInfo()
        {
            DisplayGamePlayScreen("Traveler Information", Text.TravelerInfo(_gameTraveler), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// Prompts the player to enter new values for the traveler's information.
        /// </summary>
        /// <returns></returns>
        public Traveler EditTravelerInfo()
        {
            //Variable Declarations.
            Traveler traveler = new Traveler();

            //
            // get traveler's first name
            //
            DisplayGamePlayScreen("Edit Traveler Information - First Name", Text.InitializeMissionGetTravelerFirstName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your first name: ");
            traveler.FirstName = GetString();

            //
            // get traveler's last name
            //
            DisplayGamePlayScreen("Edit Traveler Information - Last Name", Text.InitializeMissionGetTravelerLastName(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your last name: ");
            traveler.LastName = GetString();

            //
            // get traveler's age
            //
            DisplayGamePlayScreen("Edit Traveler Information - Age", Text.InitializeMissionGetTravelerAge(traveler), ActionMenu.MissionIntro, "");
            int gameTravelerAge;

            GetInteger($"Enter your age {traveler.FirstName}: ", 0, 100, out gameTravelerAge);
            traveler.Age = gameTravelerAge;

            //
            // get traveler's height level
            //
            DisplayGamePlayScreen("Edit Traveler Information - Height", Text.InitializeMissionGetTravelerHeight(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your height {traveler.FirstName}: ");
            traveler.Height = GetHeight($"Enter your height {traveler.FirstName}: ");

            //
            // get traveler's rank.
            //
            DisplayGamePlayScreen("Edit Traveler Information - Rank", Text.InitializeMissionGetTravelerRank(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your rank: ");
            traveler.Rank = GetString();

            //
            // echo the traveler's info
            //
            //DisplayGamePlayScreen("Edit Traveler Information - Complete", Text.ReinitializeTravelerEchoTravelerInfo(traveler), ActionMenu.MainMenu, "");
            DisplayGamePlayScreen("Edit Traveler Information - Complete", Text.ReinitializeTravelerEchoTravelerInfo(traveler), ActionMenu.AdminMenu, "");
            GetContinueKey();

            return traveler;
        }

        #endregion

        #endregion
    }
}
