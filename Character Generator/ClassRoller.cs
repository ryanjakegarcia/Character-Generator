
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Character_Generator
{
    public class ClassRoller
    {   private string CharacterClass;
        private string race;
        private int[] stats;
        private Dictionary<string, ClassInfo> classReqs;

        //class weights
        //Base race weights
        private int FighterChance;  private int FighterThreshhold;
        private int RangerChance;   private int RangerThreshhold;
        private int PaladinChance;  private int PaladinThreshhold;
        private int WizardChance;   private int WizardThreshhold;
        private int ClericChance;   private int ClericThreshhold;
        private int ThiefChance;    private int ThiefThreshhold;
        private int BardChance;     private int BardThreshhold;


        ClassRoller()
            
            {

            //Base Race     //Weight                                                                
            FighterChance   = 35;       FighterThreshhold   = FighterChance + 0;                      
            RangerChance    = 20;       RangerThreshhold    = RangerChance  + FighterThreshhold;        
            PaladinChance   = 5;        PaladinThreshhold   = PaladinChance + RangerThreshhold;            
            WizardChance    = 10;       WizardThreshhold    = WizardChance  + PaladinThreshhold;      
            ClericChance    = 15;        ClericThreshhold    = ClericChance  + WizardThreshhold;      
            ThiefChance     = 20;       ThiefThreshhold     = ThiefChance   + ClericThreshhold;  
            BardChance      = 15;       BardThreshhold        = BardChance + ThiefThreshhold;
        }


        public ClassRoller(string _race, int[] _stats)
        {
            classReqs = new Dictionary<string, ClassInfo>();
            race = _race;
            stats = _stats;
            readReqs();
        }

        public string RollClass()
        {
            throw new NotImplementedException();


            
            Random rng = new Random();
            bool done = false;
            while(!done)
            { 
            int roll = rng.Next(BardThreshhold + 1);

                //massive evaluation statement

                switch (roll)
                {
                    case int n when n <= FighterThreshhold:
                        {
                            //tests to see if we can be a fighter
                            if (stats[0] >= 9)
                            {
                                return "Fighter";
                            }
                        }
                        
                        break;
                    case int n when n <= RangerThreshhold:
                        { }
                        break;
                    case int n when n <= PaladinThreshhold:
                        { }
                        break;
                    case int n when n <= WizardThreshhold:
                        { }
                        break;
                    case int n when n <= ClericThreshhold:
                        { }
                        break;
                    case int n when n <= ThiefThreshhold:
                        { }
                        break;
                    case int n when n <= BardThreshhold:
                    default:
                        Console.WriteLine($"Bad class Things");
                        break;
                }
            }





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
                        while(line != "}")
                        {
                            switch (line)
                            {
                                case "Race":
                                    line = file.ReadLine();
                                    List<string> raceList = line.Split().ToList();
                                    raceList.RemoveAt(0);
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
