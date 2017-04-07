using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    public abstract class GameObject
    {
        public abstract int ItemID { get; set; }

        public abstract string ItemName { get; set; }

        public abstract string Description { get; set; }

        public abstract string PlanetDesignation { get; set; }
    }
}
