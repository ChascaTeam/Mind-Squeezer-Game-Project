namespace MindSqueezer
{
    public static class Messages
    {
        public const string EntryMsg = "\n           Welcome!\n\nPrepare your mind for squeezing!";

        //Menus and sub menus content
        public const string MainMenu = "Choose menu option:" +
                                       "\n       Start" +
                                       "\n      Tutorial" +
                                       "\n     Game Rules" +
                                       "\n     High Scores" +
                                       "\n      Credits" +
                                       "\n       Quit";

        public const string Credits = "\n\nThis game was made by:" +
                                      "\n\nDimana Dimitrova - FindWordInMatrix Game" +
                                      "\n\nKonstantin Lupov - MathMatrix Game" +
                                      "\n\nMartin Dachev - ColorQuestion Game" +
                                      "\n\nVasko Viktorov - ReadSentenceInMatrix Game";

        public const string GameRules = "Question types:" +
                                        "\n\n1.ColorQuestion: \n\n" + ColorQuestionRules +
                                        "\n\n2.FindWordInMatrix: \n\n" + FindWordInMatrixRules +
                                        "\n\n3.MathMatrixQuestion: \n\n" + MathMatrixQuestionRules +
                                        "\n\n4.ReadSentenceInMatrixQuestion: \n\n" + ReadSentenceInMatrixQuestionRules;

        public const string ReturnBtn = "\n Return <";

        //High scores menu layout
        public const string HighScoresPanel = "           |Place|Score|         Name        |";

        public const string LongLine = "           -----------------------------------";

        //Tutorial messages
        public const string TutorialEncourigingResponce = "First try to figure it yourself!";

        public const string TutorialBtnInfoSpace = "\nPress space to see the answer or any key to continue...";

        public const string TutorialBtnInfoAnyKey = "\n\nPress any key to continue...";

        public const string MathMatrixAdditionalInfo = "Any of the below answers is correct.\n";

        //Answer responses
        public const string RightInput = "Correct!";

        public const string TimeUp = "                  Time's up!";

        public const string LevelUp = "Level up!";

        public const string CurrLvl = " Current Level: ";

        //Questions
        public const string QuestionTypeColorGuess = "What color is the word?";

        public const string MathMatrixEquationCoordinates = "Locate the coordinates of X in the equation:";

        public const string QuestionTypeFindWordInMatrix = "Find four or five letter word: ";

        public const string QuestionTypeReadSentenceInMatrix = "Unwrap the sentence: ";

        //After game responses
        public const string EndMsg = "Wrong answer! - Game Over";

        public const string EnterTopThree = "Congratulations! You've made it to the top 3!";

        public const string WriteYourName = "Write your name (20 chars max, no spaces allowed): ";

        public const string EmptyName = "Invalid name!";

        //Game Rules
        public const string Rules =
                "Rules of play:\n\n" +
                "This is a small game with \"question-answer\"\n" +
                "style of play, made tо improve the player's\n" +
                "cognitive abilities.\n\n" +
                "The game will ask you questions and will\n" +
                "wait current amount of time. If you don't answer\n" +
                "in the given time, or you answer wrong the game is over,\n" +
                "but if you answer correct the game will reward you\n" +
                "with points and after few correct answers - with levels!\n\n" +
                "But be careful! Every time you level up the time goes down.\n\n" +
                "Also note that the answers are case insensitive.\n";

        public const string FindWordInMatrixRules =
            "In this game you are given a rectangle, filled\n" +
            "with letters and your task is to find the hidden\n" +
            "word of four or five letters. The word can be placed\n" +
            "horizontally, vertically or diagonally, in any direction.";

        public const string MathMatrixQuestionRules =
            "Here we will test your math skills. You will\n" +
            "be given a task where you have to find the\n" +
            "coordinates of unknown X in rectangle, filled\n" +
            "with digits. The answer should be in \"row column\"\n" +
            "format, where rows are from A to F, and columns\n" +
            "are from 1 to 6.";

        public const string ReadSentenceInMatrixQuestionRules =
            "This time you have a rectangle, filledwith\n" +
            "simple sentence. The sentence can start from\n" +
            "each of the four corners in zig zag direction.\n" +
            "Your task is to unwrap it. Be quick, time is limited!";

        public const string ColorQuestionRules =
            "Here you will have to guess the color of\nthe given word. Be careful, it can be tricky.";

        //Art
        public const string TimeUpClock = @"
                        .-'`'-.
              ,-'`'.   '._     \     ______
             /    .'  ___ `-._  |    \ .-'`
            |   .' ,-' __ `'/.`.'  ___\\
    ______  \ .' \',-' 12 '-.  '.  `-._ \
    '`-. /   ` / / 11  |   1 `.  `.    '.\
       //___  . '10    |     2 \  ;
      / _.-'  | |      O      3|  |  ______
     /.'      | |9      \      '  '  '`-. /
       ______ '  \ 8     \   4/  /      //___
       \ .-'`  '. `'.7  6  5.'  '      / _.-'
     ___\\       `. _ `'''` _.'\\-.   /.'
     `-._ \       .//`''--''   (   )
         '.\     (   )          '-`
                  `-' ";

        public const string StartLogo = @"
            _.-'`'-._
         .-'    _    '-.
          `-.__  `\_.-'
            |  `-``\|
            `-.....-A
                    #
                    #";

        public const string GameOverArt = @"
   _____                         ____                 
 / ____|                       / __ \                
| |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
| | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
| |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
 \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   ";

        public const string HighScoresArt = @"
 _   _ _       _       _____                         
| | | (_)     | |     /  ___|                        
| |_| |_  __ _| |__   \ `--.  ___ ___  _ __ ___  ___ 
|  _  | |/ _` | '_ \   `--. \/ __/ _ \| '__/ _ \/ __|
| | | | | (_| | | | | /\__/ / (_| (_) | | |  __/\__ \
\_| |_/_|\__, |_| |_| \____/ \___\___/|_|  \___||___/
          __/ |                                      
         |___/   ";

        public const string TutorialArt = @"
       _____     _             _       _        
   _  |_   _|   | |           (_)     | |  _    
  (_)   | |_   _| |_ ___  _ __ _  __ _| | (_)   
        | | | | | __/ _ \| '__| |/ _` | |       
 _ _    | | |_| | || (_) | |  | | (_| | |  _ _  
(_|_)   \_/\__,_|\__\___/|_|  |_|\__,_|_| (_|_) 
                                                ";

        public const string GameRulesArt = @"
       _____                       ______      _                  
   _  |  __ \                      | ___ \    | |            _    
  (_) | |  \/ __ _ _ __ ___   ___  | |_/ /   _| | ___  ___  (_)   
      | | __ / _` | '_ ` _ \ / _ \ |    / | | | |/ _ \/ __|       
 _ _  | |_\ \ (_| | | | | | |  __/ | |\ \ |_| | |  __/\__ \  _ _  
(_|_)  \____/\__,_|_| |_| |_|\___| \_| \_\__,_|_|\___||___/ (_|_) ";

        public const string CreditsArt = @"
       _____              _ _ _              
   _  /  __ \            | (_) |        _    
  (_) | /  \/_ __ ___  __| |_| |_ ___  (_)   
      | |   | '__/ _ \/ _` | | __/ __|       
 _ _  | \__/\ | |  __/ (_| | | |_\__ \  _ _  
(_|_)  \____/_|  \___|\__,_|_|\__|___/ (_|_) ";
    }
}
