using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component_1
{
    /// <summary>
    /// Created DrawSquare class which inherits from Shape class given
    /// </summary>
    class DrawSquare : Shape
    {
        //Declearing variable to instantiate given
        public int height;
        public int width;

        /// <summary>
        /// using constructor to initialize the instance of class
        /// </summary>
        /// <param name="x">x assigning value on height</param>
        /// <param name="y">x assigning value on width</param>
        public DrawSquare(int x, int y) : base(x, y)
        {
            height = x;
            width = y;
        }

        /// <summary>
        /// This method will hold specific shape(Rectangle) to draw and also to fill on shape given
        ///  if Fill is on
        /// </summary>
        /// <param name="myCommand">myCommand holds Drawing area</param>
        public override void Draw(command myCommand)
        {
            myCommand.g.DrawRectangle(myCommand.pen, myCommand.xPos, myCommand.yPos, width, height);

            //if this Expression is true then fill on than Rectangle gets fill with colour provided by user listed 
            if (myCommand.fill)
            {
                myCommand.g.FillRectangle(myCommand.brush, myCommand.xPos, myCommand.yPos, width, height);
            }
        }
    }
}
