
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    public class Civilian : Npc, ISpeak
    {
        #region FIELDS

        private int _messageCntr = -1;

        #endregion

        #region PROPERTIES

        public override int ID { get; set; }  //ID value for the civilian.

        public override string Description { get; set; }   //A brief description of who the civilian is.

        public List<string> Messages { get; set; }   //A list of things the civilian has to say.
        
        #endregion

        #region CONSTRUCTORS

        public Civilian()
        {

        }

        #endregion

        #region METHODS

        private string GetMessges()
        {
            _messageCntr += 1;
            if (_messageCntr >= Messages.Count)
            {
                _messageCntr = 0;
            }

            return Messages[_messageCntr];
        }

        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessges();
            }  
            else
            {
                return $"It appears that {this.FirstName} has nothing to say.";
            }
        }

        #endregion
    }
}
