using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireRangeAutomationSystem
{
    public partial class SoldireFireRange : Form
    {
        List<string> soldierNo = new List<string>();
        List<string> soldierName = new List<string>();
        List<string> tScore1 = new List<string>();
        List<string> tScore2 = new List<string>();
        List<string> tScore3 = new List<string>();
        List<string> tScore4 = new List<string>();

        string sno = "";
        string sn = "";
        string ts1 = "";
        string ts2 = "";
        string ts3 = "";
        string ts4 = "";

  

        public SoldireFireRange()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            sno = soldierNoextBox.Text;
            sn = soldierNameTextBox.Text;
            ts1 = scoreOneTextBox.Text;
            ts2 = scoreTwoTextBox.Text;
            ts3 = scoreThreeTextBox.Text;
            ts4 = scoreFourTextBox.Text;

            if (sno == "" || sn == "" || ts1 == "" || ts2 == "")
            {
                MessageBox.Show("Field Must not be empty");
                return;
            }
            else if (soldierName.Count > 0)
            {
                for (int i = 0; i < soldierNo.Count; i++)
                {
                    if (sno == soldierNo[i])
                    {
                        MessageBox.Show("Soldier Id is Already Exist..");
                        soldierNoextBox.Clear();
                        return;
                    }

                    if (sn == soldierName[i])
                    {
                        MessageBox.Show("Soldier Name is Already Exist..");
                        soldierNameTextBox.Clear();
                        return;
                    }
                }
            }

            soldierNo.Add(sno);
            soldierName.Add(sn);
            tScore1.Add(ts1);
            tScore2.Add(ts2);
            tScore3.Add(ts3);
            tScore4.Add(ts4);
            MessageBox.Show("Added Succesfully");
            Clear();
            
        }

        private void Clear()
        {
            soldierNoextBox.Clear();
            soldierNameTextBox.Clear();
            scoreOneTextBox.Clear();
            scoreTwoTextBox.Clear();
            scoreThreeTextBox.Clear();
            scoreFourTextBox.Clear();
        }

        double[] sum = new double[10];
        double[] avg = new double[10];

        private void showButton_Click(object sender, EventArgs e)
        {
            int c = 1;
            showListBox.Items.Clear();
            for (int i = 0; i < soldierName.Count; i++)
            {
                double x = Convert.ToDouble(tScore1[i]);
                double y = Convert.ToDouble(tScore2[i]);
                double z = Convert.ToDouble(tScore3[i]);
                double r = Convert.ToDouble(tScore4[i]);

                sum[i] = x + y + z + r;
                avg[i] = sum[i] / 4;

                if (c>0)
                {
                    showListBox.Items.Add("Soldier No" + "\tSoldier Name" + "\tAverage" + "\t\tTotal");
                    c--;
                }
                
                showListBox.Items.Add(soldierNo[i]+"\t\t"+soldierName[i]+
                    "\t\t"+avg[i]+ "\t\t" + sum[i]);

                //showListBox.Items.Add(soldierName[i]);
                //showListBox.Items.Add(tScore1[i]);
                //showListBox.Items.Add(tScore2[i]);
                //showListBox.Items.Add(tScore3[i]);
                //showListBox.Items.Add(tScore4[i]);
                //showListBox.Items.Add(sum[i]);
                //showListBox.Items.Add(avg[i]);

                //showListBox.Items.AddRange(new object[]{
                //    "Soldier No:  "+soldierNo[i],
                //    "Soldier Name:  "+soldierName[i],
                //    "Target Score_1:  "+tScore1[i],
                //    "Target Score_2:  "+tScore2[i],
                //    "Target Score_3:  "+tScore3[i],
                //    "Target Score_4:  "+tScore4[i],
                //    "Summation:  "+sum[i],
                //    "Average:  "+avg[i]
                //    });
            }

            //showRichTextBox.Text = "Sum: " + "\tAverage: \n"+ summation+"\t"+""+average;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string sText = searchTextBox.Text;
            if (sText != "")
            {
                if (soldierName.Count <= 0)
                {
                    MessageBox.Show("Add value is not available..");
                    return;
                }
                else
                {
                    for (int i = 0; i < soldierName.Count; i++)
                    {
                        if (idRadioButton.Checked)
                        {
                            if (sText == soldierNo[i])
                            {
                                showListBox.Items.Clear();
                                //showListBox.MultiColumn = false;
                                showListBox.Items.Add("Soldier No:  " + soldierNo[i]);
                                showListBox.Items.Add("Soldier Name: " + soldierName[i]);
                                showListBox.Items.Add("Target Score_1:  " + tScore1[i]);
                                showListBox.Items.Add("Target Score_2: " + tScore2[i]);
                                showListBox.Items.Add("Target Score_2: " + tScore2[i]);
                                showListBox.Items.Add("Target Score_3:  " + tScore3[i]);
                                showListBox.Items.Add("Target Score_4:  " + tScore4[i]);
                                return;
                            }
                        }
                        else if (nameRadioButton.Checked)
                        {
                            if (sText == soldierName[i])
                            {
                                showListBox.Items.Clear();
                                //showListBox.MultiColumn = false;
                                showListBox.Items.Add("Soldier No:  " + soldierNo[i]);
                                showListBox.Items.Add("Soldier Name: " + soldierName[i]);
                                showListBox.Items.Add("Target Score_1:  " + tScore1[i]);
                                showListBox.Items.Add("Target Score_2: " + tScore2[i]);
                                showListBox.Items.Add("Target Score_2: " + tScore2[i]);
                                showListBox.Items.Add("Target Score_3:  " + tScore3[i]);
                                showListBox.Items.Add("Target Score_4:  " + tScore4[i]);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Soldier No Or Soldier Name..");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Search value is required..");
                return;
            }

            MessageBox.Show("Sorry there is no search item available...");
            return;
        }
    }
}
