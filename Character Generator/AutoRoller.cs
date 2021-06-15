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

        public void ReRoll(string _option)
        {
            option = _option;
            Roll();
        }

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

        private int[] RollTwice()
        {
            int[] rolled = new int[14];
            for (int i = 0; i < 2; i++)
            {
                int[] set = Roll3d6();
                if (i < 1)
                {
                    for (int j = 0; j < 7; j++)
                        rolled[j] = set[j];
                }
                else
                {
                    for (int j = 7; j < 14; j++)
                        rolled[j] = set[j - 7];
                }
            }

            sort(ref rolled);

            int[] highest = new int[7];
            for (int i = 0; i < 7; i++)
            {
                highest[i] = rolled[i];
            }

            return highest;
        }

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

        public int[] getStats()
        {
            return stats;
        }

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
