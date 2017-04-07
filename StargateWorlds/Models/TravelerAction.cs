using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum TravelerAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAtObject,
        PickUpObject,
        PickUpTreasure,
        PutDownObject,
        PutDownTreasure,
        Travel,
        TravelerLocationsVisited,
        TravelerInfo,
        TravelerEdit,
        TravelerInventory,
        TravelerTreasure,
        ListTARDISDestinations,
        DisplayInventory,
        ListGameObjects,
        ListTreasures,
        ListWorlds,
        AdminMenu,
        TravelMenu,
        InventoryMenu,
        ReturnToMainMenu,
        Exit
    }
}
