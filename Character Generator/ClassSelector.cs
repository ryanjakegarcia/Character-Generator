using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Generator
{
    public class ClassSelector
    {


        string SpecificClass = "fighter";
        bool elite = false;
        int[] stats;

        public ClassSelector() 
        {
        }

        public void SetClass(string classname) { SpecificClass = classname; }
        public void setElite(bool iselite) { elite = iselite; }




        public void RollStatsforClass(string classname, string rollingmethod, bool iselite) 
        {
            ClassRoller croller;
            AutoRoller aroller = new AutoRoller(rollingmethod);
            SpecificClass= classname;



            do
            {
                //need stats to check if they are correct
                aroller.Roll();
                croller = new ClassRoller("Human", aroller.getStats());
            } while (!croller.validstats(classname)); 
  
            stats = croller.GetStats();

            // check list out stat requirements 
            // roll stats
            // see if it checks out roll again


        }
    }
}
