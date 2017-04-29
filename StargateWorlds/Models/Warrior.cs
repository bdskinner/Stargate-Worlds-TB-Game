using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    class Warrior : Npc, IBattle, ISpeak
    {
        #region FIELDS

        private int _messageCntr = -1;

        #endregion

        #region PROPERTIES

        public override int ID { get; set; }

        public override string Description { get; set; }

        public List<string> Messages { get; set; }

        #endregion

        #region METHODS

        /// <summary>
        /// Enables the NPC to engage in battle.
        /// </summary>
        /// <param name="gameTraveler"></param>
        /// <returns></returns>
        public Traveler.HealthChange Battle(Traveler gameTraveler)
        {
            //Variable Declarations.
            int rndNbr = UtilityLibrary.Misc.GetRandomInt(-3, 1);
            Traveler.HealthChange battleDamage = Traveler.HealthChange.None;

            //Determine the level of injury the traveler will sustain.
            switch (rndNbr)
            {
                case -3:
                    battleDamage = Traveler.HealthChange.MajorInjury;
                    break;
                case -2:
                    battleDamage = Traveler.HealthChange.ModerateInjury;
                    break;
                case -1:
                    battleDamage = Traveler.HealthChange.MinorInjury;
                    break;
                case 0:
                    battleDamage = Traveler.HealthChange.None;
                    break;
            }

            //Return the level of injury.
            return battleDamage;
        }

        /// <summary>
        /// Retrieves the messages from he NPC.
        /// </summary>
        /// <returns></returns>
        private string GetMessges()
        {
            _messageCntr += 1;
            if (_messageCntr >= Messages.Count)
            {
                _messageCntr = 0;
            }

            return Messages[_messageCntr];
        }

        /// <summary>
        /// Displays the message(s) from the NPC.
        /// </summary>
        /// <returns></returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessges();
            }
            else
            {
                return "It appears that this person has nothing to say.";
            }
        }

        #endregion
    }
}
