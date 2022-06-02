using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Component_1
{

    /// <summary>
    ///  creating a  DrawCircle class which  inherits from Shape class.
    /// This class will hold method and properties for Drawing Circle
    /// </summary>
    class DrawCircle : Shape
    {
        //Declearing variable to instantiate
        public int radius;

        /// <summary>
        /// using constructor to initialize the instance of class
        /// </summary>
        /// <param name="r">r will hold radius of the circle</param>
        public DrawCircle(int r) : base(r, 0)
        {
            radius = r;
        }

        /// <summary>
        /// This method will hold specific shape(Circle) to draw and also to fill on shape
        ///  if Fill is on
        /// </summary>
        /// <param name="myCommand">myCommand holds Drawing area</param>
        public override void Draw(command myCommand)
        {
            myCommand.g.DrawEllipse(myCommand.pen, myCommand.xPos, myCommand.yPos, (radius * 2), (radius * 2));

            //if this Expression is true then it will fill on than circle and gets fill with colour provided by user 
            if (myCommand.fill)
            {
                myCommand.g.FillEllipse(myCommand.brush, myCommand.xPos, myCommand.yPos, (radius * 2), (radius * 2));
            }
        }


    }
}
