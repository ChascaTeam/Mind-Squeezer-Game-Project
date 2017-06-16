using System;

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
                                        "\n\n1.ColorQuestion:..." +
                                        "\n\n2.FindWordInMatrix:..." +
                                        "\n\n3.MathMatrixQuestion:..." +
                                        "\n\n4.ReadSentenceInMatrixQuestion:..."; //TODO        

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

       




    }
}
