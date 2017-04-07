using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{

    //public enum TravelerHealth
    //{
    //    None = 0,
    //    VeryGood = 6,
    //    Good = 5,
    //    Moderate = 4,
    //    Poor = 3,
    //    VeryPoor = 2,
    //    Dead = 1
    //}

    //public enum HealthChange
    //{
    //    MajorInjury = -3,
    //    ModerateInjury = -2,
    //    MinorInjury = -1,
    //    FullHealing = 3,
    //    PartialHealing = 2
    //}

    class Program
    {
        static void Main(string[] args)
        {
            // **************************************************
            //
            // Title: Stargame Worlds Text-based Game
            // Description: This text-based game puts the player into the role of a traveler through
            //      a stargate that must travel to other worlds to get the necessary information and 
            //      items to prevent an attack by Ra, a domineering system lord, who is bent on 
            //      destroying Earth.
            // Application Type: Console Application
            // Author: Matt Grifin, Ben Skinner
            // Dated Created: 2/21/2017         
            // Last Modified: 4/5/2017         
            //
            // **************************************************


            //CHANGE TRAVELER HEALTH
            //TravelerHealth health = TravelerHealth.Good;
            //HealthChange healthChange = HealthChange.PartialHealing;

            //Console.WriteLine("The traveler's health is: " + health);
            //health += (int)healthChange;
            //if ((int)health <= (int)TravelerHealth.Dead) health = TravelerHealth.Dead;
            //if ((int)health >= (int)TravelerHealth.VeryGood) health = TravelerHealth.VeryGood;
            //Console.WriteLine("The traveler's health is: " + health);
            //Console.ReadKey();


            //CHANGE WORLD ACCESSIBILITY
            //_gameUniverse.Worlds[3].Accessable = true;


            //UPDATE THE VALUE PART OF THE KEY-VALUE PAIR IN A DICTIONARY
            //Dictionary<int, bool> testdictionary = new Dictionary<int, bool>();
            //Console.WriteLine("Original Dictionary Values: \n");
            //testdictionary.Add(1, false);
            //testdictionary.Add(2, false);
            //testdictionary.Add(3, false);
            //testdictionary.Add(4, false);
            //testdictionary.Add(5, false);
            //foreach (KeyValuePair<int, bool> test in testdictionary)
            //{
            //    Console.WriteLine(test.Key + " - " + test.Value);
            //}
            //Console.WriteLine(" \n \n");

            //testdictionary[1] = true;
            //testdictionary[3] = true;
            //testdictionary[5] = true;

            //Console.WriteLine("New Dictionary Values: \n");
            //foreach (KeyValuePair<int, bool> test in testdictionary)
            //{
            //    Console.WriteLine(test.Key + " - " + test.Value);
            //}

            //Console.ReadKey();







            Controller gameController = new Controller();
        
            Console.ReadKey();
        }
    }
}
