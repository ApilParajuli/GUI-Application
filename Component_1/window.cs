using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Component_1
{
    /// <summary>
    /// This class will hold method and properties for command instruction and set them in proper format,
    /// by error checkingif it is done By this class.
    /// </summary>
    public class window
    {
        //Repersent Line of multi line command
        int line = 0;

        /// <summary>
        /// Command will be executed based on single line or multi Line commands
        /// </summary>
        /// <param name="readCommand">holds single Line Commands</param>
        /// <param name="readMultiCommand">holds Mulit line Commands</param>
        /// <param name="myCommand">Holds myCommand to draw on</param>
        public void Command(String readCommand, String readMultiCommand, command myCommand)
        {
            //Remove previous excuted program if myCommand gets error, provide new execution area if necessary 
            if (myCommand.error)
            {
                myCommand.Reset();
                myCommand.error = false;
            }

            if (readMultiCommand.Length.Equals(0))
            {

                SingleCommand(readCommand, myCommand);   //calling the SingleCommand method
            }
            else if (readCommand.Equals("run"))
            {
                MultiCommand(readMultiCommand, myCommand);  //calling the MultiCommand method
            }
            else
            {
                MultiCommand(readMultiCommand, myCommand);    //calling the MultiCommand method
            }
        }

        /// <summary>
        /// This method will split command and parameter when white space occurs between them.
        /// </summary>
        /// <param name="readCommand">passing the single line commands</param>
        /// <param name="myCommand">Holding commands to draw on</param>
        public void SingleCommand(String readCommand, command myCommand)
        {
            String[] readCmd = readCommand.Split(' ');
            ParameterSeperator(readCmd, myCommand, -1);    //calling the ParameterSeperator method
        }

        /// <summary>
        /// This method will split new line and store those value/command.
        /// </summary>
        /// <param name="readCommand">Passing the Multi line command from ProgramWindow</param>
        /// <param name="myCommand">Hold command to draw on</param>
        public void MultiCommand(String readCommand, command myCommand)
        {
            String[] value = readCommand.Split('\n');
            int num = 0;
            int x = 0;
            try
            {
                //This loop will run until the number of input gets exist in program windows
                while (num < value.Length)
                {
                    String[] readCmd = value[num].Split(' ');
                    //if user enters value and while get equal then value will be added in list data
                    if (readCmd[0].Equals("while"))
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]);
                            num++;
                            readCmd = value[num].Split(' ');
                        }
                        while (!readCmd[0].Equals("endwhile"));
                        CmdLoopWhile(listData, myCommand, num, x);
                    }
                    //when user will enter value and if it gets equal then value will be added in list data
                    else if (readCmd[0].Equals("if"))
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]);
                            num++;
                            readCmd = value[num].Split(' ');
                        }
                        while (!readCmd[0].Equals("endif"));
                        CmdConditionIf(listData, myCommand, num, x);
                    }
                    //if user gets enter value and loop get equal then value will be added in list datas
                    else if (readCmd[0].Equals("loop"))
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]);
                            num++;
                            readCmd = value[num].Split(' ');
                        }
                        while (!readCmd[0].Equals("endfor"));
                        CmdLoopFor(listData, myCommand, num, x);
                    }
                    //if user enters value and method and get equal then value will be added in list datas
                    else if (readCmd[0].Equals("method"))
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]);
                            num++;
                            readCmd = value[num].Split(' ');
                        }
                        while (!readCmd[0].Equals("endmethod"));
                        CmdMethodSelect(listData, myCommand, num, x);
                    }
                    else
                    {
                        ParameterSeperator(readCmd, myCommand, num);    //calling the ParameterSeperator method
                    }
                    num++;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// This method will return while loop operation when user enters while loop with statement in them.
        /// </summary>
        /// <param name="listData">value provided by user in program window</param>
        /// <param name="myCommand">Hold command to draw on</param>
        /// <param name="num">lines from where command gets executed</param>
        /// <param name="z">gives error on line numbers</param>
        public void CmdLoopWhile(List<String> listData, command myCommand, int num, int z)
        {
            string newData = string.Join("\n", listData);
            String[] value = newData.Split('\n');
            String[] readCmd = value[0].Split(' ');
            int x = 0;
            bool isValueExists = false;
            List<String> stringLists = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringLists.Add(value[allValue]);
                allValue++;
            }

            try
            {
                if (readCmd[1].Split('<').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('<');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCommand.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, tempVal[1], num, myCommand, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCommand.checkSyntax.ParameterCheck(false, tempVal[0], num, myCommand, line);
                            line = line + 20;
                        }
                        else
                        {
                            while (myCommand.storeVariable.GetVar(tempVal[0]) < x)
                            {
                                newData = string.Join("\n", stringLists);
                                MultiCommand(newData, myCommand);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split('>').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('>');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCommand.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, tempVal[1], num, myCommand, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCommand.checkSyntax.ParameterCheck(false, tempVal[0], num, myCommand, line);
                            line = line + 20;
                        }
                        else
                        {
                            while (myCommand.storeVariable.GetVar(tempVal[0]) > x)
                            {
                                newData = string.Join("\n", stringLists);
                                MultiCommand(newData, myCommand);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split("==".ToCharArray()).Length > 1)
                {
                    String[] tempVal = readCmd[1].Split("==".ToCharArray());
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCommand.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, tempVal[1], num, myCommand, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCommand.checkSyntax.ParameterCheck(false, tempVal[0], num, myCommand, line);
                            line = line + 20;
                        }
                        else
                        {
                            while (myCommand.storeVariable.GetVar(tempVal[0]) == x)
                            {
                                newData = string.Join("\n", stringLists);
                                MultiCommand(newData, myCommand);
                            }
                        }
                    }
                }
                else
                {
                    myCommand.checkSyntax.ParameterCheck(false, "", num - z, myCommand, line);
                    line = line + 20;
                }
            }
            catch
            {
                myCommand.checkSyntax.ParameterCheck(false, "", num - z, myCommand, line);
                line = line + 20;
            }

        }

        /// <summary>
        /// This method will execute if condition when user enter if with statement inside them.
        /// </summary>
        /// <param name="listData">value be provided by user in the program window</param>
        /// <param name="myCommand">Hold the command to draw on</param>
        /// <param name="num">line from where command will be executed</param>
        /// <param name="z">gives error on line numbers</param>
        public void CmdConditionIf(List<String> listData, command myCommand, int num, int z)
        {
            string newData = string.Join("\n", listData);
            String[] value = newData.Split('\n');
            String[] readCmd = value[0].Split(' ');
            int x = 0;
            bool isValueExists = false;
            List<String> stringList = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringList.Add(value[allValue]);
                allValue++;
            }
            try
            {
                if (readCmd[1].Split('<').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('<');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCommand.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, tempVal[1], num, myCommand, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCommand.checkSyntax.ParameterCheck(false, tempVal[1], num, myCommand, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCommand.storeVariable.GetVar(tempVal[0]) < x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiCommand(newData, myCommand);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split('>').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('>');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCommand.checkSyntax.ParameterCheck(false, tempVal[0], num, myCommand, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCommand.storeVariable.GetVar(tempVal[0]) < x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiCommand(newData, myCommand);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split('>').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('>');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCommand.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, tempVal[1], num, myCommand, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCommand.checkSyntax.ParameterCheck(false, tempVal[0], num, myCommand, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCommand.storeVariable.GetVar(tempVal[0]) > x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiCommand(newData, myCommand);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split("==".ToCharArray()).Length > 1)
                {
                    String[] tempVal = readCmd[1].Split("==".ToCharArray());
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCommand.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, tempVal[1], num, myCommand, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCommand.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCommand.checkSyntax.ParameterCheck(false, tempVal[0], num, myCommand, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCommand.storeVariable.GetVar(tempVal[0]) > x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiCommand(newData, myCommand);
                            }
                        }
                    }
                }
                else
                {
                    myCommand.checkSyntax.ParameterCheck(false, "", num - z, myCommand, line);
                    line = line + 20;
                }
            }
            catch
            {
                myCommand.checkSyntax.ParameterCheck(false, "", num - z, myCommand, line);
                line = line + 20;
            }
        }

        /// <summary>
        /// This method will execute for loop operation when user enter for with statement inside them.
        /// </summary>
        /// <param name="listData">value provided by user in program window</param>
        /// <param name="myCommand">Holds the command to draw on</param>
        /// <param name="num">line from where command get executed</param>
        /// <param name="z">gives error on line numbers</param>
        public void CmdLoopFor(List<String> listData, command myCommand, int num, int z)//LoopFor
        {
            string newData = string.Join("\n", listData);
            String[] value = newData.Split('\n');
            String[] readCmd = value[0].Split(' ');
            int x = 0;
            bool isValueExists = false;
            List<String> stringLists = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringLists.Add(value[allValue]);
                allValue++;
            }
            try
            {
                if (readCmd[1].Equals("for"))
                {
                    if (!int.TryParse(readCmd[2], out x))
                    {
                        if (!myCommand.storeVariable.VarExists(readCmd[2]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCommand.storeVariable.GetVar(readCmd[2]);
                        }
                    }
                }
                if (isValueExists)
                {
                    myCommand.checkSyntax.ParameterCheck(false, readCmd[2], num, myCommand, line);
                    line = line + 20;
                }
                else
                {
                    for (int b = 0; b < x; b++)
                    {
                        newData = string.Join("\n", stringLists);
                        MultiCommand(newData, myCommand);
                    }
                }
            }
            catch
            {
                myCommand.checkSyntax.ParameterCheck(false, "", num - z, myCommand, line);
                line = line + 20;
            }
        }

        /// <summary>
        /// This method will execute method operation when user enter while with statement inside them.
        /// </summary>
        /// <param name="listData">value provided by user in the program windows</param>
        /// <param name="myCommand">Holds caanvas to draw on them</param>
        /// <param name="num">the line from where commands get executed</param>
        /// <param name="z">gives error on line numbers</param>
        public void CmdMethodSelect(List<String> listData, command myCommand, int num, int z)
        {
            string newData = string.Join("\n", listData);
            String[] value = newData.Split('\n');
            String[] readCmd = value[0].Split(' ');
            String x = null;
            bool isValueExists = false;
            String[] method = readCmd[1].Split('(', ')');
            String[] methodValue = null;

            myCommand.storeMethod.StoreVar(method[0], method[1]);
            List<String> stringLists = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringLists.Add(value[allValue]);
                allValue++;
            }
            try
            {
                if (myCommand.storeMethod.VarExists(method[0]))
                {
                    x = myCommand.storeMethod.GetVar(method[0]);
                    methodValue = x.Split(',');
                }
                else
                {
                    isValueExists = true;
                }
                if (isValueExists)
                {
                    myCommand.checkSyntax.ParameterCheck(false, readCmd[1], num, myCommand, line);
                    line = line + 20;
                }
                else
                {
                    newData = string.Join("\n", stringLists);
                    String methodCmd = method[0] + "command";
                    myCommand.storeMethod.StoreVar(methodCmd, newData);
                }

            }
            catch
            {
                myCommand.checkSyntax.ParameterCheck(false, "", num - z, myCommand, line);
                line = line + 20;
            }

        }

        /// <summary>
        /// This method will interact with different shape and drawing component to use for drawing shape
        /// </summary>
        /// <param name="readCmd">value provided by user</param>
        /// <param name="myCommand">Hold command to draw on</param>
        /// <param name="num">lines from where command gets executed</param>
        public void ParameterSeperator(String[] readCmd, command myCommand, int num)
        {
            try
            {
                String[] method = readCmd[0].Split('(', ')');
                // if the command provided by user is drawto then this block get executed to draw Lines
                if (readCmd[0].Equals("drawto"))
                {
                    //split parameters when comma occurs between parameters and stores value in string array s
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    bool isVarExists = false;
                    //try block run for valid parameters otherwise throw exception by catch blocks
                    try
                    {
                        //Converting string into integers
                        if (!int.TryParse(data[0], out x))
                        {
                            //check, if value is already in store variable then return boolean true or else it get value in else block
                            if (!myCommand.storeVariable.VarExists(data[0]))
                            {
                                isVarExists = true;
                            }
                            else
                            {
                                x = myCommand.storeVariable.GetVar(data[0]);
                            }
                            //if value gets true then values go for check valid parameters
                            if (isVarExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[0], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCommand.storeVariable.VarExists(data[1]))
                            {
                                isVarExists = true;
                            }
                            else
                            {
                                y = myCommand.storeVariable.GetVar(data[1]);
                            }
                            if (isVarExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[1], num, myCommand, line);
                                num = num + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                        line = line + 20;
                    }
                    //when myCommand doesnot get any error then this block will get executed
                    if (!myCommand.error)
                    {
                        myCommand.DrawLine(x, y);
                    }
                }

                // When command provided by user is movetothen  this block will get executed to move pen position
                else if (readCmd[0].Equals("moveto"))
                {
                    //split parameters when comma occurs between parameters and stores value in string arrays
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    bool isValueExists = false;
                    //trying block run for valid parameters or else throw exception by catch blocks
                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!myCommand.storeVariable.VarExists(data[0]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCommand.storeVariable.GetVar(data[0]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[0], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCommand.storeVariable.VarExists(data[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                y = myCommand.storeVariable.GetVar(data[1]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[1], num, myCommand, line);
                                num = num + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                        line = line + 20;
                    }
                    //when myCommand doesnot get any error then this block will get executed
                    if (!myCommand.error)
                    {
                        myCommand.MoveTo(x, y);
                    }
                }

                // When command provided by the user is rectanglethen  this block get executed to draw Rectangle Shape
                else if (readCmd[0].Equals("rectangle"))
                {
                    //split parameters when comma occurs in between them parameter and store value in string array
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    bool isValueExists = false;
                    //trying block run for valid parameters otherwise throw exception by catch blocks
                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!myCommand.storeVariable.VarExists(data[0]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCommand.storeVariable.GetVar(data[0]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[0], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCommand.storeVariable.VarExists(data[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                y = myCommand.storeVariable.GetVar(data[1]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[1], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                        line = line + 20;
                    }
                    //when myCommand doesnot get any error then this block will get executed
                    if (!myCommand.error)
                    {
                        Shape drawRectangle = new DrawSquare(x, y);
                        drawRectangle.Draw(myCommand);
                    }
                }
                // When command provided by user is in square then  this block will get executed to draw Square Shape
                else if (readCmd[0].Equals("square"))
                {
                    int x = 0;
                    bool isValueExists = false;
                    //trying block run for valid parameter or else throw exception by catch block
                    try
                    {
                        if (!int.TryParse(readCmd[1], out x))
                        {
                            if (!myCommand.storeVariable.VarExists(readCmd[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCommand.storeVariable.GetVar(readCmd[1]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, readCmd[1], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                        line = line + 20;
                    }
                    //when myCommand doesnot get any error then this block will get executed
                    if (!myCommand.error)
                    {
                        Shape drawSquare = new DrawSquare(x, x);
                        drawSquare.Draw(myCommand);
                    }
                }

                // When command provided by user is circle then  this block will get executed to draw Triangle Shape
                else if (readCmd[0].Equals("triangle"))
                {
                    //spliting parameters when comma occurs between parameters and store value in string arrays
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    int z = 0;
                    bool isValueExists = false;
                    //try block run for valid parameters or else throw exception by catching block
                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!myCommand.storeVariable.VarExists(data[0]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCommand.storeVariable.GetVar(data[0]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[0], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCommand.storeVariable.VarExists(data[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                y = myCommand.storeVariable.GetVar(data[1]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[1], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[2], out z))
                        {
                            if (!myCommand.storeVariable.VarExists(data[2]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                z = myCommand.storeVariable.GetVar(data[2]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, data[2], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                        line = line + 20;
                    }
                    //when myCommand doesnot get any error then this block will get executed to draw triangle
                    if (!myCommand.error)
                    {
                        Shape drawTriangle = new DrawTriangle(x, y, z);
                        drawTriangle.Draw(myCommand);
                    }
                }
                // When command provided by user is circle then  this block will get executed to draw Circle Shape
                else if (readCmd[0].Equals("circle"))
                {
                    int x = 0;
                    bool isValueExists = false;
                    //try block run for valid parameter orelse throw exception by catch block
                    try
                    {
                        if (!int.TryParse(readCmd[1], out x))
                        {
                            if (!myCommand.storeVariable.VarExists(readCmd[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCommand.storeVariable.GetVar(readCmd[1]);
                            }
                            if (isValueExists)
                            {
                                myCommand.checkSyntax.ParameterCheck(false, readCmd[1], num, myCommand, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                        line = line + 20;
                    }
                    //when myCommand doesnot get any error then this block gets executed
                    if (!myCommand.error)
                    {
                        Shape drawCircle = new DrawCircle(x);
                        drawCircle.Draw(myCommand);
                    }
                }
                
                // When command provided by user is pen then  this block gets executed
                else if (readCmd[0].Equals("pen"))
                {
                    Color color = Color.FromName(readCmd[1]); //User inputing the  color 

                    if (color.IsKnownColor == false)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, readCmd[1], num, myCommand, line);
                        line = line + 20;
                    }
                    //when myCommand doesnot get any error then this block gets executed
                    if (!myCommand.error)
                    {
                        myCommand.Set_Pen_Color(color); // call and set color given by the user
                    }
                }
                // When command provided by user is fill then this block gets executed
                else if (readCmd[0].Equals("fill"))
                {
                    bool fillOn = readCmd[1].Equals("on");
                    bool fillOff = readCmd[1].Equals("off");

                    if (fillOn == false && fillOff == false)
                    {
                        myCommand.checkSyntax.ParameterCheck(false, readCmd[1], num, myCommand, line);
                        line = line + 20;
                    }

                    //when myCommand doesnot get any error then this block will get executed
                    if (!myCommand.error)
                    {
                        //When fiil gets on
                        if (fillOn)
                        {
                            myCommand.fill = true;
                        }
                        //when fill gets off
                        else if (fillOff)
                        {
                            myCommand.fill = false;
                        }
                    }
                }
                // When command provided by user is clear then this block will get executed to fill shape
                else if (readCmd[0].Equals("clear"))
                {
                    //when myCommand doesnot get any error then this block will get executed
                    if (!myCommand.error)
                    {
                        myCommand.Clear();
                    }
                }
                // When command provided by user is reset then this block woll get executed to clear
                else if (readCmd[0].Equals("reset"))
                {
                    //when myCommand doesnot get any error then this block will get executed to reset
                    if (!myCommand.error)
                    {
                        myCommand.Reset();
                    }
                }
                // When command provided by user is exit then this block will get executed
                else if (readCmd[0].Equals("exit"))
                {
                    //when myCommand doesnot get any error then this block will get executed
                    if (!myCommand.error)
                    {
                        Application.Exit();
                    }
                }
                //Method operation to get method variable and  method seperation also
                else if (myCommand.storeMethod.VarExists(method[0]))
                {
                    String[] methodValue = (myCommand.storeMethod.GetVar(method[0])).Split(',');
                    String methodCmd = method[0] + "command";
                    String methodCommand = myCommand.storeMethod.GetVar(methodCmd);
                    //splitting the parameters when comma occurs between parameter and store value in string array
                    String[] userValue = method[1].Split(',');
                    int x = 0;
                    while (methodValue.Length > x)
                    {
                        String[] valueStore = (methodValue[x] + " = " + userValue[x]).Split(' ');
                        ParameterSeperator(valueStore, myCommand, num);
                        x++;
                    }
                    MultiCommand(methodCommand, myCommand);

                }
                // When command provided by user is =, this block will get executed for Operator functionality
                else if (readCmd[1].Equals("="))
                {
                    //try block run for validing the parameter otherwise throw exception by using catch block
                    try
                    {
                        // adition operations
                        if (readCmd[3].Equals("+"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCommand.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCommand.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCommand.checkSyntax.ParameterCheck(false, readCmd[2], num, myCommand, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                                line = line + 20;
                            }
                            varValue = x + y;
                            myCommand.storeVariable.EditVar(readCmd[0], varValue);
                        }
                        // Substract operations
                        if (readCmd[3].Equals("-"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCommand.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCommand.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCommand.checkSyntax.ParameterCheck(false, readCmd[2], num, myCommand, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                                line = line + 20;
                            }
                            varValue = x - y;
                            myCommand.storeVariable.EditVar(readCmd[0], varValue);
                        }
                        // Divide operations
                        if (readCmd[3].Equals("/"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCommand.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCommand.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCommand.checkSyntax.ParameterCheck(false, readCmd[2], num, myCommand, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                                line = line + 20;
                            }
                            varValue = x / y;
                            myCommand.storeVariable.EditVar(readCmd[0], varValue);
                        }
                        // Multiply operations
                        if (readCmd[3].Equals("*"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCommand.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCommand.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCommand.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCommand.checkSyntax.ParameterCheck(false, readCmd[2], num, myCommand, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                                line = line + 20;
                            }
                            varValue = x * y;
                            myCommand.storeVariable.EditVar(readCmd[0], varValue);
                        }
                    }
                    catch
                    {
                        int x = 0;
                        //try block run for valid parameter or else throw exceptions by catch block
                        try
                        {
                            bool isValueExists = false;
                            if (!int.TryParse(readCmd[2], out x))
                            {
                                if (!myCommand.storeVariable.VarExists(readCmd[2]))
                                {
                                    isValueExists = true;
                                }
                                else
                                {
                                    x = myCommand.storeVariable.GetVar(readCmd[2]);
                                }
                                if (isValueExists)
                                {
                                    myCommand.checkSyntax.ParameterCheck(false, readCmd[2], num, myCommand, line);
                                    line = line + 20;
                                }
                            }
                        }
                        //catch error if exceptions thrown by try
                        catch (Exception e)
                        {
                            myCommand.checkSyntax.ParameterCheck(e, num, myCommand, line);
                            line = line + 20;
                        }
                        //if myCommand doesnot get any error then this block will get executed
                        if (!myCommand.error)
                        {
                            if (!myCommand.storeVariable.VarExists(readCmd[0]))
                            {
                                myCommand.storeVariable.StoreVar(readCmd[0], x);
                            }
                            else
                            {
                                myCommand.storeVariable.EditVar(readCmd[0], x);
                            }
                        }
                    }
                }
                //check the command for valid
                else
                {
                    myCommand.checkSyntax.CommandCheck(myCommand, num, line);
                    line = line + 20;
                }
            }
            //catching error exceptions thrown by try for Command check
            catch
            {
                myCommand.checkSyntax.CommandCheck(myCommand, num, line);
                line = line + 20;
            }

        }
    }
}
    