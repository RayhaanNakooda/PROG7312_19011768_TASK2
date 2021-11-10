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
    public partial class frmIdentifyingAreas : Form
    {

        //creating an instance of the random class
        Worker worker = new Worker();

        //creating an instance of the random class
        public Random a = new Random(); 
        public static Random random = new Random();

        //<-----------------Code Attribution------------------
        //Code obtained from : https://www.youtube.com/watch?v=lp9cJJUDUsk&ab_channel=SaeThunder

        //variables that will be used to start the timer of the application 

        int timeCs, timeSec, timeMin;
        bool isActive;
        public static string finalTime;


        //<-------------End of Code Attribution------------->

        public frmIdentifyingAreas()
        {
            InitializeComponent();
        }

        private void frmIdentifyingAreas_Load(object sender, EventArgs e)
        {
            

            //sets value of the variables to 0
            timeCs = 0;
            timeSec = 0;
            timeMin = 0;

            //boolean value to that disables the timer of the form
            isActive = false;

        }

        private bool PopulateListBox()
        {

            //Dictionary containing the call numbers
            Dictionary<string, string> availableCallingNumbers = new Dictionary<string, string>(Worker.callingNumbers);
            int index; // index which is used as a counter for the for loop

            //for loop which runs 4 times
            for (int i = 0; i < 4; ++i)
            {

                //the index is assigned a random call number from the entire dictionary 
                index = random.Next(availableCallingNumbers.Count);

                //gets the key value pair of the chosen calling number
                KeyValuePair<string, string> pair = availableCallingNumbers.ElementAt(index);

                //adds the key and value to the corresponding component on the form
                lbColumnA.Items.Add(pair.Key);
                lbColumnB.Items.Add(pair.Value);
                cmbAnswerA.Items.Add(pair.Value);
                cmbAnswerB.Items.Add(pair.Value);
                cmbAnswerC.Items.Add(pair.Value);
                cmbAnswerD.Items.Add(pair.Value);

                availableCallingNumbers.Remove(pair.Key);
            }


            //for loop which runs 3 times
            for (int i = 0; i < 3; ++i)
            {

                //the index is assigned a random call number from the entire dictionary 
                index = random.Next(availableCallingNumbers.Count);

                //gets the key value pair of the chosen calling number
                KeyValuePair<string, string> pair = availableCallingNumbers.ElementAt(index);


                //adds the key and value to the corresponding component on the form
                lbColumnB.Items.Add(pair.Value);
                cmbAnswerA.Items.Add(pair.Value);
                cmbAnswerB.Items.Add(pair.Value);
                cmbAnswerC.Items.Add(pair.Value);
                cmbAnswerD.Items.Add(pair.Value);

                availableCallingNumbers.Remove(pair.Key);
            }

            return true;

        }

       

        private void btnCheckAnswers_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> availableCallingNumbers = new Dictionary<string, string>(Worker.callingNumbers);
            int index;

            index = random.Next(availableCallingNumbers.Count);
            KeyValuePair<string, string> pair = availableCallingNumbers.ElementAt(index);


            string valueA = cmbAnswerA.SelectedItem.ToString();
            string valueB = cmbAnswerB.SelectedItem.ToString();
            string valueC = cmbAnswerC.SelectedItem.ToString();
            string valueD = cmbAnswerD.SelectedItem.ToString();


            //<-----------------Code Attribution------------------
            //Code obtained from : https://www.delftstack.com/howto/csharp/get-dictionary-key-by-value-in-csharp/

            var myKeyA = availableCallingNumbers.FirstOrDefault(x => x.Value == valueA).Key;
            var myKeyB = availableCallingNumbers.FirstOrDefault(x => x.Value == valueB).Key;
            var myKeyC = availableCallingNumbers.FirstOrDefault(x => x.Value == valueC).Key;
            var myKeyD = availableCallingNumbers.FirstOrDefault(x => x.Value == valueD).Key;


            //<-------------End of Code Attribution------------->


            //assigns a variable to each string value of the listbox at a specific index
            string A = lbColumnA.Items[0].ToString();
            string B = lbColumnA.Items[1].ToString();
            string C = lbColumnA.Items[2].ToString();
            string D = lbColumnA.Items[3].ToString();


            //if statement to check if all the answers are correct
            if (myKeyA.Equals(A) && myKeyB.Equals(B) && myKeyC.Equals(C) && myKeyD.Equals(D))
            {

                //boolean value to that disables the timer of the form
                isActive = false;


                //takes the text from the 3 textboxes and adds it to a variable called finalTime which is used to display the final time of the task taken by the user
                finalTime = lblMinutes.Text + "m " + lblSeconds.Text + "s " + lblMilli.Text;

                worker.CheckTime(lblSeconds, lblMinutes, finalTime);

                // MessageBox.Show("Perfect all right");
                frmEndgame frmIA = new frmEndgame();
                this.Hide();
                frmIA.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Not all answers are correct, please try again");
            }

           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            //sets the time on the form to active
            isActive = true;

            //enables and disables the components functionality once the button btnStart has been clicked         
            btnStart.Enabled = false;
            btnCheckAnswers.Enabled = true;
            cmbAnswerA.Enabled = true;
            cmbAnswerB.Enabled = true;
            cmbAnswerC.Enabled = true;
            cmbAnswerD.Enabled = true;

            PopulateListBox(); // method call

            //sorts the comboboxes as well as the listbox at column B
            cmbAnswerA.Sorted = true;
            cmbAnswerB.Sorted = true;
            cmbAnswerC.Sorted = true;
            cmbAnswerD.Sorted = true;

            lbColumnB.Sorted = true;

        }

   

        private void pbExit_Click(object sender, EventArgs e)
        {
            //closes the current instance of the form
            frmMainMenu frmRB = new frmMainMenu();
            this.Hide();
            frmRB.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //<-----------------Code Attribution------------------
            //Code obtained from : https://www.youtube.com/watch?v=lp9cJJUDUsk&ab_channel=SaeThunder

            if (isActive)
            {
                timeCs++;

                if (timeCs >= 65)
                {
                    timeSec++;
                    timeCs = 0;

                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }

            DrawTime();

            //<-------------End of Code Attribution------------->
        }


        private void DrawTime()
        {
            lblMilli.Text = String.Format("{0:00}", timeCs);
            lblSeconds.Text = String.Format("{0:00}", timeSec);
            lblMinutes.Text = String.Format("{0:00}", timeMin);
        }



    }
}
