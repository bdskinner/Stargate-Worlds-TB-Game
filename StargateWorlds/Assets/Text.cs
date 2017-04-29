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
        public static List<string> FooterText = new List<string>() { "Bird Brain International 2017" };

        #region INTITIAL GAME SETUP         

        /// <summary>
        /// Displays information about the initial location the traveler begins the game from.
        /// </summary>
        /// <returns></returns>
        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            "You have just entered the Gate Room where Earth's Stargate is located in a top\n" +
            "secret U.S. AirForce installation under Cheyenne Mountain in Colorado.  You just returned\n" +
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
        /// Displays the formatted information about a specific NPC.
        /// </summary>
        /// <param name="npcToDisplay"></param>
        /// <returns></returns>
        public static string DisplayNpcInformation(Npc npcToDisplay)
        {
            Civilian civilianToDisplay;
            string messageBoxText = "";
            Warrior warriorToDisply;

            if (npcToDisplay is Civilian)
            {
                civilianToDisplay = npcToDisplay as Civilian;
                messageBoxText =
                $"Name: {civilianToDisplay.FirstName} {civilianToDisplay.LastName} \n" +
                " \n" +
                $"Description: {civilianToDisplay.Description} \n" +
                " \n";
            }

            if (npcToDisplay is Warrior)
            {
                warriorToDisply = npcToDisplay as Warrior;
                messageBoxText =
                $"Name: {warriorToDisply.FirstName} {warriorToDisply.LastName} \n" +
                " \n" +
                $"Description: {warriorToDisply.Description} \n" +
                " \n";
            }



            //Return the text to display in the Message area of the screen.
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
                    //Display the traveler's current world as part of the list...

                    heightList += $"{location.PlanetDesignation} \t\t\t {location.CommonName} \n";
                }
                else
                {
                    //Do not display the traveler's current world as part of the list...
                    
                    if (gameTraveler.CurrentPlanet != location.PlanetDesignation)
                    {
                        if (location.Visible == true)
                        {
                            heightList += $"{location.PlanetDesignation} \t\t\t {location.CommonName} \n";
                        }
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
        /// Returns a list of all game objects.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string GetAllGameObjects(List<GameObject> gameObjects)
        {
            //Variable Declarations.
            string messageText = "";
            string gameObjectList = "";
            int ID_PAD = 5;
            int NAME_PAD = 50;
            int PLANET_PAD = 10;

            //Setup the table headers and column names.
            messageText =
                "Game Objects \n \n" +
                "ID".PadRight(ID_PAD) +
                "Name".PadRight(NAME_PAD) +
                "Plant Designation".PadRight(PLANET_PAD) + " \n" +
                "---".PadRight(ID_PAD) +
                "----------------------".PadRight(NAME_PAD) +
                "----------------------".PadRight(PLANET_PAD) + " \n";

            //Setup the list of game objects.
            gameObjectList = null;
            foreach (GameObject gameobject in gameObjects)
            {
                gameObjectList += $"{gameobject.ItemID}".PadRight(ID_PAD) +
                    $"{gameobject.ItemName}".PadRight(NAME_PAD) +
                    $"{gameobject.PlanetDesignation}".PadRight(PLANET_PAD) +
                    " \n";
            }

            messageText += gameObjectList;

            //Return a list of the game objects with their ID, Name, and Location.
            return messageText;
        }

        /// <summary>
        /// Returns a list of all npc objects.
        /// </summary>
        /// <param name="npcObjects"></param>
        /// <returns></returns>
        public static string GetAllNpcObjects(List<Npc> npcObjects)
        {
            //Variable Declarations.
            string messageText = "";
            string gameObjectList = "";
            int ID_PAD = 5;
            int NAME_PAD = 50;
            int PLANET_PAD = 10;

            //Setup the table headers and column names.
            messageText =
                "Non-playable Characters \n \n" +
                "ID".PadRight(ID_PAD) +
                "Name".PadRight(NAME_PAD) +
                "Plant Designation".PadRight(PLANET_PAD) + " \n" +
                "---".PadRight(ID_PAD) +
                "----------------------".PadRight(NAME_PAD) +
                "----------------------".PadRight(PLANET_PAD) + " \n";

            //Setup the list of game objects.
            gameObjectList = null;
            foreach (Npc npcObject in npcObjects)
            {
                gameObjectList += $"{npcObject.ID}".PadRight(ID_PAD) +
                    $"{npcObject.FirstName} {npcObject.LastName}".PadRight(NAME_PAD) +
                    $"{npcObject.CurrentPlanet}".PadRight(PLANET_PAD) +
                    " \n";
            }

            messageText += gameObjectList;

            //Return a list of the game objects with their ID, Name, and Location.
            return messageText;
        }

        /// <summary>
        /// Gets a formated list of all the game objects in the traveler's inventory.
        /// </summary>
        /// <param name="travelerInventory"></param>
        /// <returns></returns>
        public static string GetCurrentInventory(List<TravelerObject> travelerInventory)
        {
            //Variable Declarations.
            string messageText = "";
            string inventoryObjectList = "";
            int ID_PAD = 5;
            int NAME_PAD = 50;
            int CATEGORY_PAD = 10;

            //Setup the table headers and column names.
            messageText =
                " \nTraveler Inventory \n \n" +
                "ID".PadRight(ID_PAD) +
                "Name".PadRight(NAME_PAD) +
                "Object Category".PadRight(CATEGORY_PAD) + " \n" +
                "---".PadRight(ID_PAD) +
                "----------------------".PadRight(NAME_PAD) +
                "----------------------".PadRight(CATEGORY_PAD) + " \n";

            //Check to see if the traveler's inventory has any game objects.
            if(travelerInventory.Count > 0)
            {
                //If the traveler's inventory contains one or more game objects...

                //Setup the list of game objects.
                inventoryObjectList = null;
                foreach (TravelerObject inventoryObject in travelerInventory)
                {
                    inventoryObjectList += $"{inventoryObject.ItemID}".PadRight(ID_PAD) +
                        $"{inventoryObject.ItemName}".PadRight(NAME_PAD) +
                        $"{inventoryObject.ItemType}".PadRight(CATEGORY_PAD) +
                        " \n";
                }

                messageText += inventoryObjectList;
            }
            else
            {
                //If the traveler's inventory contains no game objects...

                messageText += " \nNo Game Objects in Inventory";
            }

            //Return a list of the game objects with their ID, Name, and Location.
            return messageText;
        }

        /// <summary>
        /// Returns a formated list of the game objects for a specific world.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string GetWorldGameObjects(List<GameObject> gameObjects)
        {
            //Variable Declarations.
            string gameObjectList = "";
            int ID_PAD = 5;
            string messageText = "";
            int NAME_PAD = 50;
            int PLANET_PAD = 30;
            int VALUE_PAD = 10;
            TravelerObject travelerObject;

            //Setup the table headers and column names.
            messageText =
                " \nGame Objects \n \n" +
                "ID".PadRight(ID_PAD) +
                "Name".PadRight(NAME_PAD) +
                "Object Type".PadRight(PLANET_PAD) + 
                "Object Value".PadRight(VALUE_PAD) + " \n" +
                "---".PadRight(ID_PAD) +
                "----------------------".PadRight(NAME_PAD) +
                "----------------------".PadRight(PLANET_PAD) +
                "----------------------".PadRight(VALUE_PAD) + " \n";

            //Check the number of objects for the player's current world.
            if (gameObjects.Count > 0)
            {
                //One or more objects for the current world...

                //Setup the list of game objects.
                gameObjectList = null;
                foreach (GameObject gameobject in gameObjects)
                {                    
                    travelerObject = gameobject as TravelerObject;
                    gameObjectList += $"{travelerObject.ItemID}".PadRight(ID_PAD) +
                        $"{travelerObject.ItemName}".PadRight(NAME_PAD) +
                        $"{travelerObject.ItemType}".PadRight(PLANET_PAD) +
                        $"{travelerObject.Value}" +
                        " \n";
                }
            }
            else
            {
                //No objects for the current world...
                gameObjectList += " \nNo Game Objects Present";
            }

            messageText += gameObjectList;

            //Return a list of the game objects with their ID, Name, and Location.
            return messageText;
        }

        /// <summary>
        /// Returns a formated list of the npc's for a specific world.
        /// </summary>
        /// <param name="npcObjects"></param>
        /// <returns></returns>
        public static string GetWorldNpcObjects(List<Npc> npcObjects)
        {
            //Variable Declarations.
            string npcObjectList = "";
            int ID_PAD = 5;
            string messageText = "";
            int NAME_PAD = 50;

            //Setup the table headers and column names.
            messageText =
                " \nNon-Playable Characters \n \n" +
                "ID".PadRight(ID_PAD) +
                "Name".PadRight(NAME_PAD) + " \n" +
                "---".PadRight(ID_PAD) +
                "----------------------".PadRight(NAME_PAD) + " \n";

            //Check the number of objects for the player's current world.
            if (npcObjects.Count > 0)
            {
                //One or more objects for the current world...

                //Setup the list of npc objects.
                npcObjectList = null;
                foreach (Npc npcobject in npcObjects)
                {
                    npcObjectList += $"{npcobject.ID}".PadRight(ID_PAD) +
                        $"{npcobject.FirstName} {npcobject.LastName}".PadRight(NAME_PAD) +
                        " \n";
                }
            }
            else
            {
                //No objects for the current world...
                npcObjectList += " \nNo Non-Playable Characters Present";
            }

            messageText += npcObjectList;

            //Return a list of the game objects with their ID, Name, and Location.
            return messageText;
        }

        /// <summary>
        /// Returns the information for a specific game object.
        /// </summary>
        /// <param name="travelerObject"></param>
        /// <returns></returns>
        public static string GetGameObjectDetail(TravelerObject travelerObject)
        {
            //Variable Declarations.
            string messageText = "";

            messageText = 
                $"{travelerObject.ItemName} \n \n" +
                $"{travelerObject.Description} \n \n" +
                $"The {travelerObject.ItemName} has a value of {travelerObject.Value} and is in the {travelerObject.ItemType} category.";
                

            //Return the object's information.
            return messageText;
        }

        /// <summary>
        /// Displays text in the Message Box area of the screen prompting the player to enter the NPC
        /// they want to get information about and displays a list of all NPC's on the current world.
        /// </summary>
        /// <param name="npcID"></param>
        /// <param name="planetDesignation"></param>
        /// <param name="gameUniverse"></param>
        /// <returns></returns>
        public static string GetNpcInformation(string planetDesignation, Universe gameUniverse)
        {
            //Variable Declarations.
            List<Npc> npcsForWorld = new List<Npc>();

            string messageBoxText =
                $"What NPC would you like information about? \n" +
                " \n" +
                "Please enter the number of one of the NPC's below: \n" +
                " \n";

            //Add the list of the NPC's on the current world to the message box text.
            npcsForWorld = gameUniverse.GetNpcsByWorld(planetDesignation);
            messageBoxText += Text.GetAllNpcObjects(npcsForWorld);
            
            //Return the text to display in the Message area of the screen.
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
            //Variable Declarations.
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
            //Variable Declarations.
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
