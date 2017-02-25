﻿using System;
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
        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Traveler _gameTraveler;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Traveler gameTraveler)
        {
            _gameTraveler = gameTraveler;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
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
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public TravelerAction GetActionMenuChoice(Menu menu)
        {
            TravelerAction choosenAction = TravelerAction.None;

            ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
            char keyPressed = keyPressedInfo.KeyChar;
            //choosenAction = menu.MenuChoices[keyPressed];

            switch (keyPressed)
            {
                case '1':
                case '2':
                case '3':
                    choosenAction = menu.MenuChoices[keyPressed];
                    break;
                default:
                    break;
            }
            
            return choosenAction;
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
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        //public Character.RaceType GetRace()
        //{
        //    Character.RaceType raceType;
        //    Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

        //    return raceType;
        //}

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
            //Console.WriteLine(tabSpace + @" _____ _              ___  _               ______          _           _   ");
            //Console.WriteLine(tabSpace + @"|_   _| |            / _ \(_)              | ___ \        (_)         | |  ");
            //Console.WriteLine(tabSpace + @"  | | | |__   ___   / /_\ \_  ___  _ __    | |_/ _ __ ___  _  ___  ___| |_ ");
            //Console.WriteLine(tabSpace + @"  | | | '_ \ / _ \  |  _  | |/ _ \| '_ \   |  __| '__/ _ \| |/ _ \/ __| __|");
            //Console.WriteLine(tabSpace + @"  | | | | | |  __/  | | | | | (_) | | | |  | |  | | | (_) | |  __| (__| |_ ");
            //Console.WriteLine(tabSpace + @"  \_/ |_| |_|\___|  \_| |_|_|\___/|_| |_|  \_|  |_|  \___/| |\___|\___|\__|");
            //Console.WriteLine(tabSpace + @"                                                         _/ |              ");
            //Console.WriteLine(tabSpace + @"                                                        |__/             ");



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
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Traveler GetInitialTravelerInfo()
        {
            //Variable Declarations.
            Traveler traveler = new Traveler();

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
            if (traveler.Age % 2 == 0)
                traveler.IsLucky = true;
            else
                traveler.IsLucky = false;

            if (traveler.Age % 2 == 0)
                traveler.IsQuick = true;
            else
                traveler.IsQuick = false;



            ////
            //// get traveler's race
            ////
            //DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetTravelerRace(traveler), ActionMenu.MissionIntro, "");
            //DisplayInputBoxPrompt($"Enter your race {traveler.Name}: ");
            //traveler.Race = GetRace();

            //
            // echo the traveler's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTravelerInfo(traveler), ActionMenu.MissionIntro, "");
            GetContinueKey();

            return traveler;
        }

        public void DisplayClosingScreen()
        {
            //Display a closing message on the screen.
            DisplayGamePlayScreen("Exit Game", Text.ClosingScreen(), ActionMenu.MissionIntro, "");
            GetContinueKey();
        }

        #region ----- display responses to menu action choices -----

        public void DisplayTravelerInfo()
        {
            DisplayGamePlayScreen("Traveler Information", Text.TravelerInfo(_gameTraveler), ActionMenu.MainMenu, "");
        }

        public Traveler EditTravelerInfo()
        {
            //Variable Declarations.
            Traveler traveler = new Traveler();

            //
            // intro
            //
            //DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            //GetContinueKey();

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
            DisplayGamePlayScreen("Edit Traveler Information - Complete", Text.ReinitializeTravelerEchoTravelerInfo(traveler), ActionMenu.MainMenu, "");
            GetContinueKey();

            return traveler;
        }

        #endregion

        #endregion
    }
}
