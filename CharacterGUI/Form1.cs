using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Character_Generator;
//using AutoRoller;


namespace CharacterGUI
{
    public partial class Form1 : Form
    {
        private AutoRoller roller;
        private ClassRoller classRoller;

        public Form1()
        {
            InitializeComponent();

            roller = new AutoRoller("3d6");
            roller.Roll();

            classRoller = new ClassRoller("Human", roller.getStats());
        }

        private void Random_Click(object sender, EventArgs e)
        {
            string value ="";
            if (Rollmethod4d6d1.Checked)
            {
                value = Rollmethod4d6d1.Text;
            }
            else if (Rollmethod3d6r2.Checked)
            {
                value = Rollmethod3d6r2.Text;
            }
            else if (Rollmethod3d6.Checked)
            {
                value = Rollmethod3d6.Text;
            }

            roller.ReRoll(value);

            populate_form(classRoller.RollClass(roller.getStats()), classRoller.GetRace(), roller.getStats());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //this function takes an array of numbers and updates the stats
        private void populate_form(string charclass, string charrace, int[] charstats) 
        {
            statDisplay.DataSource = charstats;
            //This is a much simpler way to display the stats


            //populating editable statbox
            StrengthBox.Text = charstats[0].ToString();
            DexterityBox.Text = charstats[1].ToString();
            ConstitutionBox.Text = charstats[2].ToString();
            IntelligenceBox.Text = charstats[3].ToString();
            WisomBox.Text = charstats[4].ToString();
            CharismaBox.Text = charstats[5].ToString();
            DumpBox.Text = charstats[6].ToString();

            Classbox.Text = charclass;

            //populating rollbox
            /*StrengthLabel.Text = charstats[0].ToString();
            DexterityLabel.Text = charstats[1].ToString();
            ConstitutionLabel.Text = charstats[2].ToString();
            IntelligenceLabel.Text = charstats[3].ToString();   
            WisdomLabel.Text = charstats[4].ToString();
            CharismaLabel.Text = charstats[5].ToString();
            PerceptionLabel.Text = charstats[6].ToString();
            */

        }

        private void statsbox_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       /// <summary>
       /// This function takes in three parameters and access more data inside
       /// We iterate through the classes and create an array of classes that we want
       /// There various cases due to posibilities of elite and multi class characters
       /// 
       /// 
       /// </summary>
       /// <param name="race"></param>
       /// <param name="ismulitclass"></param>
       /// <param name="iselite"></param>
        private void GenerateButton_Click()
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }
    }
}
