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
        private Race raceroller;

        private Dictionary<int, string> str;
        private Dictionary<int, string> dex;
        private Dictionary<int, string> con;
        private Dictionary<int, string> ent;
        private Dictionary<int, string> wis;
        private Dictionary<int, string> chr;
        private Dictionary<int, string> pcp;

        public Form1()
        {
            InitializeComponent();

            str = new Dictionary<int, string>();
            dex = new Dictionary<int, string>();
            con = new Dictionary<int, string>();
            ent = new Dictionary<int, string>();
            wis = new Dictionary<int, string>();
            chr = new Dictionary<int, string>();
            pcp = new Dictionary<int, string>();

            readStats();

            roller = new AutoRoller("3d6");
            roller.Roll();

            classRoller = new ClassRoller("Human", roller.getStats());
            raceroller = new Race();
        }

        private void Random_Click(object sender, EventArgs e)
        {
            string value = "";
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
            classRoller.UpdateRace(raceroller.RaceRoll());

            populate_form(classRoller.RollClass(roller.getStats()), classRoller.GetRace(), roller.getStats());
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
            WisdomBox.Text = charstats[4].ToString();
            CharismaBox.Text = charstats[5].ToString();
            PerceptionBox.Text = charstats[6].ToString();

            string strLine = "";

            str.TryGetValue(charstats[0], out strLine);

            string[] strSplit = strLine.Split();

            HitAdjBox.Text = strSplit[0];
            DamAdjBox.Text = strSplit[1];
            WeightAllowBox.Text = strSplit[2];
            MaxPressBox.Text = strSplit[3];
            OpenDoorsBox.Text = strSplit[4] + "(" + strSplit[5] + ")";
            BBLGBox.Text = strSplit[6] + "%";

            Classbox.Text = charclass;
            RaceBox.Text= charrace;

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


        /// <summary>
        /// This function takes in three parameters and access more data inside
        /// We iterate through the classes and create an array of classes that we want
        /// There various cases due to posibilities of elite and multi class characters
        /// </summary>
        /// <param name="race"></param>
        /// <param name="ismulitclass"></param>
        /// <param name="iselite"></param>
     

        /// <summary>
        /// Reads in the stat lines
        /// </summary>
        private void readStats()
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader("statFields.txt"))
            {
                string line;
                string stat;
                while (!file.EndOfStream)
                {
                    line = file.ReadLine();

                    if (line.Equals("{"))
                    {
                        stat = file.ReadLine();

                        switch (stat)
                        {
                            case "str":
                                int i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    str.Add(i++, line);
                                    line = file.ReadLine();
                                }
                                break;
                            case "dex":
                                i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    dex.Add(i++, line);
                                    line = file.ReadLine();
                                }
                                break;
                            case "con":
                                i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    con.Add(i++, line);
                                    line = file.ReadLine();
                                }
                                break;
                            case "ent":
                                i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    ent.Add(i++, line);
                                    line = file.ReadLine();
                                }
                                break;
                            case "wis":
                                i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    wis.Add(i++, line);
                                    line = file.ReadLine();
                                }
                                break;
                            case "charisma":
                                i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    chr.Add(i++, line);
                                    line = file.ReadLine();
                                }
                                break;
                            case "pcp":
                                i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    pcp.Add(i++, line);
                                    line = file.ReadLine();
                                }
                                break;
                            default:
                                break;

                        }
                    }
                }
            }
        }

        private void StrengthBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(StrengthBox.Text, out int stat))
            {
                if (stat > 26)
                    return;



                string strLine = "";
                str.TryGetValue(stat, out strLine);

                if (strLine != null)
                {
                    string[] strSplit = strLine.Split();


                    HitAdjBox.Text = strSplit[0];
                    DamAdjBox.Text = strSplit[1];
                    WeightAllowBox.Text = strSplit[2];
                    MaxPressBox.Text = strSplit[3];
                    OpenDoorsBox.Text = strSplit[4] + "(" + strSplit[5] + ")";
                    BBLGBox.Text = strSplit[6] + "%";
                }
            }

        
            
        }

        private void DexterityBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(DexterityBox.Text, out int stat))
            {
                if (stat > 26)
                    return;



                string dexLine = "";
                dex.TryGetValue(stat, out dexLine);

                if (dexLine != null)
                {
                    string[] dexSplit = dexLine.Split();


                    ReactBox.Text = dexSplit[0];
                    MissileBox.Text = dexSplit[1];
                    ACBox.Text = dexSplit[2];
          
                }
            }



        }

        private void ConstitutionBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(ConstitutionBox.Text, out int stat))
            {
                if (stat > 26)
                    return;

                string conLine = "";
                con.TryGetValue(stat, out conLine);

                if (conLine != null)
                {
                    string[] conSplit = conLine.Split();

                    HPBox.Text = conSplit[0];
                    SSBox.Text = conSplit[1];
                    RSBox.Text = conSplit[2];
                    PSBox.Text = conSplit[3];
                    RegenBox.Text = conSplit[4];
                }
            }

        }

        private bool ValidRaceInput()
        {

            if (RacesList.CheckedItems.Count == 0)
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
                ErrorBox.Text += ErrorBox.Text + "You must Select a class to continue"; //If options are unselected we should roll them randomly if possible -Ryan

                return false;
            }
            return true;


        }



        private string Get_Roll_Method()
        {
            if (Rollmethod4d6d1.Checked)
            {
                return Rollmethod4d6d1.Text;
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
        private string RollRace()
        {
            Random rnd = new Random();
            int num = rnd.Next(RacesList.Items.Count);
            return RacesList.Items[num].ToString();
        }

        //take priority on the character creation via book
        //scores race and class
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            //clearing text for error box
            ErrorBox.Text = "";









            if (ValidClassInput())
            {
                //selecting race
                Random rnd = new Random();
                int num;
                string race;
                if (RacesList.CheckedItems.Count > 0)
                {

                     num = rnd.Next(RacesList.CheckedItems.Count);
                     race = RacesList.CheckedItems[num].ToString();

                }
                else
                {
                    race = RollRace(); 
                }


                if (MultiCheck.Checked)

                {


                }
                else
                {
                    //case of single no multiclass
                    //selectiing class
                    num = rnd.Next(ClassesList.CheckedItems.Count);
                    string charclass = ClassesList.CheckedItems[num].ToString();
                   


                    ClassSelector cl = new ClassSelector();
                    cl.SetClass(charclass);
                    //iselite remove  later
                    cl.RollStatsforClass(charclass, Get_Roll_Method());
                    populate_form(charclass, race, cl.getStats());



                }
            }
            else
            {
                //failure to have correct form data
                //We should just roll a random character if nothing is selected -Ryan
                string value = "";
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
                classRoller.UpdateRace(raceroller.RaceRoll());

                populate_form(classRoller.RollClass(roller.getStats()), classRoller.GetRace(), roller.getStats());
                return;

            }


        }

        private void IntelligenceBox_TextChanged(object sender, EventArgs e)
        {

            if (Int32.TryParse(IntelligenceBox.Text, out int stat))
            {
                if (stat > 26)
                    return;

                string conLine = "";
                ent.TryGetValue(stat, out conLine);

                if (conLine != null)
                {
                    string[] conSplit = conLine.Split();

                    LangBox.Text = conSplit[0];
                    SpellBox.Text = conSplit[1];
                    SpellChanceBox.Text = conSplit[2];
                    MaxSpellBox.Text = conSplit[3];
                    ImmunityBox.Text = conSplit[4];
                }
            }
        }
    }
}
    

