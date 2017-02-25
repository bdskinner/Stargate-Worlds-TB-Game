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

        public static string MissionIntro()
        {
            string messageBoxText =
            //"You have been hired by the Norlon Corporation to participate " +
            //"in its latest endeavor, the Aion Project. Your mission is to " +
            //"test the limits of the new Aion Engine and report back to " +
            //"the Norlon Corporation.\n" +
            //" \n" +
            //"Press the Esc key to exit the game at any point.\n" +
            //" \n" +
            //"Your mission begins now.\n" +
            //" \n" +
            //"\tYour first task will be to set up the initial parameters of your mission.\n" +
            //" \n" +
            //"\tPress any key to begin the Mission Initialization Process.\n";

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

        public static string ClosingScreen()
        {
            string messageBoxText =
            "Thank you for playing Stargate Worlds by Bird Brain International.\n" +
            "Visit www.birdbrain.com for upcoming games\n" +
            " \n" +
            "Press any key to exit\n";

            return messageBoxText;
        }

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

        //public static string Travel(int currentSpaceTimeLocationId, List<SpaceTimeLocation> spaceTimeLocations)
        //{
        //    string messageBoxText =
        //        $"{gameTraveler.Name}, Aion Base will need to know the name of the new location.\n" +
        //        " \n" +
        //        "Enter the ID number of your desired location from the table below.\n" +
        //        " \n";


        //    string spaceTimeLocationList = null;

        //    foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
        //    {
        //        if (race != Character.RaceType.None)
        //        {
        //            raceList += $"\t{race}\n";
        //        }
        //    }

        //    messageBoxText += raceList;

        //    return messageBoxText;
        //}

        #endregion
    }
}
