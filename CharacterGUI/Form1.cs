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
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Random_Click(object sender, EventArgs e)
        {
            string value ="";
            if (Rollmethod3d6.Checked)
            {
                value = Rollmethod3d6.Text;
            }
            else if (Rollmethod3d6r2.Checked)
            {
                value = Rollmethod3d6.Text;
            }
            else if (Rollmethod4d6d1.Checked)
            {
                value = Rollmethod3d6.Text;
            }
            Console.WriteLine(value);

            AutoRoller roller = new AutoRoller(value);
            roller.Roll();

            ClassRoller classRoller = new ClassRoller("Human", roller.getStats());
            classRoller.RollClass();

            populate_form(classRoller.GetClass(), classRoller.GetRace(), roller.getStats());

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //this function takes an array of numbers and updates the stats
        private void populate_form(string charclass, string charrace, int[] charstats) 
        {

            StrengthBox.Text = charstats[0].ToString();
            DexterityBox.Text = charstats[1].ToString();
            ConstitutionBox.Text = charstats[2].ToString();
            IntelligenceBox.Text = charstats[3].ToString();
            WisomBox.Text = charstats[4].ToString();
            CharismaBox.Text = charstats[5].ToString();
            DumpBox.Text = charstats[6].ToString();


        }

        private void statsbox_Enter(object sender, EventArgs e)
        {

        }
    }
}
