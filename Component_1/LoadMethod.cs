using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component_1
{
   public class LoadMethod
    {

        //Dictionary will represent the store key and its value
        Dictionary<string, string> VarDetail = new Dictionary<string, string>();

        /// <summary>
        /// using Represent to add specific key and value of given method to the Dictionary
        /// </summary>
        /// <param name="methodName">using store String Key of given method to the Dictionary above</param>
        /// <param name="methodValue">using store String Value of given method to the Dictionary above</param>
        public void StoreVar(String methodName, String methodValue)
        {
            VarDetail.Add(methodName, methodValue); //adding specific key and value of given method to the Dictionary above
        }

        /// <summary>
        /// Represent helps to get value from specific key above
        /// </summary>
        /// <param name="methodName">Getting the value of Specific key</param>
        /// <returns>Returns true, if Dictionary contains value with their specific Keys, orelse false</returns>
        public String GetVar(String methodName)
        {
            String x;
            VarDetail.TryGetValue(methodName, out x); //getting the value from specific key
            return x;
        }

        /// <summary>
        ///using boolean to Check for value is Exists or not
        /// </summary>
        /// <param name="methodName">value for checking</param>
        /// <returns>Returns true, if Dictionary contains value with their specific Keys, orelse false</returns>
        public bool VarExists(String methodName)
        {
            String x;
            return VarDetail.TryGetValue(methodName, out x);
        }

        /// <summary>
        /// Reset or Remove using specific keys and value from Dictionary above
        /// </summary>
        public void Reset()
        {
            VarDetail.Clear(); //it willRemove all keys and value from Dictionary
        }

    }
}
