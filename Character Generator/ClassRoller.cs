using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Character_Generator
{
    public class ClassRoller
    {
        private string race;
        private int[] stats;
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





        public ClassRoller(string _race, int[] _stats)
        {



            //Base Race    //Weight                                                                
            FighterChance   = 35; FighterThreshhold = FighterChance + 0; //This feels needless complicated/bloated
            RangerChance    = 20; RangerThreshhold = RangerChance + FighterThreshhold;
            PaladinChance   = 5; PaladinThreshhold = PaladinChance + RangerThreshhold;
            WizardChance    = 10; WizardThreshhold = WizardChance + PaladinThreshhold;
            ClericChance    = 15; ClericThreshhold = ClericChance + WizardThreshhold;
            ThiefChance     = 20; ThiefThreshhold = ThiefChance + ClericThreshhold;
            BardChance      = 15; BardThreshhold = BardChance + ThiefThreshhold;


            classReqs = new Dictionary<string, ClassInfo>();
            race = _race;
            stats = _stats;
            readReqs();
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
        private bool validstats(string classname)
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
        public string RollClass()
        {
            //creaiting a new Random object
            Random rng = new Random();
            // rolled class container
            String RolledClass = "";
            //Loop flag
            bool done = false;
            while (!done)
            {
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
                        }
                        break;
                    case int n when n <= RangerThreshhold:
                        {

                            RolledClass = "Ranger";
                            //tests to see if we can be a Ranger
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                        }
                        break;
                    case int n when n <= PaladinThreshhold:
                        {
                            RolledClass = "Paladin";
                            //tests to see if we can be a Paladin
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                        }
                        break;
                    case int n when n <= WizardThreshhold:
                        {
                            RolledClass = "Wizard";
                            //tests to see if we can be a wizard
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                        }
                        break;
                    case int n when n <= ClericThreshhold:
                        {
                            RolledClass = "Cleric";
                            //tests to see if we can be a cleric
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                        }
                        break;
                    case int n when n <= ThiefThreshhold:
                        {
                            RolledClass = "Thief";
                            //tests to see if we can be a Thief
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                        }
                        break;
                    case int n when n <= BardThreshhold:
                        {
                            RolledClass = "Bard";
                            //tests to see if we can be a Bard
                            if (validrace(RolledClass) && validstats(RolledClass))
                            { return RolledClass; }
                        }
                        break;
                    default:
                        done = true;
                        return "Ultra instinct Log"; //Funny
                        break;
                }
            }
            return "log";
        }

        /// <summary>
        /// Parses a file with classes and their requirements/restrictions.
        /// Stores parsed information for use during generation.
        /// </summary>
        private void readReqs()
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader("..\\..\\..\\..\\Character Generator\\ClassInfo.txt"))
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
