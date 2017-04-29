using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    public abstract class Npc : Character
    {
        public abstract int ID { get; set; }   //ID value for an individual npc.

        public abstract string Description { get; set; }   //A brief summary of the npc.
    }
}
