using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SoldireData.Models;

namespace SoldireData
{
    public partial class SoldireDataEntry : Form
    {
        List<Soldire> soldireList = new List<Soldire>();
        public SoldireDataEntry()
        {
            InitializeComponent();
        }

        private void btnSoldireSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoldireNo.Text == "" || txtSoldireName.Text == "" || txtScoreOne.Text == "" || txtScoreTwo.Text == "" || txtScoreThree.Text == "" || txtScoreFour.Text == "")
                {
                    MessageBox.Show("Fill the All TextBox");
                    return;
                }

                string solNo = txtSoldireNo.Text;
                string solName = txtSoldireName.Text;
                //double solScoreOne; = Convert.ToDouble(txtScoreOne.Text);
                //double solScoreTwo; = Convert.ToDouble(txtScoreTwo.Text);
                //double solScoreThree; = Convert.ToDouble(txtScoreThree.Text);
                //double solScoreFour; = Convert.ToDouble(txtScoreFour.Text);

                double solScoreOne, solScoreTwo, solScoreThree, solScoreFour;

                if (double.TryParse(txtScoreOne.Text,out solScoreOne) == false)
                {
                    MessageBox.Show("Correct the integer number in Score 1 ");
                    txtScoreOne.Focus();
                    txtScoreOne.Clear();
                    return;
                }
                if (double.TryParse(txtScoreTwo.Text, out solScoreTwo) == false)
                {
                    MessageBox.Show("Correct the integer number in Score 2 ");
                    txtScoreTwo.Focus();
                    txtScoreTwo.Clear();
                    return;
                }
                if (double.TryParse(txtScoreThree.Text, out solScoreThree) == false)
                {
                    MessageBox.Show("Correct the integer number in Score 3 ");
                    txtScoreThree.Focus();
                    txtScoreThree.Clear();
                    return;
                }
                if (double.TryParse(txtScoreFour.Text, out solScoreFour) == false)
                {
                    MessageBox.Show("Correct the integer number in Score 4 ");
                    txtScoreFour.Focus();
                    txtScoreFour.Clear();
                    return;
                }

                foreach (Soldire sol in soldireList)
                {
                    if (solNo == sol.soldireNo)
                    {
                        MessageBox.Show("Soldire Already Exist!");
                        return;
                    }
                }

                Soldire soldire = new Soldire();
                soldire.soldireNo = solNo;
                soldire.soldireName = solName;
                soldire.scoreOne = solScoreOne;
                soldire.scoreTwo = solScoreTwo;
                soldire.scoreThree = solScoreThree;
                soldire.scoreFour = solScoreFour;
                soldire.CalculateResult();

                soldireList.Add(soldire);

                MessageBox.Show("Soldire Saved");
                txtSoldireNo.Clear();
                txtSoldireName.Clear();
                txtScoreOne.Clear();
                txtScoreTwo.Clear();
                txtScoreFour.Clear();
                txtScoreThree.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Fill the Search Box");
                return;
            }

            lbSoldireDataShow.Items.Clear();
            lbSoldireDataShow.Items.Add("Soldire No.\tSoldire Name\tAverage Score\tTotal Score");

            string searchData = txtSearch.Text;
            bool chk = false;
            foreach (Soldire sol in soldireList)
            {
                string data = sol.soldireNo + "\t\t" + sol.soldireName + "\t\t" + sol.averageScore + "\t\t" + sol.totalScore;
                if (rbSoldireNo.Checked == true)
                {
                    if (searchData == sol.soldireNo)
                    {
                        lbSoldireDataShow.Items.Add(data);
                        chk = true;
                    }
                    
                }
                else if(rbSoldireName.Checked == true)
                {
                    if (searchData == sol.soldireName)
                    {
                        lbSoldireDataShow.Items.Add(data);
                        chk = true;
                    }
                    
                }
                
            }
            if (chk == false)
            {
                MessageBox.Show("Soldier Not Found!");
                lbSoldireDataShow.Items.Clear();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            lbSoldireDataShow.Items.Clear();
            lbSoldireDataShow.Items.Add("Soldire No.\tSoldire Name\tAverage Score\tTotal Score");

            
            double topAvgScore = 0;
            double topTotalScore = 0;
            string topAvgScoreName = "", topTotalScoreName = "";

            foreach (Soldire sol in soldireList)
            {
                string data = sol.soldireNo + "\t\t" + sol.soldireName + "\t\t" + sol.averageScore + "\t\t" + sol.totalScore;
                lbSoldireDataShow.Items.Add(data);

                if (topAvgScore < sol.averageScore)
                {
                    topAvgScore = sol.averageScore;
                    topAvgScoreName = sol.soldireName;
                }

                if (topTotalScore < sol.totalScore)
                {
                    topTotalScore = sol.totalScore;
                    topTotalScoreName = sol.soldireName;
                }
            }

            txtTopAvgScore.Text = topAvgScoreName;
            txtTopTotalScore.Text = topTotalScoreName;

        }

        
    }
}
