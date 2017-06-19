namespace MindSqueezer
{
    public static class Messages
    {
        public const string EntryMsg = "\n           Welcome!\n\nPrepare your mind for squeezing!"; 

        //Menus and sub menus content
        public const string MainMenu = "Choose menu option:" +
                                       "\n       Start" +
                                       "\n     Game Rules" +
                                       "\n     High Scores" +
                                       "\n      Credits" +
                                       "\n       Quit";

        public const string Credits = "This game was made by:" +
                                      "\n\nDimana Dimitrova" +
                                      "\n\nKonstantin Lupov" +
                                      "\n\nMartin Dachev" +
                                      "\n\nVasko Viktorov"; 

        public const string GameRules = "Question types:" +
                                        "\n\n1.ColorQuestion: \n\n" + ColorQuestionRules +
                                        "\n\n2.FindWordInMatrix: \n\n" + FindWordInMatrixRules +
                                        "\n\n3.MathMatrixQuestion: \n\n" + MathMatrixQuestionRules + 
                                        "\n\n4.ReadSentenceInMatrixQuestion: \n\n" + ReadSentenceInMatrixQuestionRules;       

        //High scores menu layout
        public const string HighScores = "\n            High Scores\n";

        public const string HighScoresPanel = "|Place|Score|         Name        |";

        public const string LongLine = "-----------------------------------";

        //Answer responses

        public const string RightInput = "Correct!";

        public const string TimeUp = "Time's up!";

        //Questions
        public const string QuestionTypeColorGuess = "What color is the word?";

        public const string MathMatrixEquationCoordinates = "Locate the coordinates of X in the equation:";

        public const string QuestionTypeFindWordInMatrix = "Find four or five letter word: ";

        public const string QuestionTypeReadSentenceInMatrix = "Unwrap the sentence: ";

        //After game responses
        public const string EndMsg = "Wrong answer! - Game Over";
        
        public const string EnterTopThree = "Congratulations! You've made it to the top 3!";

        public const string WriteYourName = "Write your name (20 chars max): ";

        public const string EmptyName = "Name cannot be empty!";

        public const string FindWordInMatrixRules = 
            @"In this game you are given a rectangle, filled with letters and your task is to 
find the hidden word of four or five letters. The word can be placed horizontally, 
vertically or diagonally, in any direction.";

        public const string MathMatrixQuestionRules =
            @"Here we will test your math skills. You will be given a task where you have to find 
the coordinates of unknown X in rectangle, filled with digits. The answer should be 
in ""row column"" format, where rows are from A to F, and columns are from 1 to 6.";

        public const string ReadSentenceInMatrixQuestionRules =
            @"This time you have a rectangle, filled with simple sentence. The sentence can start 
from each of the four corners in zig zag direction. Your task is to unwrap it. 
Be quick, time is limited!";

        public const string ColorQuestionRules =
            @"Here you will have to guess the color of the given word. Be careful, it can be tricky.";

    }
}
