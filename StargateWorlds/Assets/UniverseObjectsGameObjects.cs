using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    public partial class UniverseObjectsGameObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new TravelerObject
            {
                ItemID = 1,
                ItemName = "Zat'nik'tel",
                PlanetDesignation = "P8X-362",
                Description = "The Zat'nik'tel is a handheld energy weapon.  The weapon is activated by squeezing " + 
                    "a switch on the bottom curve of the gun. Following this initial activation, each subsequent " + 
                    "press fires a directed energy beam",
                ItemType = TravelerObjectType.Weapons,
                Value = 0,
            },

            new TravelerObject
            {
                ItemID = 2,
                ItemName = "Ma'Tok staff",
                PlanetDesignation = "P8X-362",
                Description = "The Ma'Tok staff is a high-power, anti-personnel energy weapon.  The front end is " + 
                    "oval-shaped, which opens to reveal the barrel of the weapon.  The Ma'Tok staff fires a " + 
                    "powerful plasma blast which can kill most beings with a single shot.",
                ItemType = TravelerObjectType.Weapons,
                Value = 0,
            },

            new TravelerObject
            {
                ItemID = 3,
                ItemName = "Stun Grenades",
                PlanetDesignation = "P8X-362",
                Description = "Stun Grenades are filled with a mixture of aluminum and potassium perchlorate " +
                    "which, when ignited, produce a high-pressure wave with intense light and sound to temporarily " +
                    "overwhelm the intended target's sight and hearing for approximately ten seconds.",
                ItemType = TravelerObjectType.Weapons,
                Value = 0,
            },

            new TravelerObject
            {
                ItemID = 4,
                ItemName = "Experimental Control Crystals",
                PlanetDesignation = "P8X-362",
                Description = "Control Crystals are crystals designed to regulate various functions in advanced " + 
                    "technology. Most spacefaring races make use of crystal technology in some form.",
                ItemType = TravelerObjectType.Technology,
                Value = 0,
            },

            new TravelerObject
            {
                ItemID = 5,
                ItemName = "Personal Cloaking Device",
                PlanetDesignation = "P2Q-463",
                Description = "A personal cloaking device is a form of stealth technology that is used to selectively " + 
                    "bend light and other forms of energy thereby making a person invisible to the electromagnetic " +
                    "spectrum and most sensors.",
                ItemType = TravelerObjectType.Technology,
                Value = 45,
            },

            new TravelerObject
            {
                ItemID = 6,
                ItemName = "Naquadria",
                PlanetDesignation = "P5C-768",
                Description = "Naquadria is a highly unstable radioactive isotope of Naquadah which has the potential " +
                    "to be an enormously powerful energy source. Even a small amount is capable of emiting a pulse of " +
                    "energy far greater than that of weapons-grade Naquadah",
                ItemType = TravelerObjectType.Technology,
                Value = 0,
            },

            new TravelerObject
            {
                ItemID = 7,
                ItemName = "Advanced Agriculture Equipment",
                PlanetDesignation = "P3C-117",
                Description = "Agriculture Equipment developed by the Asgard that was specifically designed to grow " + 
                    "crops in an arid desert environment for one of their colonies in the Beta Megellan Cluster.",
                ItemType = TravelerObjectType.Equipment,
                Value = 0,
                RequiredObjects =
                {
                    {6, false},
                    {4, false},
                }
            },

            new TravelerObject
            {
                ItemID = 8,
                ItemName = "Trinium",
                PlanetDesignation = "P3X-595",
                Description = "Trinium is an element that is a hundred times lighter and stronger than steel when refined.",
                ItemType = TravelerObjectType.Resources,
                Value = 0,
                RequiredObjects =
                {
                    {7, false},
                }
            },

            new TravelerObject
            {
                ItemID = 9,
                ItemName = "General Bomb Specifications",
                PlanetDesignation = "P3X-593",
                Description = "General Information about Ra's advanced weapon.",
                ItemType = TravelerObjectType.Information,
                Value = 0,
            },

            new TravelerObject
            {
                ItemID = 10,
                ItemName = "Plans and inventory of Dakara Installation",
                PlanetDesignation = "P3X-593",
                Description = "Information concerning the layout of the Dakara Installation itself as well as the " +
                    "number of Jaffa soldiers at the installation and inventory of weapons and technology stored " + 
                    "at the base.",
                ItemType = TravelerObjectType.Information,
                Value = 0,
            },

            new TravelerObject
            {
                ItemID = 11,
                ItemName = "Interphasic Scanner",
                PlanetDesignation = "P2Q-463",
                Description = "n interphasic scanner, or simply IP scanner, is used in detecting objects which " + 
                    "existed in a state outside normal visual and sensor acuity.",
                ItemType = TravelerObjectType.Tools,
                Value = 15,
            },

            new TravelerObject
            {
                ItemID = 12,
                ItemName = "Heisenberg Compensator",
                PlanetDesignation = "P2A-509",
                Description = "The Heisenberg compensator is a component of teleportation systems. The compensator " +
                    "works around the problems caused by the Heisenberg Uncertainty Principle, allowing sensors to " +
                    "compensate for their inability to determine both the position and momentum of the target particles " +
                    "to the same degree of accuracy. This ensured the matter stream remained coherent during transport, " +
                    "and no data was lost.",
                ItemType = TravelerObjectType.Equipment,
                Value = 100,
            },

            new TravelerObject
            {
                ItemID = 13,
                ItemName = "Hyperspanner",
                PlanetDesignation = "P2Q-463",
                Description = "A hyperspanner was an adaptable multipurpose engineering tool carried aboard starships. Its " +
                    "uses included repairing communication systems, relinking and bypassing the circuit boards of electrical " +
                    "systems.",
                ItemType = TravelerObjectType.Tools,
                Value = 15,
            },

            new TravelerObject
            {
                ItemID = 14,
                ItemName = "Graviton Emitter",
                PlanetDesignation = "P2A-509",
                Description = "A graviton emitter was a device capable of producing and directing an energy form with " +
                    "gravitational properties.",
                ItemType = TravelerObjectType.Equipment,
                Value = 50,
            },

            new TravelerObject
            {
                ItemID = 15,
                ItemName = "Self-Sealing Stem Bolt",
                PlanetDesignation = "P2A-509",
                Description = "Self-sealing stem bolts were, as their name suggested, stem bolts that sealed themselves.",
                ItemType = TravelerObjectType.Equipment,
                Value = 5,
            },

            new TravelerObject
            {
                ItemID = 16,
                ItemName = "Coil Spanner",
                PlanetDesignation = "P2Q-463",
                Description = "A Coil Spanner is an engineering tool used to make adjustments to the plasma injectors " +
                    "that are part of faster than light propollson systems.",
                ItemType = TravelerObjectType.Tools,
                Value = 10,
            },

            new TravelerObject
            {
                ItemID = 17,
                ItemName = "Antigraviton Emitter",
                PlanetDesignation = "P2A-509",
                Description = "The Angigraviton Emitter sends out a high concentrated beam of charged antigravitons that is designed to disrupt the field generated by a shield emitter.",
                ItemType = TravelerObjectType.Equipment,
                Value = 50,
            },

            new TravelerObject
            {
                ItemID = 18,
                ItemName = "Micro-Resonator",
                PlanetDesignation = "P2Q-463",
                Description = "The Micro-Resonator is a tool used by engineers to degauss relatively small devices.",
                ItemType = TravelerObjectType.Tools,
                Value = 5,
            },

            new TravelerObject
            {
                ItemID = 19,
                ItemName = "Tomographic Imaging Scanner",
                PlanetDesignation = "P2A-509",
                Description = "A Tomographic Imaging Scanner was a device designed to function as a sensor to scan deep layers of subspace. The scanner is capable of multiphasic resolution and can penetrate significant amounts of subspace interference.",
                ItemType = TravelerObjectType.Equipment,
                Value = 45,
            },

            new TravelerObject
            {
                ItemID = 20,
                ItemName = "Directional Sonic Generator",
                PlanetDesignation = "P2A-509",
                Description = "A Directional Sonic Generator is a device capable of producing a wide range of sound frequencies.",
                ItemType = TravelerObjectType.Equipment,
                Value = 0,
            },
        };
    }
}
