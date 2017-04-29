using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    interface IBattle
    {
        Traveler.HealthChange Battle(Traveler gameTraveler);
    }
}
