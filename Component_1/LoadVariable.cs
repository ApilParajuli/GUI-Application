using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component_1
{
   public class LoadVariable
    {

        //using Dictionary to represent the store key and its value listed
        Dictionary<string, int> VarDetail = new Dictionary<string, int>();

        /// <summary>
        ///using Represent to add specific key and value of given variable to the Dictionary above
        /// </summary>
        /// <param name="varName">using store String Key of given variable to the Dictionary above</param>
        /// <param name="varValue">using store int Value of given variable to the Dictionary above</param>
        public void StoreVar(String varName, int varValue)
        {
            VarDetail.Add(varName, varValue); //adding specific key and value to the Dictionary above
        }

        /// <summary>
        /// Representing it  to get value from specific keys
        /// </summary>
        /// <param name="varName">Get value of Specific keys</param>
        /// <returns>if Returns true, if Dictionary contains value with their specific Keys, or else false</returns>
        public int GetVar(String varName)
        {
            int x;
            VarDetail.TryGetValue(varName, out x); //getting the value from specific key
            return x;
        }

        /// <summary>
        /// Representing to update value if needed
        /// </summary>
        /// <param name="varName">Representing String Key of given variables</param>
        /// <param name="varValue">Updating int value of given key to the Dictionary above</param>
        public void EditVar(String varName, int varValue)
        {
            VarDetail[varName] = varValue; //update value if needed
        }

        /// <summary>
        ///using boolean to Check for value if Exists or not
        /// </summary>
        /// <param name="varName">using value to check</param>
        /// <returns>if Returns true, if Dictionary contains value with their specific Keys, or else false</returns>
        public bool VarExists(String varName)
        {
            int x;
            return VarDetail.TryGetValue(varName, out x);
        }

        /// <summary>
        /// Resetting or Removing all keys and value from Dictionary above
        /// </summary>
        public void Reset()
        {
            VarDetail.Clear(); //Removing all keys and value from Dictionary above
        }
    }
}
