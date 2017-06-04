namespace MindSqueeze.App
{
    public static class Score
    {
        public static int Add(int totalScore)
        {
            return totalScore + 1;
        }

        public static bool CheckIfTopScore(int TotalScore)
        {
            int[] PreviousScore = new int[3]; //TO DO check previousScore File
            if (TotalScore > PreviousScore[2]) // This shoud be "for" or "while" that checks if the score
                                               // is better then the first, second, third and rewrites 
                                               //the file if needed
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
