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
    public partial class frmAlternateEndgame : Form
    {
        public frmAlternateEndgame()
        {
            InitializeComponent();
        }

        private void frmAlternateEndgame_Load(object sender, EventArgs e)
        {
            label1.Text = "";

            label1.Text = "Time Taken : " + frmAlternateIdentifyingArea.finalTime;
        }


        private void btnPlayAgain_Click_1(object sender, EventArgs e)
        {
            frmIdentifyingAreas frmRB = new frmIdentifyingAreas();
            this.Hide();
            frmRB.ShowDialog();
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            //closes the current instance of the form
            frmMainMenu frmRB = new frmMainMenu();
            this.Hide();
            frmRB.ShowDialog();
            this.Close();
        }
    }
}
