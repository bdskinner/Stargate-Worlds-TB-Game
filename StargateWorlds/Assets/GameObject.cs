using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    public abstract class GameObject
    {
        public abstract int ItemID { get; set; }   //ID value for the game object.

        public abstract string ItemName { get; set; }   //Name of the game object.

        public abstract string Description { get; set; }   //A brief description of what the game object is.

        public abstract string PlanetDesignation { get; set; }   //The designation of the world the item is on.
    }
}
