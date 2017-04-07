using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        private List<GameObject> _gameObjects;
        private List<World> _worlds;
        
        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public List<World> Worlds
        {
            get { return _worlds; }
            set { _worlds = value; }
        }
        
        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // add all of the universe objects to the game
            // 
            IntializeUniverse();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverse()
        {
            _worlds = UniverseObjectsWorldLocations.Worlds as List<World>;
            _gameObjects = UniverseObjectsGameObjects.gameObjects as List<GameObject>;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// Returns a game object for a specific ID value.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public GameObject GetGameObjectByID(int ID)
        {
            //Variable Declarations.
            GameObject gameObjectTotReturn = null;

            //Check the list of game objects for the id value. 
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.ItemID == ID)
                {
                    gameObjectTotReturn = gameObject;
                }
            }

            //If the id is not found throw an error.
            if(gameObjectTotReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {ID} does not exist in the current Universe.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            //Return the gameobject information.
            return gameObjectTotReturn;
        }

        /// <summary>
        /// Returns a list of game objects for a specific world.
        /// </summary>
        /// <param name="planetDesignation"></param>
        /// <returns></returns>
        public List<GameObject> GetGameObjectsByWorld(string planetDesignation)
        {
            //Variable Declarations.
            List<GameObject> gameObjects = new List<GameObject>();

            //Go through the list of game objects and add the objects from the specific world to the list.
            foreach (GameObject gameObject in _gameObjects)
            {
                if(gameObject.PlanetDesignation == planetDesignation)
                {
                    gameObjects.Add(gameObject);
                }
            }

            //Return the list of game objects for the specific world.
            return gameObjects;
        }

        /// <summary>
        /// get a SpaceTimeLocation object using an ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public World GetWorldByID(string ID)
        {
            World worldLocation = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (World location in _worlds)
            {
                if (location.PlanetDesignation == ID)
                {
                    worldLocation = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (worldLocation == null)
            {
                string feedbackMessage = $"The planet {ID} does not exist in the current Universe.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return worldLocation;
        }

        /// <summary>
        /// Returns the planet designation of the world that will have its accessibility updated.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetWorldToUpdate(int ID)
        {
            //Variable Declarations.
            string worldToUpdate = "";

            //Look through the required items for each world to find the id for an item added to inventory.
            foreach (World world in _worlds)
            {
                //If the world's contains the restricted object get the planet designation.
                if (world.RequiredObjects.Keys.Contains(ID))
                {
                    worldToUpdate = world.PlanetDesignation;
                    break;
                }
            }

            //Return the world's planet designation.
            return worldToUpdate;
        }

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="spaceTimeLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(string planetDesignation)
        {
            World world = GetWorldByID(planetDesignation);
            if (world.Accessable == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the planet designation provided to make sure it is valid.
        /// </summary>
        /// <param name="planetDesignation"></param>
        /// <returns></returns>
        public bool IsValidPlanetDesignation(string planetDesignation)
        {
            List<string> planeetDesignations = new List<string>();

            //
            // create a list of space-time location ids
            //
            foreach (World stl in _worlds)
            {
                planeetDesignations.Add(stl.PlanetDesignation);
            }

            //
            // determine if the space-time location id is a valid id and return the result
            //
            if (planeetDesignations.Contains(planetDesignation))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Puts the game object entered by the user into the traveler's inventory.
        /// </summary>
        /// <param name="_gameUniverse"></param>
        /// <param name="_gameTraveler"></param>
        /// <param name="_consoleView"></param>
        public void PutDownItem(Universe _gameUniverse, Traveler _gameTraveler, ConsoleView _consoleView)
        {
            //Variable Declarations.
            string gameObjectList = "";
            int ID = 0;
            TravelerObject objectToRemove;
            GameObject objectToUpdate = null;
            string worldToUpdate = "";

            //Check the traveler's inventory to see if it contains any game objects.
            if (_gameTraveler.TravelerInventory.Count > 0)
            {
                //If there are one or more items in the traveler's inventory...

                //Display the traveler's current inventory.
                gameObjectList = Text.GetCurrentInventory(_gameTraveler.TravelerInventory);
                _consoleView.DisplayGamePlayScreen("Traveler Inventory", gameObjectList, ActionMenu.InventoryMenu, "Enter ID of Item to put down: ");

                //Get the ID value of the game object the player wants to put into inventory.
                _consoleView.GetInteger("Enter ID of Item to put down: ", 0, 0, out ID);
                
                //If the player entered 0 then put down all the game objects in the traveler's inventory on the current world.
                //if (ID == 0)
                //{
                //    PutDownAll(_gameTraveler.CurrentPlanet, _gameTraveler);
                //}
                
                //Determine whether or not the game object entered by the player is in the traveler's inventory.
                if (IsValidInventoryItem(ID, _gameTraveler) == true)
                {
                    //Game object is in inventory...

                    //Get the game object that has the ID value in the parameter.
                    objectToUpdate = GetGameObjectByID(ID);

                    //Change the planet designation of the game object to the planet designation of the current world.
                    objectToUpdate.PlanetDesignation = _gameTraveler.CurrentPlanet;

                    //Remove the game object from the travelerInventory in the Traveler class.
                    objectToRemove = objectToUpdate as TravelerObject;
                    _gameTraveler.TravelerInventory.Remove(objectToRemove);

                    //Update the world accessibility.
                    worldToUpdate = GetWorldToUpdate(ID);
                    if (worldToUpdate != "")
                    {
                        //If there is a world to update the accessiblility of...

                        UpdateWorldAccessibility(GetWorldToUpdate(ID), _gameTraveler);
                    }
                    
                    //Tell the player the game object has been added to the traveler inventory.
                    _consoleView.DisplayGamePlayScreen("Traveler Inventory Updated", $"{objectToUpdate.ItemName} has been removed to your inventory.", ActionMenu.InventoryMenu, "");
                }
                else
                {
                    //Game object is not in inventory...

                    //Display an error message in the Input Box area of the screen.
                    _consoleView.DisplayInputErrorMessage("The object entered is not currently in inventory.  Press any key to continue.");
                    Console.ReadKey();


                    //if (ID != 0)
                    //{
                    //    _consoleView.DisplayInputErrorMessage("The object entered is not currently in inventory.  Press any key to continue.");
                    //    Console.ReadKey();
                    //}


                    _consoleView.DisplayGamePlayScreen("Inventory Menu", "Select an operation from the menu.", ActionMenu.InventoryMenu, "");
                }
            }
            else
            {
                //If there are no items in the traveler's inventory...

                //Display the traveler's current inventory.
                gameObjectList = Text.GetCurrentInventory(_gameTraveler.TravelerInventory);
                _consoleView.DisplayGamePlayScreen("Traveler Inventory", gameObjectList, ActionMenu.InventoryMenu, "");
            }
        }

        /// <summary>
        /// Puts the game object entered by the user into the traveler's inventory.
        /// </summary>
        /// <param name="_gameUniverse"></param>
        /// <param name="_gameTraveler"></param>
        /// <param name="_consoleView"></param>
        public void PickupItem(Universe _gameUniverse, Traveler _gameTraveler, ConsoleView _consoleView)
        {
            //Variable Declarations.
            string gameObjectList = "";
            int ID = 0;
            TravelerObject objectToAdd;
            GameObject objectToUpdate;
            string worldToUpdate = "";
            
            //Check the traveler's inventory to see if it contains any game objects.
            if(_gameUniverse.GetGameObjectsByWorld(_gameTraveler.CurrentPlanet).Count > 0)
            {
                //If there are one or more items on the current world the traveler can pickup...

                //Display a list of items for the current world.
                gameObjectList = Text.GetWorldGameObjects(_gameUniverse.GetGameObjectsByWorld(_gameTraveler.CurrentPlanet));
                _consoleView.DisplayGamePlayScreen("Game Objects", gameObjectList, ActionMenu.InventoryMenu, "Enter ID of Item to pickup: ");

                //Get the ID value of the game object the player wants to put into inventory.
                _consoleView.GetInteger("Enter ID of Item to pickup: ", 0, 0, out ID);

                //If the player entered 0 then pick up all game objects from the current world and add them to the traveler's inventory.
                //if (ID == 0)
                //{
                //    PickupAll(_gameTraveler.CurrentPlanet, _gameTraveler);
                //}
                
                //Determine whether or not the game object the player entered is on the world.
                if (IsValidGameOBjectByWorldID(ID, _gameTraveler.CurrentPlanet) == true)
                {
                    //The object is on the world...

                    //Get the game object that has the ID value in the parameter.
                    objectToUpdate = GetGameObjectByID(ID);

                    //Change the planet designation of the game object to "0" to put it into the traveler's inventory.
                    objectToUpdate.PlanetDesignation = "0";

                    //Add the object to the TravelerInventory list in the Traveler class.
                    objectToAdd = objectToUpdate as TravelerObject;
                    _gameTraveler.TravelerInventory.Add(objectToAdd);

                    //Update the world accessibility.
                    worldToUpdate = GetWorldToUpdate(ID);
                    if (worldToUpdate != "")
                    {
                        //If there is a world to update the accessiblility of...

                        UpdateWorldAccessibility(GetWorldToUpdate(ID), _gameTraveler);
                    }

                    //Tell the player the game object has been added to the traveler inventory.
                    _consoleView.DisplayGamePlayScreen("Traveler Inventory Updated", $"{objectToUpdate.ItemName} has been added to your inventory.", ActionMenu.InventoryMenu, "");
                }
                else
                {
                    //The object is not on the world...

                    //Display an error message in the Input Box area of the screen.
                    _consoleView.DisplayInputErrorMessage("The object entered is not available on this world.  Press any key to continue.");
                    Console.ReadKey();


                    //if (ID != 0)
                    //{
                    //    _consoleView.DisplayInputErrorMessage("The object entered is not available on this world.  Press any key to continue.");
                    //    Console.ReadKey();
                    //}


                    _consoleView.DisplayGamePlayScreen("Inventory Menu", "Select an operation from the menu.", ActionMenu.InventoryMenu, "");
                }
            }
            else
            {
                //If there are no items in the traveler's inventory...

                //Display a list of items for the current world.
                gameObjectList = Text.GetWorldGameObjects(_gameUniverse.GetGameObjectsByWorld(_gameTraveler.CurrentPlanet));
                _consoleView.DisplayGamePlayScreen("Game Objects", gameObjectList, ActionMenu.InventoryMenu, "");
            }
        }

        /// <summary>
        /// Adds all game objects on the player's current world to the traveler's inventory.
        /// </summary>
        /// <param name="planetDesignation"></param>
        /// <param name="gameTraveler"></param>
        private void PickupAll(string planetDesignation, Traveler gameTraveler)
        {
            //Variable Declarations.
            List<GameObject> gameObjects;
            string worldToUpdate = "";

            //Get a list of game objects for the current world (GetObjectsByWorld method)
            gameObjects = GetGameObjectsByWorld(planetDesignation);

            //Loop through the list of game objects for the curret world
            foreach (GameObject gameObject in gameObjects)
            {
                //Set the planet designation to "0".
                gameObject.PlanetDesignation = "0";

                //Add the game object to the travelerinventory list in the traveler object.
                gameTraveler.TravelerInventory.Add(gameObject as TravelerObject);

                //Check to see if the world accessibility needs to be updated.  UpdateWorldAccessibility              
                worldToUpdate = GetWorldToUpdate(gameObject.ItemID);
                if (worldToUpdate != "")
                {
                    //If there is a world to update the accessiblility of...

                    UpdateWorldAccessibility(worldToUpdate, gameTraveler);
                }
            }
        }

        /// <summary>
        /// Removes all game objects from the traveler's inventory and puts the on the current world.
        /// </summary>
        /// <param name="planetDesignation"></param>
        /// <param name="gameTraveler"></param>
        private void PutDownAll(string planetDesignation, Traveler gameTraveler)
        {
            //Variable Declarations.
            string worldToUpdate = "";

            //Loop through the list of game objects.
            foreach (GameObject gameObject in _gameObjects)
            {
                //If the game object are in the traveler's inventory remove it.
                if(gameObject.PlanetDesignation == "0")
                {
                    //Set the planet designation to the current world.
                    gameObject.PlanetDesignation = gameTraveler.CurrentPlanet;

                    //Remove the game object to the travelerinventory list in the traveler object.
                    gameTraveler.TravelerInventory.Remove(gameObject as TravelerObject);

                    //Check to see if the world accessibility needs to be updated.  UpdateWorldAccessibility              
                    worldToUpdate = GetWorldToUpdate(gameObject.ItemID);
                    if (worldToUpdate != "")
                    {
                        //If there is a world to update the accessiblility of...

                        UpdateWorldAccessibility(worldToUpdate, gameTraveler);
                    }
                }
            }
        }

        /// <summary>
        /// Changes whether or not a specific planet is accessible to the player.
        /// </summary>
        /// <param name="planetDesignation"></param>
         public void UpdateWorldAccessibility(string planetDesignation, Traveler gameTraveler)
        {
            //Variable Declarations.
            World worldToUpdate;
            GameObject gameObjectToCheck;
            TravelerObject travelerObjectToCheck;

            //Get the world information.
            worldToUpdate = GetWorldByID(planetDesignation);

            //Loop through the world's required items, if they are in inventory mark the dictionary's value component to true.
            foreach (KeyValuePair<int, bool> requiredItem in worldToUpdate.RequiredObjects)
            {
                //Get the travelerobject info.
                gameObjectToCheck = GetGameObjectByID(requiredItem.Key);
                travelerObjectToCheck = gameObjectToCheck as TravelerObject;

                //Check the traveler's inventory for the travelerobject.
                if(gameTraveler.TravelerInventory.Contains(travelerObjectToCheck))
                {
                    //The required item is in the traveler's inventory...

                    //Update the value component of the worlds required items dictionary to 'true'.
                    worldToUpdate.RequiredObjects[travelerObjectToCheck.ItemID] = true;
                    break;
                }
                else
                {
                    //The required item is not in the traveler's inventory...

                    //Update the value component of the worlds required items dictionary to 'false'.
                    worldToUpdate.RequiredObjects[travelerObjectToCheck.ItemID] = false;
                    break;
                }
            }

            //Loop through the world's required items, if all value components of the dictionary are true change the world's accessibility property to true.
            foreach (KeyValuePair<int, bool> requiredItem in worldToUpdate.RequiredObjects)
            {
                //Check to see if all required items to access the world are in inventory.
                if(worldToUpdate.RequiredObjects.Values.Contains(false) == false)
                {
                    //All game objects are in inventory...

                    //set the world accessibility to true.
                    worldToUpdate.Accessable = true;
                    break;
                }
                else
                {
                    //All game objects are not in inventory...

                    //set the world accessibility to false.
                    worldToUpdate.Accessable = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether or not a specific game object is on a specific world.
        /// </summary>
        /// <param name="gameObjectID"></param>
        /// <param name="planetDesignation"></param>
        /// <returns></returns>
        public bool IsValidGameOBjectByWorldID(int gameObjectID, string planetDesignation)
        {
            //Variable Declarations.
            List<int> gameObjects = new List<int>();

            //Get a list of game objects for the current world.
            foreach (GameObject gameoObject in _gameObjects)
            {
                if(gameoObject.PlanetDesignation == planetDesignation)
                {
                    gameObjects.Add(gameoObject.ItemID);
                }
            }

            //Determine whether the game object is on the current world.
            if(gameObjects.Contains(gameObjectID) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether or not a specific item is in the traveler's inventory.
        /// </summary>
        /// <param name="gameObjectID"></param>
        /// <param name="gameTraveler"></param>
        /// <returns></returns>
        public bool IsValidInventoryItem(int gameObjectID, Traveler gameTraveler)
        {
            //Variable Declarations.
            List<int> inventoryObjects = new List<int>();

            //Get a list of game object ID's for the game objects in the traveler's inventory.
            foreach (TravelerObject travelerObject in gameTraveler.TravelerInventory)
            {
                inventoryObjects.Add(travelerObject.ItemID);
            }

            //Determine whether or not the game object is currently in the traveler's inventory.
            if(inventoryObjects.Contains(gameObjectID) == true)
            {
                //Game Object is in inventory...

                return true;
            }
            else
            {
                //Game Object is not in inventory...

                return false;
            }
        }

        #endregion
    }
}
