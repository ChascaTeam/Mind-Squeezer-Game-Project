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

        public static int GetRandomNumber(int minNumber, int maxNumber)
        {
            return random.Next(minNumber, maxNumber);
        }

        public static int GetRandomNumber(int minNumber, int maxNumber, int numberToOmit)
        {
            int randomNum;

            do
            {
                randomNum = random.Next(maxNumber);
            } while (randomNum == numberToOmit);

            return randomNum;
        }
    }
}
