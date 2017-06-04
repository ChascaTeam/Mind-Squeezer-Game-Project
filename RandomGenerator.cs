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
    }
}
