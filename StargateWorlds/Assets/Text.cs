using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Stargate Worlds" };
        public static List<string> FooterText = new List<string>() { "Bird Brain Inernational 2017" };

        #region INTITIAL GAME SETUP         

        /// <summary>
        /// Displays information about the initial location the traveler begins the game from.
        /// </summary>
        /// <returns></returns>
        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            //"You are now in the Norlon Corporation research facility located in " +
            //"the city of Heraklion on the north coast of Crete. You have passed through " +
            //"heavy security and descended an unknown number of levels to the top secret " +
            //"research lab for the Aion Project.\n" +
            //" \n" +
            //"\tChoose from the menu options to proceed.\n";

            "You have just entered the Gate Room where Earth's Stargate is located in a top\n" +
            "secret U.S. Airforce installation under Cheyenne Mountain in Colorado.  You just returned\n" +
            "from your scouting mission and have brief your commanding officer, Gen. George Hammond, on\n" +
            "what you have found.  Gen. Hammond orders you to the planet of Abydos to speak wih the\n" +
            "leaders of that planet to acquire the Trinium necessary for Earth's defense.\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        /// <summary>
        /// Displays the initial description of the mission.
        /// </summary>
        /// <returns></returns>
        public static string MissionIntro()
        {
            string messageBoxText =
            "You are a member of SG-1, a team of AirForce officers who travel to other worlds through a\n" +
            "device called a Stargate.  While scouting a location for a new off-world base on a newly\n" +
            "visited world you uncover evidence that a System Lord named Ra is planning on sending an\n" +
            "advanced bomb to Earth through the Stargate.  Your mission, acquire enough of a metal\n" +
            "called Trinium to construct a barrier for the Stargate to stop the bomb from reaching \n" +
            "Earth.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your mission begins now.\n" +
            " \n" +
            "\tYour first task will be to set up the initial parameters of your mission.\n" +
            " \n" +
            "\tPress any key to begin the Mission Initialization Process.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin your mission we much gather your base data.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerFirstName()
        {
            string messageBoxText =
                "Enter your first name traveler.\n" +
                " \n";// +
                //"Please use the name you wish to be referred during your mission.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerLastName(Traveler gameTraveler)
        {
            string messageBoxText =
                $"Enter your last name {gameTraveler.FirstName}.\n" +
                " \n"; // +
                //"Please use the name you wish to be referred during your mission.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerRank(Traveler gameTraveler)
        {
            string messageBoxText =
                $"Now, {gameTraveler.FirstName}, what is your rank\n" +
                " \n"; // +
                       //"Please use the name you wish to be referred during your mission.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerAge(Traveler gameTraveler)
        {
            string messageBoxText =
                $"Very good then, we will call you {gameTraveler.FirstName} on this mission.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerHeight(Traveler gameTraveler)
        {
            string messageBoxText =
                $"Enter your height below.\n" +
                " \n" +
                "Please use the height classifications below." +
                " \n";

            string heightList = null;

            foreach (Character.HeightLevel race in Enum.GetValues(typeof(Character.HeightLevel)))
            {
                if (race != Character.HeightLevel.None)
                {
                    heightList += $"\t{race}\n";
                }
            }

            messageBoxText += heightList;

            return messageBoxText;
        }

       

        //public static string InitializeMissionGetTravelerRace(Traveler gameTraveler)
        //{
        //    string messageBoxText =
        //        $"{gameTraveler.FirstName}, it will be important for us to know your race on this mission.\n" +
        //        " \n" +
        //        "Enter your race below.\n" +
        //        " \n" +
        //        "Please use the universal race classifications below." +
        //        " \n";

        //    string raceList = null;

        //    foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
        //    {
        //        if (race != Character.RaceType.None)
        //        {
        //            raceList += $"\t{race}\n";
        //        }
        //    }

        //    messageBoxText += raceList;

        //    return messageBoxText;
        //}

        public static string InitializeMissionEchoTravelerInfo(Traveler gameTraveler)
        {
            string messageBoxText =
                $"Very good then {gameTraveler.FirstName}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your mission. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tTraveler Rank: {gameTraveler.Rank}\n" +
                $"\tTraveler First Name: {gameTraveler.FirstName}\n" +
                $"\tTraveler Last Name: {gameTraveler.LastName}\n" +
                $"\tTraveler Age: {gameTraveler.Age}\n" +
                $"\tTraveler Height: {gameTraveler.Height}\n" +
                //$"\tTraveler Health: {gameTraveler.Health}\n" +
                $"\tTraveler Health: {ConsoleWindowHelper.ToLabelFormat(gameTraveler.Health.ToString())}\n" +
                $"\tTraveler Gold Coins: {gameTraveler.GoldCoins}\n" +
                $"\tTraveler Lucky: {gameTraveler.IsLucky}\n" +
                $"\tTraveler Quick: {gameTraveler.IsQuick}\n" +

                " \n" +
                "Press any key to begin your mission.";

            return messageBoxText;
        }

        public static string ReinitializeTravelerEchoTravelerInfo(Traveler gameTraveler)
        {
            string messageBoxText =
                $"Your information has been successfully updated {gameTraveler.FirstName}. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tTraveler Rank: {gameTraveler.Rank}\n" +
                $"\tTraveler First Name: {gameTraveler.FirstName}\n" +
                $"\tTraveler Last Name: {gameTraveler.LastName}\n" +
                $"\tTraveler Age: {gameTraveler.Age}\n" +
                $"\tTraveler Height: {gameTraveler.Height}\n" +
                //$"\tTraveler Health: {ConsoleWindowHelper.ToLabelFormat(gameTraveler.Health.ToString())}\n" +
                //$"\tTraveler Gold Coins: {gameTraveler.GoldCoins}\n" +
                //$"\tTraveler Lucky: {gameTraveler.IsLucky}\n" +
                //$"\tTraveler Quick: {gameTraveler.IsQuick}\n" +

                " \n" +
                "Choose a menu option to continue your mission.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        /// <summary>
        /// Displays the closing message in the Message Box area of the screen.
        /// </summary>
        /// <returns></returns>
        public static string ClosingScreen()
        {
            string messageBoxText =
            "Thank you for playing Stargate Worlds by Bird Brain International.\n" +
            "Visit www.birdbrain.com for upcoming games\n" +
            " \n" +
            "Press any key to exit\n";

            return messageBoxText;
        }

        /// <summary>
        /// Returns a list of all worlds that are in stargate network.
        /// </summary>
        /// <param name="gameUniverse"></param>
        /// <param name="gameTraveler"></param>
        /// <returns></returns>
        public static string DisplayWorlds(Universe gameUniverse, Traveler gameTraveler, bool displayCurrenLocation)
        {
            //Variable Declarations.
            string heightList = null;
            string messageBoxText = "";

            //Add the headings to the message text.
            messageBoxText += "Planet Designation \t\t Planet \n " +
                " \n";

            //Add the worlds to the message text.
            foreach (World location in gameUniverse.Worlds)
            {
                if (displayCurrenLocation == true)
                {
                    //Display the traveler's current world as part of the list.
                    heightList += $"{location.PlanetDesignation} \t\t\t {location.CommonName} \n";
                }
                else
                {
                    //Do not display the traveler's current world as part of the list.
                    if (gameTraveler.CurrentPlanet != location.PlanetDesignation)
                    {
                        heightList += $"{location.PlanetDesignation} \t\t\t {location.CommonName} \n";
                    }
                }
            }

            messageBoxText += heightList;

            //Return the list of worlds.
            return messageBoxText;
        }

        /// <summary>
        /// Returns a list of all worlds that the traveler has visited during the game.
        /// </summary>
        /// <param name="gameUniverse"></param>
        /// <param name="gameTraveler"></param>
        /// <returns></returns>
        public static string DisplayWorldsTraveled(Universe gameUniverse, Traveler gameTraveler)
        {
            //Variable Declarations.
            string worldList = null;
            string messageBoxText = "";

            //Add the headings to the message text.
            messageBoxText += "Planet Designation \t\t Planet \n " +
                " \n";

            //if(gameTraveler.WorldsVisited != null)
            if (gameTraveler.WorldsVisited.Count > 0)
            {
                //Build the list of worlds visited.
                foreach (KeyValuePair<string, string> location in gameTraveler.WorldsVisited)
                {
                    worldList += $"{location.Key.ToString()} \t\t\t {location.Value.ToString()} \n";
                }
            }
            else
            {
                //Add a message that no worlds have been visited.
                worldList += $"No Worlds Visited";
            }

            //Add the list of worlds to the message text.
            messageBoxText += worldList;

            //Return the list of worlds.
            return messageBoxText;
        }

        /// <summary>
        /// Returns the name and description of the current world the player is on.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public static string LookAround(World world)
        {
            string messageBoxText =
                $"Current Location: {world.CommonName}\n" +
                " \n" +
                world.Description  +
                " \n" +
                world.GeneralContents;

            return messageBoxText;
        }
        
        /// <summary>
        /// Displays the stats of the traveler in the Status Box area of the screen.
        /// </summary>
        /// <param name="traveler"></param>
        /// <param name="universe"></param>
        /// <returns></returns>
        public static List<string> StatusBox(Traveler traveler, Universe universe)
        {
            List<string> statusBoxText = new List<string>();

            //statusBoxText.Add($"Experience Points: {traveler.ExperiencePoints}\n");
            //statusBoxText.Add($"Health: {traveler.Health}\n");

            statusBoxText.Add($"Health: {ConsoleWindowHelper.ToLabelFormat(traveler.Health.ToString())}\n");
            statusBoxText.Add($"Gold Coins: {traveler.GoldCoins}\n");

            //statusBoxText.Add($"Lives: {traveler.Lives}\n");



            return statusBoxText;
        }

        /// <summary>
        /// Displays the Traveler's information.
        /// </summary>
        /// <param name="gameTraveler"></param>
        /// <returns></returns>
        public static string TravelerInfo(Traveler gameTraveler)
        {
            string messageBoxText =
                $"\tTraveler Rank: {gameTraveler.Rank}\n" +
                $"\tTraveler First Name: {gameTraveler.FirstName}\n" +
                $"\tTraveler Last Name: {gameTraveler.LastName}\n" +
                $"\tTraveler Age: {gameTraveler.Age}\n" +
                $"\tTraveler Height: {gameTraveler.Height}\n" +
                //$"\tTraveler Health: {gameTraveler.Health}\n" +
                $"\tTraveler Health: {ConsoleWindowHelper.ToLabelFormat(gameTraveler.Health.ToString())}\n" +
                $"\tTraveler Gold Coins: {gameTraveler.GoldCoins}\n" +
                $"\tTraveler Lucky: {gameTraveler.IsLucky}\n" +
                $"\tTraveler Quick: {gameTraveler.IsQuick}\n" +
                " \n";

            return messageBoxText;
        }

        /// <summary>
        /// Displays text in the Message Box area of the screen prompting the player to enter the world
        /// they want to travel to and displays a list of all worlds in the universe.
        /// </summary>
        /// <param name="gameUniverse"></param>
        /// <returns></returns>
        public static string TravelToWorld(Universe gameUniverse, Traveler gameTraveler)
        {
            string messageBoxText =
                $"What world would you like to travel to? \n" +
                " \n" +
                "Please enter the number of one of the worlds below: \n" +
                " \n";

            //Add the list of worlds to the message box text.
            messageBoxText += DisplayWorlds(gameUniverse, gameTraveler, false);

            //Return the text to display in the Message area of the screen.
            return messageBoxText;
        }

        /// <summary>
        /// Displays a list of the worlds the traveler has visited during the game in the Message Box area of the screen.
        /// </summary>
        /// <param name="gameUniverse"></param>
        /// <param name="gameTraveler"></param>
        /// <returns></returns>
        public static string WorldsVisited(Universe gameUniverse, Traveler gameTraveler)
        {
            string messageBoxText =
                $"Belowe is a list of the worlds you have visited: \n" +
                " \n";

            //Add the list of worlds to the message box text.
            messageBoxText += DisplayWorldsTraveled(gameUniverse, gameTraveler);

            //Return the text to display in the Message area of the screen.
            return messageBoxText;
        }        

        #endregion
    }
}
