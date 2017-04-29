using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    public static partial class UniverseNpcs
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                ID = 1,
                FirstName = "George",
                LastName = "Hammond",
                Description = "Gen. George Hammond is the commander of the Stargate Facility and oversees the operations of te base and all travel involving the Stargate.",
                CurrentPlanet = "P2X-3YZ",
                Messages = new List<string>
                {
                    "Go to Abydos and talk to Kasuf.  He can help you get the Trinium.",
                    "The Asgard might have the agriculture equipment the people of Abydos need. Go to Asgard Prime and talk with Thor.",
                    "We need to know more about Ra's bomb.",
                    "Dakara on Chulak is a dangerous place, make sure you get information on the base.",
                    "To get any good information talk to Selmak with the Tok'ra on Simarka.",
                    "Surely you can't be serious",
                }
            },

            new Civilian
            {
                ID = 2,
                FirstName = "Thor",
                LastName = "",
                Description = "Thor is the supreme commander of the Asgard Space Fleet.  As a leader among the advanced and ancient Asgard people, Thor has remained one of Earth's greatest allies. ",
                CurrentPlanet = "P3C-117",
                Messages = new List<string>
                {
                    "I have some agriculture equipment that would suit your needs.",
                    "If you get Naquadria from Edora and the Experimental Control Crystals the Gou'ald have been developing on Chulak, the agraculture equipment is yours.",
                    "Do not go to the Dakara Installation on Chulak without information about the base.",
                    "You might want to get the more advanced weapons while on Chulak to help you on Edora.",
                }
            },

            new Civilian
            {
                ID = 3,
                FirstName = "Selmak ",
                LastName = "",
                Description = "Selmak is among the oldest and wisest in the Tok'ra ranks.  Selmak has been the respected leader of the Tok'ra High Council for almost 2,000 years.  ",
                CurrentPlanet = "P3X-593",
                Messages = new List<string>
                {
                    "The Tok'ra have collected information on the Dakara Installation and what the Gou'ald have stored there.",
                    "The bomb specifications will help you better defend against what Ra has planned.",
                    "To have a better chance of getting the Naquadria on Edora, you can acquire a cloaking device on Vyrus.",
                }
            },

            new Civilian
            {
                ID = 4,
                FirstName = "Kasuf",
                LastName = "",
                Description = "Kasuf is the leader of the Abydonians.",
                CurrentPlanet = "P3X-595",
                Messages = new List<string>
                {
                    "It is good to see you again.",
                    "We can help you get the Trinium you need.",                    
                    "We need your help in return to get new agraculture equipment to expand our fields.",
                    "I will make arrangements for the Trinium.  Skaara will want to see you before you leave.",
                }
            },

            new Civilian
            {
                ID = 5,
                FirstName = "Skaara",
                LastName = "",
                Description = "Skaara has been intrumental in previous missions SG-1 has been given.  The young Abydonian is very resourceful and adept at gathering materials and information.",
                CurrentPlanet = "P3X-595",
                Messages = new List<string>
                {
                    "Welcom, welcome, I am most pleased to see you again.",
                    "I am troubled to hear your world is in danger.  I'm sure my father can help you with what you need.",
                    "To aid you in your mission, there is a world I have heard of that might help you.  If the stories I have heard are true, going to Cimmeria can help you get to other places you need to go.  If you think that might help you the address is P3X-974",
                    "Good luck with your mission my friend.",
                }
            },

            new Civilian
            {
                ID = 6,
                FirstName = "Sha'uri",
                LastName = "",
                Description = "Sha'uri was among the first group to befriend SG-1 on their first mission to Abydos.  Her gift for picking up new languages as well as accurately interpreting various dialects has helped SG-1 on several missions.",
                CurrentPlanet = "P3X-595",
            },

            new Warrior
            {
                ID = 7,
                FirstName = "Jaffa Soldiers",
                LastName = "",
                Description = "A unit of Jaffa soldiers.",
                CurrentPlanet = "P8X-362",
                Messages = new List<string>
                {
                    "You have trespassed on our world, that is not acceptable.",
                }
            },
        };
    }
}
