﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Character_Generator;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using AutoRoller;


namespace CharacterGUI
{
    public partial class Form1 : Form
    {
        private AutoRoller roller;
        private ClassRoller classRoller;
        private Race raceroller;

        //stat dictionaries
        private Dictionary<int, string> str;
        private Dictionary<int, string> dex;
        private Dictionary<int, string> con;
        private Dictionary<int, string> ent;
        private Dictionary<int, string> wis;
        private Dictionary<int, string> chr;
        private Dictionary<int, string> pcp;

        //proficiency list












        struct proficiency
        {
            public string name;
            public int slots;
            public string stat;
            public int modifier;

            public override string ToString()
            {
                string x;
                // this will return a string IT ISNT PRETTY INB THE UI BECAUSE IT NEEDS A MONOSPACE FONT
                //return normalize(name, slots, stat, modifier, 40);

                //THE BACKUP
                return String.Format("{0,-20} {1,-3} {2, -15} {3,-3}", name, slots, stat, modifier);



                //return String.Format("{0,-30}|{1,3}|{2, -15}|{3,-3}",name, slots, stat, modifier);
                //return name + " "+ slots+ " "+ stat + " "+ modifier;
            }



            //useless
            string normalize(string name, int slot, string stat, int modifier, int mathlength)
            {
                int maxNameWidth = 180;
                Graphics graphics = Graphics.FromImage(new Bitmap(1, 1));
                float spacewidth;
                Font measurement = new Font("Friz Quadrata Std", (12));
                string teststring = name + "";
                int spacesAdded = 0;

                StringFormat f = new StringFormat(StringFormat.GenericTypographic)
                { FormatFlags = StringFormatFlags.MeasureTrailingSpaces };

                //cant use space this is a solve but there isnt really a point
                // it wont even work with the same character
                while (maxNameWidth > graphics.MeasureString(teststring + "x", measurement).Width)
                {
                    spacesAdded++;
                    teststring += " ";
                }

                return name + " ".PadRight(spacesAdded, 'x') + slot;
            }
        }
        private List<proficiency> GeneralProf = new List<proficiency>();
        private List<proficiency> PriestProf = new List<proficiency>();
        private List<proficiency> WarriorProf = new List<proficiency>();
        private List<proficiency> RogueProf = new List<proficiency>();
        private List<proficiency> WizardProf = new List<proficiency>();


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

            //proficiency dictionary initializations


            readStats();
            readProficiencies();

            roller = new AutoRoller("3d6");
            roller.Roll();

            classRoller = new ClassRoller("Human", roller.getStats());
            raceroller = new Race();
        }


