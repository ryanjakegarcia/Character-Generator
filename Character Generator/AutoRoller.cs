using System;

namespace Character_Generator
{
    public class AutoRoller
    {
        string option;
        int[] stats;

        AutoRoller(string _option)
        {
            option = _option;
            stats = new int[7];
        }

        void Roll()
        {
            switch (option)
            {
                case "4d6d1":
                    RollHeroic();
                    break;
                case "3d6d2":
                    RollTwice();
                    break;
                default:
                    RollLine();
                    break;
            }
        }

        private int[] RollLine()
        {
            Random rng = new Random();
            int sum = 0;
            int[] rolled = new int[7];
            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 3; j++)
                    sum += rng.Next(1, 7);

                rolled[i] = sum;
            }

            return rolled;
        }

        private void RollTwice()
        {
            int[] rolled = new int[14];
            for(int i = 0; i < 2; i++)
            {
                int[] set = RollLine();
                if(i < 1)
                {
                    for (int j = 0; j < 7; j++)
                        rolled[j] = set[j];
                }
                else
                {
                    for (int j = 6; j < 14; j++)
                        rolled[j] = set[j];
                }
            }
        }

        private void RollHeroic()
        {
            throw new NotImplementedException();
        }

        public int[] getStats()
        {
            return stats;
        }
    }
}
