using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MultiCommandTest()
        {

            Component_1.Form1 form = new Component_1.Form1();

            Component_1.window cmdSetup = new Component_1.window();
            Bitmap outBitmap = form.myBitmap;

            Component_1.command myCommand = new Component_1.command(Graphics.FromImage(outBitmap));
            cmdSetup.Command("run", "drawto 10,10", myCommand);
        }
        
        [TestMethod]
        public void ParameterSeperator()
        {
            Component_1.Form1 form = new Component_1.Form1();

            Component_1.window cmdSetup = new Component_1.window();
            Bitmap outBitmap = form.myBitmap;

            Component_1.command myCommand = new Component_1.command(Graphics.FromImage(outBitmap));
            cmdSetup.Command("run", "drawto 10,10", myCommand);

        }

        [TestMethod]
        public void MoveToTest()
        {
            Component_1.Form1 form = new Component_1.Form1();

            Component_1.window cmdSetup = new Component_1.window();
            Bitmap outBitmap = form.myBitmap;

            Component_1.command myCommand = new Component_1.command(Graphics.FromImage(outBitmap));
            cmdSetup.Command("moveto 10,10", "", myCommand);

        }
        public void FillOnTest()
        {
            Component_1.Form1 form = new Component_1.Form1();

            Component_1.window cmdSetup = new Component_1.window();
            Bitmap outBitmap = form.myBitmap;

            Component_1.command myCommand = new Component_1.command(Graphics.FromImage(outBitmap));
            cmdSetup.Command("fill on", "", myCommand);
        }
    }
}