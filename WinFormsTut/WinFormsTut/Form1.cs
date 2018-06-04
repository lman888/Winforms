using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Winforms is a eventbased graphic handler
//need to set isMDIcontainer so it may hold other windows

namespace WinFormsTut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////Create a form
            //Form secondForm = new Form();

            ////Show the form
            //secondForm.Show();  ///If we dont show the form, we cant see it

            ///Create the dialog
            OpenFileDialog dialog = new OpenFileDialog();

            ///Show dialog
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Shows the file in the dialog box
                MessageBox.Show(dialog.FileName);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ///Casts textbox into texbox
            TextBox tb = sender as TextBox;
            if (tb == null)
            {
                ///Raise an Error
                return;
            }

            if (tb.Text.ToLower().EndsWith("awesome"))
            {
                MessageBox.Show("Its Awesome!");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           //MessageBox.Show(e.ClickedItem.Text);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyData.ToString());
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X + " " + e.Y);
        }

        private void item1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create new window
            TextWindow newTextWindow = new TextWindow();

            //Set MDI parent
            //Tells the window which parent it is apart of
            newTextWindow.MdiParent = this;

            //Show the Window
            newTextWindow.Show();
            
        }

        private void item2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create an open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Set the dialog to be navigated to the users My Documents
            //folder by default.
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //Finds us the users My Documents folder
            openFileDialog.InitialDirectory = myDocumentsPath;

            //Open the dialog, store the result when done
            DialogResult result = openFileDialog.ShowDialog();

            //if the dialog was used successfully, attempt to open the
            //selected file.
            if (result == DialogResult.OK)
            {
                try
                {
                    //Get the text
                    string text = System.IO.File.ReadAllText(openFileDialog.FileName); //We attempt to read the file and return to a string

                    //Create a new text form
                    TextWindow textForm = new TextWindow();

                    //Insert the read text into the form
                    textForm.MainTextArea.Text = text;  //Grab the main text area contect

                    //Set the forms parent
                    textForm.MdiParent = this;          //Sets the parent

                    textForm.Text = openFileDialog.SafeFileName;    

                    //Show the form
                    textForm.Show();
                }
                catch
                {
                    MessageBox.Show("Could not open selected file");
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                textBox1.Text = File.ReadAllText(label1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
