using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component_1
{
    /// <summary>
    /// Creating abstract shape and class to provide appropriate base classes from which other classes are inherited
    /// </summary>
    abstract class Shape
    {
        //Declearing variable to instantiate
        int height;
        int width;

        /// <summary>
        ///using constructor to initialize the instance of class
        /// </summary>
        /// <param name="x">x assigning the value from it child class</param>
        /// <param name="y">y assigning the value from it child class</param>
        public Shape(int x, int y)
        {
            height = x;
            width = y;
        }

        /// <summary>
        /// Draw method must be implemented by using its child class and it is used to draw shape
        /// </summary>
        /// <param name="myCommand">myCommand hold drawing area results</param>
        public abstract void Draw(command myCommand);

    }
}
