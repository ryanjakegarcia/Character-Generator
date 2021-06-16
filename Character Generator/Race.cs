using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Generator
{
    //The purpose of this race class is to assign a race based off of a characters race
    //Assumption: we have an array of 7 integers
    // We then apply a race to a given set of numbers and modify the stats.
    public class Race
    {
        //Base race weights
        private int HumanChance;    private int HumanThreshhold;
        private int DwarfChance;    private int DwarfThreshhold;
        private int ElfChance;      private int ElfThreshhold;  
        private int HalfingChance;  private int HalfingThreshhold;
        private int GnomeChance;    private int GnomeThreshhold;
        private int Half_ElfChance; private int Half_ElfThreshhold;

        //in case we wanted to expand we can generate a random number from the total

        public Race() {
            
            //Base Race     //Chance                                                                  //Threshhold
             HumanChance    = 50;             HumanThreshhold = HumanChance + 0;                      //50
             DwarfChance    = 15;             DwarfThreshhold = DwarfChance + HumanThreshhold;        //65
             ElfChance      = 15;             ElfThreshhold = ElfChance + DwarfThreshhold;            //80
             HalfingChance  = 10;             HalfingThreshhold = HalfingChance + ElfThreshhold;      //90
             GnomeChance    = 5;              GnomeThreshhold = GnomeChance + HalfingThreshhold;      //95
             Half_ElfChance = 5;              Half_ElfThreshhold = Half_ElfChance + GnomeThreshhold;  //100
        }

        public void RaceRoll() 
        {
            string race;
            Random rng = new Random();
            int roll = rng.Next(101);

            //massive evaluation statement

            switch (roll) 
            { 
                case int n when n <= HumanThreshhold:
                    { race = "Human"; }
                    break;
                case int n when n <= DwarfThreshhold:
                    { race = "Dwarf"; }
                    break;
                case int n when n <= ElfThreshhold:
                    { race = "Elf"; }
                    break;
                case int n when n <= HalfingThreshhold:
                    { race = "Halfing"; }
                    break;
                case int n when n <= GnomeThreshhold:
                    { race = "Gnome"; }
                    break;
                case int n when n <= Half_ElfThreshhold:
                    { race = "Half-Elf"; }
                    break;
                default:
                    Console.WriteLine($"Bad Things");
                    break;
            }
        }
    }
}
