using System;

namespace MindSqueeze.App
{
    public static class RandomGenerator
    {
        private static Random random = new Random();

        public static int GetRandomNumber(int maxNumber)
        {
            return random.Next(maxNumber);
        }

        public static int GetRandomNumber(int maxNumber, int numberToOmit)
        {
            int randomNum = random.Next(maxNumber);
            while (randomNum == numberToOmit)
            {
                randomNum = random.Next(maxNumber);
            }
            return randomNum;
        }
    }
}
