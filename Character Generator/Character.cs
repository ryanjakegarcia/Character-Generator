using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Generator
{
    public class Character
    {
        private int[] stats = new int[7];
        private string className;
        private bool warriorFlag;
        private int age;
        private char sex;
        private string handed;
        private int hitPoints;
        private List<string> languages;
        private List<string> nwProfs; //Non-weapon proficiencies
        private List<string> wProfs; //Weapon proficiencies


        public Character(int[] _stats, string _className, bool _warriorFlag, int _age = 1, char _sex = 'n', string _handed = "Right", int _hitPoints = 1, List<string> _languages = null)
        {
            stats = _stats;
            className = _className;
            warriorFlag = _warriorFlag;
            age = _age;
            sex = _sex;
            handed = _handed;
            hitPoints = _hitPoints;
            languages = _languages ?? new List<string>(new string[] { "Common" }); //Checks if _languages is null, if null defaults to just Common.
        }
    }
}
