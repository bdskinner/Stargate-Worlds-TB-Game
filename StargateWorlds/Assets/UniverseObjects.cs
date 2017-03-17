using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's
    /// </summary>
    public static class UniverseObjects
    {
        public static List<World> Worlds = new List<World>()
        {

            new World
            {
                CommonName = "Stargate Command, Earth",
                PlanetDesignation = "P2X-3YZ",
                UniversalLocation = "P-1, SS-278, G-2976, LS-3976",
                Description = "Stargate Command is a beyond top secret Airforce base " +
                    "located under Cheyenne Mountain, outside Colorado Springs, Colorado " +
                    "that houses Earth's stargate.\n",
                GeneralContents = "The Gate Room is a large, well lit room, that is the on base " +
                    "location for the Stargate.  This room is overlooked by the Control Room, " +
                    "which is the operational center for all activities involving the Stargate. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Grand Counsel Meeting Room, Abydos",
                PlanetDesignation = "P3X-595",
                UniversalLocation = "P-2, SS-278, G-2976, LS-3976",
                Description = "The meeting room of the Abydos Grand Counsel is located in " +
                    "The Great Pyramid of Abydos that was constructed at the beginning of Ra's " +
                    "rule of Abydos.  The meeting room adjoins the room that contains the " +
                    "Abydonian Stargate.\n",
                GeneralContents = "The Grand Counsel Meeting Room is lit almost entirely by torches, " +
                    "with light streaming in through a series of small windows located high up on " +
                    "two walls of the chamber. The room is usually busy with the activity of counselors " +
                    "and aids discussing and debating various issues. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Thor's Laboratory, Asgard Prime",
                PlanetDesignation = "P3C-117",
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "Thor's laboratory is located in the Asgard Central Research Facility " +
                    "on Asgard Prime's southwest continent.  This facility has been in continous  " +
                    "operation for several thousand years and has been responsible for a majority " +
                    "of the technological advancement on Asgard Prime.\n",
                GeneralContents = "Thor's Lab is a large dimly lit room contains may tables, shelves, and workbenches, " +
                    "all of which are covered with various types of advanced technology.  Because of " +
                    "the shorter stature of the Asgard race everything in the lab appears small to" + 
                    "other visiting races like Humans. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Dakara Installation, Chulak",
                PlanetDesignation = "P8X-362",
                UniversalLocation = "P-4, SS-278, G-2976, LS-3976",
                Description = "The Dakara Installation is a military installation used by the Jaffa soldiers " +
                    "on Chulak for the storage of military equipment like weapons, technology, and supplies.  " +
                    "Located near the Chulak Stargate, the Dakara Installation provides a convienent place " +
                    "for Jaffa soldiers to re-supply between missions to other worlds.\n",
                GeneralContents = "The Dakara Installation contains a maze of hallways and store rooms.  The structure of the " +
                    "installation is made up of masonary, concrete, and steel, and is guarded by two units of " +
                    "Jaffa soldiers. " +
                    " \n",
                Accessable = false,
            },

            new World
            {
                CommonName = "Tok'Ra Counsel Chamber, Simarka ",
                PlanetDesignation = "P3X-593",
                UniversalLocation = "P-5, SS-278, G-2976, LS-3976",
                Description = "Located below the surface of Simarka in artiicially generated caves, the Tok'Ra's " +
                    "Counsel Chamber is surprising well lit for an underground structure.  Light is provided by " +
                    "chrystals that have been embedded into the cave walls.  The Tok'Ra can manipulate the " +
                    "structure of the cave system to provide their group with whatever space they need.\n",
                GeneralContents = "The Counsel Meeting Chamber is only generated when needed for official business.  The walls, " +
                    "ceiling, and floor have a glassy appearance.  The members of the Tok'Ra counsel sit on " +
                    "two sides of a three sided table that is made from the same material as the rest of the room. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Kahndahar Province Central Hospital, Jebanna",
                PlanetDesignation = "P4A-771",
                UniversalLocation = "P-6, SS-278, G-2976, LS-3976",
                Description = "On the Nakuru Plains in the Kahndahar Province the Central Hospital is the largest " +
                    "medical facility in the Kahndahar Province.  The Central Hospital treats more than 5,000 patients " +
                    "every year using medicines derived from the variety of local plant life." +
                    ".\n",
                GeneralContents = "The Central Hospital's main treatment area is an open and moderately well lit space.   The facility " +
                    "is staffed with some of the best healers in the province.  The main treatment area branches off into " +
                    "smaller areas for individual are for more specialized treatment.  Each alcove is equiped with an " +
                    "array of medical tools that can treat a wide variety of minor to moderate injuryies. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Plascon Manufacturing Facitlity, Reetalia",
                PlanetDesignation = "P2A-509",
                UniversalLocation = "P-7, SS-278, G-2976, LS-3976",
                Description = "Plascon Manufacturing is located in the heart of industrial sector of the capital city of Luton. " +
                    "Plascon manufactures advanced repair and diagnostic equipment for a variety of engineering applications. .\n",
                GeneralContents = "Plascon manufactures a variety of repair and diagnostic equipment ranging from Heisenberg Compensators to " +
                    "Graviton Emitters.  Any equipment that Plascon produces can be acquired not only from the many facilities " +
                    "that sell repair and diagnostic equipment, but also directly from the Plascon Facility. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Portobello Road Market, Vyus",
                PlanetDesignation = "P2Q-463",
                UniversalLocation = "P-8, SS-278, G-2976, LS-3976",
                Description = "Located on the 300 and 400 blocks of Portobello Road in the capital city of Warrington the " +
                    "Portobello Road Market is one of the busiest trading places in the gate network. \n",
                GeneralContents = "Stands, carts, and kiosks line each side of the 300 and 400 blocks of Portobello Road " +
                    "giving the visitor to the market a wide variety of choices in merchandise.  Everything from refurbished " +
                    "Laser Drills and Magna-Spanners to Maglocks and Holographic Imagers can be found and acquired here... " +
                    "for a price. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Dagenham Industries, Tollana",
                PlanetDesignation = "P3A-707",
                UniversalLocation = "P-9, SS-278, G-2976, LS-3976",
                Description = "Dagenham Industries is located in the heart of industrial sector of the capital city of Telford. " +
                    "Dagenham manufactures advanced repair and diagnostic equipment for a variety of engineering applications. .\n",
                GeneralContents = "Dagenham manufactures a variety of repair and diagnostic equipment ranging from Coil Spanners to " +
                    "Interphasic Scanners.  Any equipment that Dagenham produces can be acquired not only from the many facilities " +
                    "that sell repair and diagnostic equipment, but also directly from the Dagenham Facility. \n",
                Accessable = true,
            },

            new World
            {
                CommonName = "Beloyarsk Power Station, Edora",
                PlanetDesignation = "P5C-768",
                UniversalLocation = "P-10, SS-278, G-2976, LS-3976",
                Description = "Located on the banks of the Beloyarsk River in the city of Wigan, the Beloyarsk Power Station does " +
                    "not resemble a traditional power station if viewed from the outside.  Rising 5 stories above the Beloyarsk  " +
                    "River the building is clad in glass panels, making it appear more like an office building or high rise.  The " +
                    "Beloyarsk Power Station produces  40% of the power used in the city of Wigan using Niquadria in combination " +
                    "with other exotic fuels.\n",
                GeneralContents = "The Beloyarsk Power Station contains a maze of hallways, pipes, and wiring.  The largest area is " +
                    "the control room, where most of the staff of the station coordinate the operation of the plant.  The fuels used " +
                    "in the generation of power are housed in separate reinforced store rooms located in the basement of the facility. " +
                    " \n",
                Accessable = false,
            },





            //new World
            //{
            //    CommonName = "",
            //    PlanetDesignation = "",
            //    UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
            //    Description = " " +
            //        " " +
            //        " " +
            //        ".\n",
            //    GeneralContents = ", " +
            //        " " +
            //        " " +
            //        " \n",
            //    Accessable = true,
            //},


            //new World
            //{
            //    CommonName = "Aion Base Lab",
            //    SpaceTimeLocationID = 1,
            //    UniversalDate = 386759,
            //    UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
            //    Description = "The Norlon Corporation research facility located in " +
            //        "the city of Heraklion on the north coast of Crete and the top secret " +
            //        "research lab for the Aion Project.\n",
            //    GeneralContents = "The lab is a large, well lit room, and staffed " +
            //        "by a small number of scientists, all wearing light blue uniforms with the " +
            //        "hydra-like Norlan Corporation logo. \n",
            //    Accessable = true,
            //    ExperiencePoints = 10
            //},

            //new World
            //{
            //    CommonName = "Felandrian Plains",
            //    SpaceTimeLocationID = 2,
            //    UniversalDate = 386759,
            //    UniversalLocation = "P-2, SS-85, G-2976, LS-3976",
            //    Description = "The Felandrian Plains are a common destination for tourist. " +
            //        "Located just north of the equatorial line on the planet of Corlon, they " +
            //        "provide excellent habitat for a rich ecosystem of flora and fauna.",
            //    GeneralContents = "- stuff in the room -",
            //    Accessable = true,
            //    ExperiencePoints = 10
            //},

            //new World
            //{
            //    CommonName = "Xantoria Market",
            //    SpaceTimeLocationID = 3,
            //    UniversalDate = 386759,
            //    UniversalLocation = "P-6, SS-3978, G-2976, LS-3976",
            //    Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
            //                  "open market managed by the Xantorian Commerce Coop. It is a place " +
            //                  "where many races from various systems trade goods.",
            //    GeneralContents = "- stuff in the room -",
            //    Accessable = true,
            //    ExperiencePoints = 20
            //},

            //new World
            //{
            //    CommonName = "Norlon Corporate Headquarters",
            //    SpaceTimeLocationID = 4,
            //    UniversalDate = 386759,
            //    UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
            //    Description = "The Norlon Corporation Headquarters is located in just outside of Detroit Michigan." +
            //                  "Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company " +
            //                  "with huge holdings in defense and space research and development.",
            //    GeneralContents = "- stuff in the room -",
            //    Accessable = true,
            //    ExperiencePoints = 10
            //}
        };
    }
}
