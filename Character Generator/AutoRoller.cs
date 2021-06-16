using System;

namespace Character_Generator
{
    public class AutoRoller
    {
        string option;
        int[] stats;

        public AutoRoller(string _option)
        {
            option = _option;
            stats = new int[7];
        }

        public AutoRoller()
        {
            stats = new int[7];
            option = "";
        }

        /// <summary>
        /// Used for changing the rolling method of this AutoRoller and then Rolling with that new method.
        /// </summary>
        /// <param name="_option"></param>
        public void ReRoll(string _option)
        {
            option = _option;
            Roll();
        }

        /// <summary>
        /// Generalized rolling method to apply the current AutoRoller option.
        /// </summary>
        public void Roll()
        {
            switch (option)
            {
                case "4d6d1":
                    stats = Roll4d6d1();
                    break;
                case "3d6r2":
                    stats = RollTwice();
                    break;
                default:
                    stats = Roll3d6();
                    break;
            }
        }

        /// <summary>
        /// Generates 7 stats by rolling 3d6 once for each stat and then returns the 7 stats.
        /// </summary>
        /// <returns></returns>
        private int[] Roll3d6()
        {
            Random rng = new Random();
            int sum = 0;
            int[] rolled = new int[7];
            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 3; j++)
                    sum += rng.Next(1, 7);

                rolled[i] = sum;
                sum = 0;
            }

            return rolled;
        }

        /// <summary>
        /// Generates 14 stats and then returns the highest 7 stats.
        /// </summary>
        /// <returns></returns>
        private int[] RollTwice()
        {
            int[] rolled = new int[14];
            for (int i = 0; i < 2; i++) //Iterate 2 rolls of 3d6
            {
                int[] set = Roll3d6();
                if (i < 1) //First roll
                {
                    for (int j = 0; j < 7; j++)
                        rolled[j] = set[j];
                }
                else //Second roll
                {
                    for (int j = 7; j < 14; j++)
                        rolled[j] = set[j - 7];
                }
            }

            sort(ref rolled); //Sort the rolls from highest to lowest.

            int[] highest = new int[7];
            for (int i = 0; i < 7; i++)
            {
                highest[i] = rolled[i];
            }

            return highest;
        }

        /// <summary>
        /// Generates 7 stats by rolling 4d6 and then dropping the lowest number rolled for each individual stat.
        /// Returns the 7 stats rolled.
        /// </summary>
        /// <returns></returns>
        private int[] Roll4d6d1()
        {
            Random rng = new Random();
            int[] dice = new int[4];
            int num = 0;
            int[] rolled = new int[7];

            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    dice[j] = rng.Next(1, 7);

                    if(j > 0)
                    {
                        if(dice[j - 1] < dice[j])
                        {
                            num = dice[j];
                            dice[j] = dice[j - 1];
                            dice[j - 1] = num;
                        }
                    }
                }

                rolled[i] = dice[0] + dice[1] + dice[2];
            }

            return rolled;
        }

        /// <summary>
        /// Getter used to retrieve the most recently rolled stats by this AutoRoller.
        /// </summary>
        /// <returns></returns>
        public int[] getStats()
        {
            return stats;
        }

        /// <summary>
        /// Helper sorting method that uses Insertion sort from Highest to Lowest.
        /// Insertion sort performs the fastest on small arrays.
        /// </summary>
        /// <param name="rolled"></param>
        private void sort(ref int[] rolled)
        {
            for(int i = 1; i < rolled.Length; ++i)
            {
                int key = rolled[i];
                int j = i - 1;

                while (j >= 0 && rolled[j] < key)
                {
                    rolled[j + 1] = rolled[j];
                    j = j - 1;
                }
                rolled[j + 1] = key;
            }
        }
    }
}
