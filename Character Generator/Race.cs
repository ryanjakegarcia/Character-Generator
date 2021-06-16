using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Generator
{
    //The purpose of this race class is to assign a race based off of a characters race
    //Assumption: we have an array of 7 integers
    // We then apply a race to a given set of numbers and modify the stats.
    public class  Race
    {
        //Race weights


        //in case we wanted to expand we can generate a random number from the total



        //Base Ranges
        int[] HumanChance    = { 1, 50 };
        int[] DwarfeChance   = { 51, 65 };
        int[] ElfChance      = { 66, 80 };
        int[] HalfingChance  = { 81, 90 };
        int[] GnomeChance    = { 91, 95 };
        int[] Half_ElfChance = { 96, 100};





        public void RaceRoll() 
        {
            string race;
            Random rng = new Random();
            int roll = rng.Next(101);

            //massive evaluation statement

            if (roll < 51) 
            { race = "Human"; }
            else if (roll < 66)
            { race = "Dwarf"; }
            else if (roll < 81)
            { race = "elf"; }
            else if (roll < 91)
            { race = "Halfing"; }
            else if (roll < 96)
            { race = "Gnome"; }
     
            else 
            { race = "Half-Elf"; }
            Console.WriteLine("You are a dirty" + race);








        }

    }
}
