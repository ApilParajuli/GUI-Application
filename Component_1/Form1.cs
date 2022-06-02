using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Component_1
{
    public partial class Form1 : Form
    {
        //Bitmap to draw which will display on pictureBox
        const int bitmapX = 640;
        const int bitmapY = 480;
        public Bitmap myBitmap = new Bitmap(bitmapX, bitmapY);
        public Graphics g;

        command myCommand;

        /// <summary>
        /// Created a Form1 constructor to initialize
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            myCommand = new command(Graphics.FromImage(myBitmap));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void ObtainInstruction()
        {
            String readCommand = textBox1.Text.Trim().ToLower();
            String readMultiCommand = Command.Text.Trim().ToLower();
            window cmdSetup = new window();
            cmdSetup.Command(readCommand, readMultiCommand, myCommand);
            Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();  // Terminate Application 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application is about Drawing a different shape using command Prompt by user\n"
              + Environment.NewLine + "Programmer Name: Apil Parajuli\n"
               + Environment.NewLine + "Thank You For Using This Application"
               , "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All COMMAND Should be Case INSENSITIVE"
             + Environment.NewLine + "======================================\n"
             + Environment.NewLine + "1. moveTo \"To move the pen position\"\nCommand-> moveTo x,y \nWhere x and y is integer value or (X,y) coordinate\n"
             + Environment.NewLine + "2. drawTo \"To Draw Line on Drawing area\"\nCommand-> drawTo x,y \nWhere x and y is integer value or (X,y) coordinate\n"
             + Environment.NewLine + "3. clear \"To Clear the Drawing area\"\nCommand-> clear\n"
             + Environment.NewLine + "4. reset \"To move pen to initial position at the top left of the Screen\"\nCommand-> reset\n"
             + Environment.NewLine + "5. run \"Read the program and Executes it\"\nCommand-> run\n"
             + Environment.NewLine + "6. rectangle \"To Draw Rectangle Shape\"\nCommand-> rectangle width,Height\n"
             + Environment.NewLine + "7. Square \"To Draw Square Shape\"\nCommand-> square width\n"
             + Environment.NewLine + "8. Circle \"To Draw Circle Shape\"\nCommand-> circle radius\n"
             + Environment.NewLine + "9. Triangle \"To Draw Triangle Shape\"\nCommand-> triangle hyp,base,adj\n"
             + Environment.NewLine + "10. Pen color \"To Choose color for drawing\"\nCommand-> pen color \n where color indicate different colour name according to user choice\n"
             + Environment.NewLine + "11. Fill on \"To fill the interior of a polygon\"\nCommand-> fill on\n"
             , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                myBitmap.Save(saveFileDialog1.FileName);
            }
            catch (Exception)
            {

            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                windowProgram.Load(openFileDialog1.FileName);
            }
            catch (Exception)
            {

            }
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            ObtainInstruction();
        }

        private void windowProgram_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImageUnscaled(myBitmap, 0, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Terminate Application 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Command_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
