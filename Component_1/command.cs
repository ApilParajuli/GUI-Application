using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Component_1
{
    public class command
    {
        /// <summary>
        ///this will Create Instance data graphics
        /// </summary>
        public Graphics g;

        /// <summary>
        ///ithis will Create Instance for SoildBrush
        /// </summary>
        public SolidBrush brush;

        /// <summary>
        ///it will Create Instance for fill
        /// </summary>
        public bool fill = false;

        /// <summary>
        /// it will Create Instance for CheckUserSyntax
        /// </summary>
        public CheckUserSyntax checkSyntax;

        /// <summary>
        /// it willCreate Instance for StoreMethod
        /// </summary>
        public LoadMethod storeMethod;

        /// <summary>
        ///it will Create Instance for StoreVariable
        /// </summary>
        public LoadVariable storeVariable;

        /// <summary>
        /// it willCreate Instance for error
        /// </summary>
        public bool error = false;

        /// <summary>
        /// it wilCreate Instance for pen
        /// </summary>
        public Pen pen;

        /// <summary>
        ///Following public variable for xPos, yPos
        /// </summary>
        public int xPos, yPos;
        


        /// <summary>
        ///  using constructor to initialize the instance of class
        /// </summary>
        /// <param name="g">g it will hold methods and properties to draw and make graphics objects</param>
        public command(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;
            storeVariable = new LoadVariable();
            storeMethod = new LoadMethod();
            checkSyntax = new CheckUserSyntax();
            pen = new Pen(Color.Black, 1);//default pen with color and width
            g.DrawRectangle(pen, xPos, yPos, 1, 1);
            brush = new SolidBrush(Color.Black);
        }

        /// <summary>
        /// it will Draw line from current pen posiion
        /// </summary>
        /// <param name="toX">Position for drawing</param>
        /// <param name="toY">Position for drawing</param>
        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(pen, xPos, yPos, toX, toY);//for drawing line
            xPos = toX;
            yPos = toY; //the pen position will be moved at the end of line
        }

        /// <summary>
        ///it Moves from current position to given position
        /// </summary>
        /// <param name="toX">position for drawing</param>
        /// <param name="toY">position for drawing</param>
        public void MoveTo(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
            g.DrawRectangle(pen, xPos, yPos, 1, 1); //drawing a square
        }

        /// <summary>
        /// This method will hold hold pen color which is Provided by user through command
        /// </summary>
        /// <param name="colour">color hold pen color which is given by user</param>
        public void Set_Pen_Color(Color colour)
        {
            pen = new Pen(colour, 1);
            brush = new SolidBrush(colour);
        }

        /// <summary>
        /// Resetting the Drawing area
        /// </summary>
        public void Reset()
        {
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);//defaulting pens with constants
            g.Clear(SystemColors.Control);
            g.DrawRectangle(pen, xPos, yPos, 1, 1);
            storeVariable.Reset();
            storeMethod.Reset();
            error = false;
            fill = false;
        }

        /// <summary>
        /// Clearng the Drawing area
        /// </summary>
        public void Clear()
        {
            g.Clear(SystemColors.Control);
        }

    }


}