        private void Random_Click(object sender, EventArgs e)
        {
            string rollMethod = "";
            if (Rollmethod4d6d1.Checked)
            {
                rollMethod = Rollmethod4d6d1.Text;
            }
            else if (Rollmethod3d6r2.Checked)
            {
                rollMethod = Rollmethod3d6r2.Text;
            }
            else if (Rollmethod3d6.Checked)
            {
                rollMethod = Rollmethod3d6.Text;
            }

            roller.ReRoll(rollMethod);
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
            RaceBox.Text = charrace;
            Update_Proficiencies();



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
                            case "chr":
                                i = 1;
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    chr.Add(i++, line);
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
        private void readProficiencies()
        {

            using (System.IO.StreamReader file = new System.IO.StreamReader("regularProficiencies.txt"))
            {
                string line;
                string group;
                proficiency temp;
                while (!file.EndOfStream)
                {
                    line = file.ReadLine();

                    if (line.Equals("{"))
                    {
                        group = file.ReadLine();

                        switch (group)
                        {//priest rogue warrior wizard
                            case "gen":
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    temp.name = line;
                                    temp.slots = Convert.ToInt32(file.ReadLine());
                                    temp.stat = file.ReadLine();
                                    temp.modifier = Convert.ToInt32(file.ReadLine());
                                    GeneralProf.Add(temp);
                                    line = file.ReadLine();

                                }
                                break;
                            case "pri":
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    temp.name = line;
                                    temp.slots = Convert.ToInt32(file.ReadLine());
                                    temp.stat = file.ReadLine();
                                    temp.modifier = Convert.ToInt32(file.ReadLine());
                                    PriestProf.Add(temp);
                                    line = file.ReadLine();

                                }
                                break;
                            case "war":
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    temp.name = line;
                                    temp.slots = Convert.ToInt32(file.ReadLine());
                                    temp.stat = file.ReadLine();
                                    temp.modifier = Convert.ToInt32(file.ReadLine());
                                    WarriorProf.Add(temp);
                                    line = file.ReadLine();

                                }
                                break;
                            case "wiz":
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    temp.name = line;
                                    temp.slots = Convert.ToInt32(file.ReadLine());
                                    temp.stat = file.ReadLine();
                                    temp.modifier = Convert.ToInt32(file.ReadLine());
                                    WizardProf.Add(temp);
                                    line = file.ReadLine();

                                }
                                break;
                            case "rog":
                                line = file.ReadLine();
                                while (!line.Equals("}"))
                                {
                                    temp.name = line;
                                    temp.slots = Convert.ToInt32(file.ReadLine());
                                    temp.stat = file.ReadLine();
                                    temp.modifier = Convert.ToInt32(file.ReadLine());
                                    RogueProf.Add(temp);
                                    line = file.ReadLine();

                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            General_Prof_Box.DataSource = GeneralProf;
            Rogue_Prof_Box.DataSource = RogueProf;
            Wizard_Prof_Box.DataSource = WizardProf;
            Warrior_Prof_Box.DataSource = WarriorProf;
            Priest_Prof_Box.DataSource = PriestProf;

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

                    if (classRoller.isWarrior())
                        HPBox.Text = conSplit[1];
                    else
                        HPBox.Text = conSplit[0];

                    SSBox.Text = conSplit[2] + "%";
                    RSBox.Text = conSplit[3] + "%";
                    PSBox.Text = conSplit[4];
                    RegenBox.Text = conSplit[5];
                }
            }

        }

        private void IntelligenceBox_TextChanged(object sender, EventArgs e)
        {

            if (Int32.TryParse(IntelligenceBox.Text, out int stat))
            {
                if (stat > 26)
                    return;

                string entLine = "";
                ent.TryGetValue(stat, out entLine);

                if (entLine != null)
                {
                    string[] entSplit = entLine.Split();

                    LangBox.Text = entSplit[0];
                    if (stat < 9)
                    {
                        SpellBox.Text = "- -";
                        SpellChanceBox.Text = "- -";
                        MaxSpellBox.Text = "- -";
                    }
                    else
                    {
                        SpellChanceBox.Text = entSplit[2] + "%";
                        MaxSpellBox.Text = entSplit[3];
                    }

                    //ImmunityBox.Text = conSplit[4];
                }
            }
        }

