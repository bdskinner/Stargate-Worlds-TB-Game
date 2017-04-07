using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    public class TravelerObject : GameObject
    {
        public override int ItemID { get; set; }  //Unique ID reference for the individual item.

        public override string ItemName { get; set; }  //Common name of the item.

        public override string Description { get; set; }  //A brief description of the item and what it does.

        public override string PlanetDesignation { get; set; }  //The planet designation for the world the item is located on (zero if in the traveler's inventory).

        public TravelerObjectType ItemType { get; set; }  //The type of game object that the traveler can put in their inventory.

        public int Value { get; set; }  //The monetary value (in Gold Coins) of the game object.
    }
}
