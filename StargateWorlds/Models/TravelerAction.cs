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
        BattleNpc,
        DisplayInventory,
        LookAround,
        LookAtObject,
        NpcInformation,
        PickUpObject,
        PickUpTreasure,
        PutDownObject,
        TalkToNpc,
        Travel,
        TravelerLocationsVisited,
        TravelerInfo,
        TravelerEdit,
        TravelerInventory,
        ListGameObjects,
        ListNonplayerCharacters,
        ListWorlds,
        AdminMenu,
        TravelMenu,
        InventoryMenu,
        NpcMenu,
        ReturnToMainMenu,
        Exit
    }
}
