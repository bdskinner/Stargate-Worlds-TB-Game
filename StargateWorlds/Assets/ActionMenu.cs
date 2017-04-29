using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, TravelerAction>()
                    {
                        { ' ', TravelerAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.AdminMenu },
                    { '2', TravelerAction.TravelMenu },
                    { '3', TravelerAction.InventoryMenu },
                    { '4', TravelerAction.NpcMenu },
                    { '5', TravelerAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.TravelerInfo },
                    { '2', TravelerAction.TravelerEdit },
                    { '3', TravelerAction.ListWorlds },
                    { '4', TravelerAction.TravelerLocationsVisited },
                    { '5', TravelerAction.ListGameObjects },
                    { '6', TravelerAction.ListNonplayerCharacters },
                    { '7', TravelerAction.ReturnToMainMenu }
                }
        };

        public static Menu InventoryMenu = new Menu()
        {
            MenuName = "InventoryMenu",
            MenuTitle = "Inventory Menu",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.DisplayInventory },
                    { '2', TravelerAction.PickUpObject },
                    { '3', TravelerAction.PutDownObject },
                    { '4', TravelerAction.LookAtObject },
                    { '5', TravelerAction.ReturnToMainMenu }
                }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.TalkToNpc },
                    { '2', TravelerAction.NpcInformation },
                    { '3', TravelerAction.ReturnToMainMenu }
                }
        };

        public static Menu TravelMenu = new Menu()
        {
            MenuName = "TravelMenu",
            MenuTitle = "Travel Menu",
            MenuChoices = new Dictionary<char, TravelerAction>()
                {
                    { '1', TravelerAction.Travel },
                    { '2', TravelerAction.LookAround },
                    { '3', TravelerAction.ReturnToMainMenu }
                }
        };

        public enum CurrentMenu
        {
            AdminMenu,
            InventoryMenu,
            MainMenu,
            TravelMenu,
            NpcMenu,
            InitializeMission
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;
    }
}
