using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Component_1
{

    /// <summary>
    /// Created DrawTriangle class inorder to inherit from Shape class.
    /// This class is responsible for building Triangle.
    /// </summary>
    class DrawTriangle : Shape
    {
        //Declearing variables to instantiate
        public int bseValue;
        public int adjacent;
        public int hypotenuse;

        /// <summary>
        ///  using constructor to initialize the instance of class given
        /// </summary>
        /// <param name="x">x will  hold hypotenuse value provided by user given</param>
        /// <param name="y">y will hold base value provided by user given</param>
        /// <param name="z">z will hold adjacent value provided by user given</param>
        public DrawTriangle(int x, int y, int z) : base(x, y)
        {
            hypotenuse = x;
            bseValue = y;
            adjacent = z;
        }

        /// <summary>
        /// This method will hold specific shape(Triangle) to draw and also to fill on shape
        ///  if Fill is on
        /// </summary>
        /// <param name="myCommand">myCommand Drawing area</param>
        public override void Draw(command myCommand)
        {
            PointF a = new Point(myCommand.xPos, myCommand.yPos);
            PointF b = new Point(myCommand.xPos, myCommand.yPos + bseValue);
            PointF c = new PointF(myCommand.xPos + adjacent, myCommand.yPos + bseValue);
            PointF[] pnt = { a, b, c };
            myCommand.g.DrawPolygon(myCommand.pen, pnt);//Drawing a triangle
            if (myCommand.fill)
            {

                myCommand.g.FillPolygon(myCommand.brush, pnt);//Drawing a filled triangle if fill is given true
            }
        }
    }
}
