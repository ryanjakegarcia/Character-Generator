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
        }

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
