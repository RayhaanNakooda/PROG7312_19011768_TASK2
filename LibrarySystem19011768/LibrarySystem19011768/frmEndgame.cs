using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem19011768
{
    public partial class frmEndgame : Form
    {
        public frmEndgame()
        {
           

            InitializeComponent();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            frmAlternateIdentifyingArea frmRB = new frmAlternateIdentifyingArea();
            this.Hide();
            frmRB.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the current instance of the form
            frmMainMenu frmRB = new frmMainMenu();
            this.Hide();
            frmRB.ShowDialog();
            this.Close();
        }

        private void frmEndgame_Load(object sender, EventArgs e)
        {

            lblTimeTaken.Text = "";

            lblTimeTaken.Text = "Time Taken : " + frmIdentifyingAreas.finalTime;

        }

        
    }
}