        private void WisdomBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(WisdomBox.Text, out int stat))
            {
                if (stat > 26)
                    return;

                string wisLine = "";
                wis.TryGetValue(stat, out wisLine);

                if (wisLine != null)
                {
                    string[] wisSplit = wisLine.Split();

                    MDAdjBox.Text = wisSplit[0];

                    int l = wisSplit[1].Length;
                    string bonusSpells = "";

                    for (int i = 0; i < l; i++, bonusSpells += ",")
                    {
                        switch (i)
                        {
                            case 0:
                                bonusSpells += "1st x" + wisSplit[1][0];
                                break;
                            case 1:
                                bonusSpells += "2nd x" + wisSplit[1][1];
                                break;
                            case 2:
                                bonusSpells += "3rd x" + wisSplit[1][2];
                                break;
                            case 3:
                                bonusSpells += "4th x" + wisSplit[1][3];
                                break;
                            case 4:
                                bonusSpells += "5th x" + wisSplit[1][4];
                                break;
                            case 5:
                                bonusSpells += "6th x" + wisSplit[1][5];
                                break;
                            case 6:
                                bonusSpells += "7th x" + wisSplit[1][6];
                                break;
                            default:
                                bonusSpells = "None";
                                break;
                        }
                    }

                    if (Int32.Parse(wisSplit[1]) == 0)
                        bonusSpells = "None";

                    bonusSpellBox.Text = bonusSpells;

                    sFailureBox.Text = wisSplit[2] + "%";

                    if (wisSplit[3] == "1")
                        sImmunitiesBox.Text = "See book for more details.";
                    else
                        sImmunitiesBox.Text = "None";
                }
            }
        }

        private void CharismaBox_TextChanged(object sender, EventArgs e)
        {

            if (Int32.TryParse(CharismaBox.Text, out int stat))
            {
                if (stat > 26)
                    return;

                string conLine = "";
                chr.TryGetValue(stat, out conLine);

                if (conLine != null)
                {
                    string[] conSplit = conLine.Split();

                    HenchmenBox.Text = conSplit[0];
                    LoyaltyBox.Text = conSplit[1];
                    ReactAdjBox.Text = conSplit[2];

                }
            }
        }

        private void PerceptionBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(PerceptionBox.Text, out int stat))
            {
                if (stat > 26)
                    return;

                string pcpLine = "";

                dex.TryGetValue(stat, out pcpLine);

                if (pcpLine != null)
                {
                    string[] pcpSplit = pcpLine.Split();

                    PcpReactBox.Text = pcpSplit[2];

                }

                ent.TryGetValue(stat, out pcpLine);

                if (pcpLine != null)
                {
                    string[] pcpSplit = pcpLine.Split();


                    ImmunityBox.Text = pcpSplit[4];
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
            return !(ClassesList.CheckedItems.Count == 0);
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


        //updates the number of weapon and regular proficiencies via class and stats

        private void Update_Proficiencies()
        {   //clearing previous data
            Proficiencies_Box.Items.Clear();
            foreach (int i in General_Prof_Box.CheckedIndices)
            {
                General_Prof_Box.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in Rogue_Prof_Box.CheckedIndices)
            {
                Rogue_Prof_Box.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in Priest_Prof_Box.CheckedIndices)
            {
                Priest_Prof_Box.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in Wizard_Prof_Box.CheckedIndices)
            {
                Wizard_Prof_Box.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in Warrior_Prof_Box.CheckedIndices)
            {
                Warrior_Prof_Box.SetItemCheckState(i, CheckState.Unchecked);
            }
            //setting defaults
            int weapon = 0;
            int regular = 0;
            Proficiency_Access_Box.Text = string.Empty;
            Proficiency_Access_Box.Text += "General ";


            //switch case to determine which classes have access to what proficiencies 
            switch (Classbox.Text)
            {
                case "Ranger":
                    Proficiency_Access_Box.Text += "Wizard ";
                    goto case "Fighter";

                case "Paladin":
                    Proficiency_Access_Box.Text += "Priest ";
                    goto case "Fighter";
                case "Fighter":
                    weapon = 4;
                    regular = 3;
                    Proficiency_Access_Box.Text += "Warrior ";
                    break;
                case "Cleric":
                    Proficiency_Access_Box.Text += "Priest ";

                    weapon = 2;
                    regular = 4;
                    break;
                case "Wizard":
                    Proficiency_Access_Box.Text += "Wizard ";

                    weapon = 1;
                    regular = 4;
                    break;
                case "Bard":
                    Proficiency_Access_Box.Text += "Warrior ";
                    Proficiency_Access_Box.Text += "Wizard ";
                    goto case "Thief";
                case "Thief":
                    Proficiency_Access_Box.Text += "Rogue ";
                    weapon = 2;
                    regular = 3;

                    break;
                case "Log ":
                    weapon = -1;
                    regular = -1;

                    break;
                default: break;

            }
            //setting # of proficiecncies 
            WeaponNumber.Text = weapon.ToString();
            RegularNumber.Text = (regular + Convert.ToInt32(LangBox.Text)).ToString();
            Remaining_Prof.Text = (regular + Convert.ToInt32(LangBox.Text)).ToString();
        }





        //user tries to add a general proficiency 

        private void General_Prof_Box_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            proficiencyhandler("General", e);
        }

        private void Priest_Prof_Box_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            proficiencyhandler("Priest", e);
        }
        private void Rogue_Prof_Box_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            proficiencyhandler("Rogue", e);
        }
        private void Wizard_Prof_Box_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            proficiencyhandler("Wizard", e);
        }

        private void Warrior_Prof_Box_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            proficiencyhandler("Warrior", e);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="boxtype"> essentially a case determintes which proficiency category is being selected</param>
        /// <param name="e"> the event from said box</param>
        private void proficiencyhandler(String boxtype, ItemCheckEventArgs e)
        {

         



            //clearing box
            Proficiency_Error_Box.Text = "";
            int result = 0;
            int.TryParse(Remaining_Prof.Text, out result);

            /// the actual box in the gui
            var BoxTarget = General_Prof_Box;
            //the list that actually holds the prof data
            var ListTarget = GeneralProf;

            //cost of the proficiency 
            int cost = ListTarget[e.Index].slots;
            
            //checks to see if we actually have access to the proficiency 
            bool Has_Access = false;
            if (Proficiency_Access_Box.Text.Contains(boxtype))
            {
                Has_Access = true;
            }

            if (!Has_Access) 
            {
                cost++;
            }
            switch (boxtype) 
            {
                case "General":
                    {
                        BoxTarget = General_Prof_Box;
                        ListTarget = GeneralProf;
                        break;
                    }

                case "Warrior":
                    {
                        BoxTarget = Warrior_Prof_Box;
                        ListTarget = WarriorProf;
                        break;
                    }
                case "Rogue":
                    {
                        BoxTarget = Rogue_Prof_Box;
                        ListTarget = RogueProf;
                        break;
                    }
                case "Priest":
                    {
                        BoxTarget = Priest_Prof_Box;
                        ListTarget = PriestProf;
                        break;
                    }
                case "Wizard":
                    {
                        BoxTarget = Wizard_Prof_Box;
                        ListTarget = WizardProf;
                        break;
                    }
                default:
                break;
            }








          
            if (BoxTarget.GetItemCheckState(e.Index) != CheckState.Checked)
            {
                //check to see if we have slots if not uncheck
                //check to see if its already in the list if so check slot


                if (result - ListTarget[e.Index].slots >= 0)
                {
                    if (Proficiencies_Box.Items.Count == 0)
                    {
                        Proficiencies_Box.Items.Add(BoxTarget.Items[e.Index]);
                        Remaining_Prof.Text = (result - cost).ToString();
                        return;
                    }

                    //checking to see if it is alreay in the proficiency box
                    foreach (var stuff in Proficiencies_Box.Items)
                    {
                        if (!stuff.ToString().Equals(ListTarget[e.Index].ToString()))
                        {
                            Proficiencies_Box.Items.Add(BoxTarget.Items[e.Index]);
                            Remaining_Prof.Text = (result - cost).ToString();

                            return;
                        }
                    }
                    BoxTarget.SetItemChecked(e.Index, false);
                    Proficiency_Error_Box.Text = "Proficiency has already been added";
                    return;

                }
                BoxTarget.SetItemChecked(e.Index, false);
                Proficiency_Error_Box.Text = "You do not have enough slots";
                return;
            }
            else
            {


                foreach (var stuff in Proficiencies_Box.Items)
                {
                    if (stuff.ToString().Equals(ListTarget[e.Index].ToString()))
                    {

                        //Console.WriteLine("WE happy");
                        Proficiencies_Box.Items.Remove(BoxTarget.Items[e.Index]);
                        Remaining_Prof.Text = (result + cost).ToString();
                        return;
                    }
                }

            }



        }

        
    }
}
    

