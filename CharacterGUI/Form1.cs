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

        private string Get_Roll_Method() 
        {
            if (Rollmethod4d6d1.Checked)
            {
                return  Rollmethod4d6d1.Text;
            }
            else if (Rollmethod3d6r2.Checked)
            {
                return Rollmethod3d6r2.Text;
            }
            else  
            {//default
                return Rollmethod3d6.Text;
            }
        }

        private void Random_Click(object sender, EventArgs e)
        {
            string value = Get_Roll_Method();
           
            

            AutoRoller roller = new AutoRoller(value);
            roller.Roll();

            ClassRoller classRoller = new ClassRoller("Human", roller.getStats());
            

            populate_form(classRoller.RollClass() , classRoller.GetRace(), roller.getStats());

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //this function takes an array of numbers and updates the stats
        private void populate_form(string charclass, string charrace, int[] charstats) 
        {
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
            StrengthLabel.Text = charstats[0].ToString();
            DexterityLabel.Text = charstats[1].ToString();
            ConstitutionLabel.Text = charstats[2].ToString();
            IntelligenceLabel.Text = charstats[3].ToString();   
            WisdomLabel.Text = charstats[4].ToString();
            CharismaLabel.Text = charstats[5].ToString();
            PerceptionLabel.Text = charstats[6].ToString();




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
    
        
  
        private bool ValidRaceInput() 
        {

            if (ClassesList.CheckedItems.Count == 0)
            {
                ErrorBox.Text += ErrorBox.Text + "You must Select a race to continue";
                return false;
            }
            return true;


        }
        private bool ValidClassInput() 
        {

            
            //class input validation 
            if (ClassesList.CheckedItems.Count == 0)
            {
                ErrorBox.Text += ErrorBox.Text + "You must Select a class to continue";
                
                return false;
            }
            return true;

            
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

        private void label11_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// This function takes in three parameters and access more data inside
        /// We iterate through the classes and create an array of classes that we want
        /// There various cases due to posibilities of elite and multi class characters
        /// 
        /// 
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            //clearing text for error box
            ErrorBox.Text = "";
            
            if (ValidClassInput() && ValidRaceInput())
            {
                //selecting race
                Random rnd = new Random();
                int num = rnd.Next(RacesList.CheckedItems.Count);
                string race = RacesList.CheckedItems[num].ToString();
                

                if (MultiCheck.Checked)

                {


                }
                else
                {
                   //case of single no multiclass
                    //selectiing class
                    int x = rnd.Next(ClassesList.CheckedItems.Count);
                    string charclass = ClassesList.CheckedItems[num].ToString();


                    ClassSelector cl = new ClassSelector();
                    cl.SetClass(charclass);
                                                                        //iselite remove  later
                    cl.RollStatsforClass(charclass,Get_Roll_Method());
                    populate_form(charclass, race, cl.getStats());
                  


                }
            }
            else 
            { 
                //failure to have correct form data
                return; 
            
            }


        }
    }
}
