using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Component_1
{
   public class CheckUserSyntax
    {
        /// <summary>
        /// This method will give error message when entered command is Invalid
        /// </summary>
        /// <param name="myCommand">This indicate a place where Error message will be Displayed</param>
        /// <param name="num">num will indicate line number of Command</param>
        /// <param name="x">It will indicate the location where error will be displayed on command</param>
        public void CommandCheck(command myCommand, int num, int x)
        {
            //create font for Error message
            Font errortxtFont = new Font("Arial", 10);
            //create Solid brush for Error message with color black
            SolidBrush errortxtBrush = new SolidBrush(Color.Black);
            num++;
            if (num != 0)
            {
                if (x == 0)
                {
                    //Reset caanvas if error not found
                    myCommand.Reset();
                }
                //Display Error if command on particular line does not exit
                myCommand.g.DrawString("Command on line " + (num) + " does not exist", errortxtFont, errortxtBrush, 0, 0 + x);
            }
            else
            {
                //Display Error if Command does not exit
                myCommand.g.DrawString("Command does not exist", errortxtFont, errortxtBrush, 0, 0);
            }
            //sets the error to true
            myCommand.error = true;

        }


        /// <summary>
        /// This method will give error message when entered Parameter % be Invalid
        /// </summary>
        /// <param name="parameter">will get boolean values according to validity of parameter</param>
        /// <param name="data">Gives line number where Error will be found</param>
        /// <param name="num">num will indicate line number for Command</param>
        /// <param name="myCaanvas">This will indicate a place where Error message will be Displayed</param>
        /// <param name="x">It will indicate the location where error will be displayed on command</param>
        public void ParameterCheck(bool parameter, String data, int num, command myCommand, int x)
        {
            //It willGive error message when entered Parameter and it will be Invalid
            if (!parameter)
            {
                Font errortxtFont = new Font("Arial", 10);
                SolidBrush errortxtBrush = new SolidBrush(Color.Black);
                if (x == 0)
                {
                    // use Reset command if error not found
                    myCommand.Reset();
                }
                if ((num + 1) == 0)
                {
                    // will Display Error if parameter are Invalid
                    myCommand.g.DrawString("Paramater " + data + " is invalid", errortxtFont, errortxtBrush, 0, 0 + x);
                }
                else
                {
                    //will Display Error if parameter are Invalid for Multi line command
                    myCommand.g.DrawString("Paramater " + data + " on line " + (num + 1) + " is invalid", errortxtFont, errortxtBrush, 0, 0 + x);
                }
                //Sets the Error to true
                myCommand.error = true;
            }
        }

        /// <summary>
        /// This method will give error message when entered and Parameter number will be Invalid and
        /// Catch Exception used for invalid command
        /// </summary>
        /// <param name="e"> it willCatch Exception for invalid command</param>
        /// <param name="num">num will indicate line number of Command</param>
        /// <param name="myCommand">This will indicate a place where Error message will be Displayed</param>
        /// <param name="x">It will indicate the location where error will be displayed on canvas</param>
        public void ParameterCheck(Exception e, int num, command myCommand, int x)
        {
            Font errortxtFont = new Font("Arial", 10);
            SolidBrush errortxtBrush = new SolidBrush(Color.Black);

            if (x == 0)
            {
                //use Reset command if error not found
                myCommand.Reset();
            }
            if ((num + 1) == 0)
            {
                // it will display Error if number of parameters are invalid
                myCommand.g.DrawString("Wrong number of parameters inputted", errortxtFont, errortxtBrush, 0, 0 + x);
            }
            else
            {
                //it will display Error if number of parameters are invalid
                myCommand.g.DrawString("Wrong number of parameters inputted on line" + (num + 1), errortxtFont, errortxtBrush, 0, 0 + x);
            }
            //sets the error to true
            myCommand.error = true;
        }
    }
}


    

