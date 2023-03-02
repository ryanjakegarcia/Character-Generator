using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Generator
{
    //I think ClassSelecter will be totally removed
    public class ClassSelector
    {
        string SpecificClass = "fighter";
      
        int[] stats;

        public ClassSelector() 
        {
        }

        public void SetClass(string classname) { SpecificClass = classname; }

      

        public int[] getStats() { return stats; }


        public void RollStatsforClass(string classname, string rollingmethod) 
        {
            ClassRoller cRoller;
            AutoRoller aRoller = new AutoRoller(rollingmethod);
            SpecificClass= classname;

            do
            {
                //need stats to check if they are correct
                aRoller.Roll();
                cRoller = new ClassRoller("Human", aRoller.getStats());
            } while (!cRoller.validstats(classname)); 
  
            stats = cRoller.GetStats();

            // check list out stat requirements 
            // roll stats
            // see if it checks out roll again
        }
    }
}
