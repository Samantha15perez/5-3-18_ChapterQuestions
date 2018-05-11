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

namespace Tutorial7_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //the readscores method reads the scores from the
        //testscores.txt file into the scoresList parameter.
        private void ReadScores(List<int> scoresList)
        {
            try
            {
                //open the testscores.txt file
                StreamReader inputfile = File.OpenText("testscores.txt");

                //read the scores into the list
                while (!inputfile.EndOfStream)
                {
                    scoresList.Add(int.Parse(inputfile.ReadLine()));
                }
                //close the file
                inputfile.Close();
            }catch (Exception ex)
            {
                //display an error message
                MessageBox.Show(ex.Message);
            }
        }
        //the displayscores method displays the contents of the
        //scoreslist parameter in the listbox control
        private void DisplayScores(List<int> scoresList)
        {
            foreach (int score in scoresList)
            {
                testScoresListBox.Items.Add(score);
            }
        }

        //the Average Method returns the average of the values
        //in the scoreslist parameter
        private double Average(List<int> scoresList)
        {
            int total = 0;      //accumulator
            double average;        //to hold the average

            //calculate the total of the scores
            foreach(int score in scoresList)
            {
                total += score;
            }

            //calculate the average of the scores
            average = (double)total / scoresList.Count;

            //return the average
            return average;
        }
        //the aboveaverage method returns the number of
        //above average scores in scoresList
        private int AboveAverage (List<int> scoresList)
        {
            int numAbove = 0;       //ACCUMULATOR
            //GET THE AVERAGE SCORE
            double avg = Average(scoresList);

            //count the number of above average scores.
            foreach (int score in scoresList)
            {
                if (score > avg)
                {
                    numAbove++;
                }
            }
                //Return the number of above average scores.
                return numAbove;
            }


        //the belowaverage method returns the number of
        //below average scores in scoresList
        private int BelowAverage(List<int> scoresList)
        {
            int numBelow = 0;       //accumulator
            //get the average score
            double avg = Average(scoresList);
            //count the number of below average scores
            foreach (int score in scoresList)
            {
                if (score > avg)
                {
                    numBelow++;
                }
            }
                //return the number ofg below average scores.
                return numBelow;
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            //close the form.
            this.Close();
        }

        private void getScoresButton_Click_1(object sender, EventArgs e)
        {
            double averageScore; //to hold the average score
            int numAboveAverage; //number of above average scores
            int numBelowAverage; //number of below average scores

            //create a list to hold the scores
            List<int> scoresList = new List<int>();
            //read the scores from the file into the list
            ReadScores(scoresList);
            //display the scores
            DisplayScores(scoresList);
            //display the average score
            averageScore = Average(scoresList);
            aboveAverageLabel.Text = averageScore.ToString("n1");
            //display the number of above average scores
            numAboveAverage = AboveAverage(scoresList);
            aboveAverageLabel.Text = numAboveAverage.ToString();
            //DisplayScores the number of below average scores
            numBelowAverage = BelowAverage(scoresList);
            belowAverageLabel.Text = numBelowAverage.ToString();
        }
    }
}
