using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Character_Generator
{
    public class ClassRoller
    {
        private string race;
        private int[] stats;
        private string charclass;
        private Dictionary<string, ClassInfo> classReqs;

        //class weights
        //Base race weights
        private int FighterChance;  private int FighterThreshhold; //Could these be arrays of length 2? Might clean up the amount of variables/typing needed
        private int RangerChance;   private int RangerThreshhold;
        private int PaladinChance;  private int PaladinThreshhold;
        private int WizardChance;   private int WizardThreshhold;
        private int ClericChance;   private int ClericThreshhold;
        private int ThiefChance;    private int ThiefThreshhold;
        private int BardChance;     private int BardThreshhold;



        //constructor

        public ClassRoller(string _race, int[] _stats)
        {



            //Base Race    //Weight                                                                
            FighterChance   = 35; FighterThreshhold = FighterChance + 0; //This feels needless complicated/bloated
            RangerChance    = 40; RangerThreshhold = RangerChance + FighterThreshhold;
            PaladinChance   = 40; PaladinThreshhold = PaladinChance + RangerThreshhold;
            WizardChance    = 10; WizardThreshhold = WizardChance + PaladinThreshhold;
            ClericChance    = 12; ClericThreshhold = ClericChance + WizardThreshhold;
            ThiefChance     = 20; ThiefThreshhold = ThiefChance + ClericThreshhold;
            BardChance      = 20; BardThreshhold = BardChance + ThiefThreshhold;


            classReqs = new Dictionary<string, ClassInfo>();
            race = _race;
            stats = _stats;
            readReqs();
        }


        public void UpdateStats(int[] statroll) 
        {
            int i = 0;
            foreach (int cstat in statroll) 
            
            {
                stats[i] = statroll[i];
                i++;

            }
          
        }
        public int[] GetStats() { return stats; }

        public void UpdateRace(string CharRace) 
        {

            race = CharRace;

        }
         public string GetRace() { return race; }

        public string GetClass() 
        {
            return charclass;        
        }

        //This function checks to see if a character's race is valid for the given class
        //Assumptions: We know the selected class, and We know the selected race and we have access to a list of valid races
        private bool validrace(string classname) 
        {
            ClassInfo storage;

            //test to see if our classname is actually in the classreq dictionary. 
            //this should be true in all cases where our data has been read in properly

            if (!classReqs.TryGetValue(classname, out storage))
            { return false; }
            else
            //test to see what races are valid
            {
                
                //any case
                if (storage.Races[0] == "Any" )
                { return true; }
                int i = 0; 
                foreach (string Race in storage.Races) 
                {  if (storage.Races[i] == race)
                        return true;
                
                }
                    
            
            }
            return false;
        
        
        
        }
        //This functions purpose is a helper function for RollClass
        //This function checks to see if a character's stats are valid for the given class
        //Assumptions: We know the selected class, and know our stats.
        public bool validstats(string classname)
        {
           
            ClassInfo Storage;
            string Requirement;
            //test to see if our classname is actually in the classreq dictionary. 
            //this should be true in all cases where our data has been read in properly
            if (!classReqs.TryGetValue(classname, out Storage))
            { return false; }
            else
            //test to see if our stats are valid
            {   //variable to hold stat requirement number ex: strength would mean 9
                int numVal;
                // for loop to iterate through stats

                for (int i = 0; i < 7; i++)
                {
                    Storage.StatReqs.TryGetValue(i.ToString(), out Requirement);
                    if (Requirement != null)
                    {  //converting string to int
                        numVal = Int32.Parse(Requirement);
                        if (! (stats[i] >= numVal) )
                        { 
                            return false;
                        }
                    }
                
                }


            }
            return true;
        }
        //this functions purpose is to roll a class and determine if the stats apply
        public string RollClass()
        {
            //creaiting a new Random object
            Random rng = new Random();
            // rolled class container
            String RolledClass = "";
            //Loop flag


            //Statements needed to have to determine if we can be any class purely to see if we have run out of classes to be
            bool CanFighter = true;
            bool CanRanger = true;
            bool CanPaladin = true;
            bool CanWizard = true;
            bool CanCleric = true;
            bool CanThief = true;
            bool CanBard = true;
            bool done = false;

            while (!done)
            {
                //Log- as in stat log check


                if (!(CanFighter || CanRanger || CanPaladin|| CanWizard|| CanCleric||CanThief||CanBard)) 
                {
                    return "Log";
                    break; }
                //Rolling the number
                int roll = rng.Next(BardThreshhold + 1);

                //massive evaluation statement

                switch (roll)
                {
                    case int n when n <= FighterThreshhold:
                        {
                            RolledClass = "Fighter";
                            //tests to see if we can be a fighter
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                            else CanFighter = false;
                        }
                        break;
                    case int n when n <= RangerThreshhold:
                        {

                            RolledClass = "Ranger";
                            //tests to see if we can be a Ranger
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                            else CanRanger = false;
                        }
                        break;
                    case int n when n <= PaladinThreshhold:
                        {
                            RolledClass = "Paladin";
                            //tests to see if we can be a Paladin
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                            else CanPaladin = false;
                        }
                        break;
                    case int n when n <= WizardThreshhold:
                        {
                            RolledClass = "Wizard";
                            //tests to see if we can be a wizard
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                            else CanWizard = false;
                        }
                        break;
                    case int n when n <= ClericThreshhold:
                        {
                            RolledClass = "Cleric";
                            //tests to see if we can be a cleric
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                            else CanCleric = false;

                        }
                        break;
                    case int n when n <= ThiefThreshhold:
                        {
                            RolledClass = "Thief";
                            //tests to see if we can be a Thief
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                            else CanThief = false;

                        }
                        break;
                    case int n when n <= BardThreshhold:
                        {
                            
                                RolledClass = "Bard";
                            //tests to see if we can be a Bard
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                            else
                                CanBard = false;
                        }   
                            
                        break;
                    default:
                        done = true;
                        return "Roll switch statement is broken"; //Funny LR
                        break;
                }
            } return "system failure";
          
        }

        /// <summary>
        /// Parses a file with classes and their requirements/restrictions.
        /// Stores parsed information for use during generation.
        /// </summary>
        private void readReqs()
        {

            //alternate path for the file 
            //original"..\\..\\..\\..\\Character Generator\\ClassInfo.txt"
            //for github
            
            //path2 += "C:\\Users\\tyler\\Source\\Repos\\ryanjakegarcia\\Character-Generator\\Character Generator\\ClassInfo.txt";
            string path2 = Directory.GetCurrentDirectory();
            //due to some wierd ass build shit somehow the builds for the gui and the tests are not even the same distance from the classinfo.txt one is 3 away one is 4 away

            while (path2[path2.Length-1] != 'r')
            {
                path2 = Directory.GetParent(path2).ToString();
            }

            path2 += "\\Character Generator\\ClassInfo.txt";


            using (System.IO.StreamReader file = new System.IO.StreamReader(path2))
            {
                string line;
                while (!file.EndOfStream)
                {
                    ClassInfo classInfo = new ClassInfo();
                    line = file.ReadLine();
                    if (line.Equals("{"))
                    {
                        classInfo.ClassName = file.ReadLine();
                        line = file.ReadLine();
                        while (line != "}")
                        {
                            switch (line)
                            {
                                case "Race":
                                    line = file.ReadLine();
                                    List<string> raceList = line.Split().ToList();
                                    classInfo.Races = raceList;
                                    break;
                                default:
                                    string[] statSplit;
                                    statSplit = line.Split();
                                    classInfo.StatReqs.Add(statSplit[0], statSplit[1]);
                                    break;
                            }

                            line = file.ReadLine();
                        }
                        classReqs.Add(classInfo.ClassName, classInfo);
                    }
                }
            }
        }

        /// <summary>
        /// Wrapper class for storing and accessing parsed information.
        /// </summary>
        protected class ClassInfo
        {
            protected string className;
            protected List<string> races;
            protected Dictionary<string, string> statReqs;

            public ClassInfo()
            {
                races = new List<string>();
                statReqs = new Dictionary<string, string>();
            }

            public string ClassName
            {
                get { return className; }
                set { className = value; }
            }

            public Dictionary<string, string> StatReqs
            {
                get { return statReqs; }
                set { statReqs = value; }
            }

            public List<string> Races
            {
                get { return races; }
                set { races = value; }
            }
        }
    }

}
