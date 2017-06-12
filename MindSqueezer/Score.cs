using System;
using System.IO;
using System.Linq;
using System.Text;


namespace MindSqueezer
{
    public static class Score
    {
        public static int Add(int totalScore)
        {
            return totalScore + 1;
        }

        public static bool CheckIfTopScore(int totalScore)
        {
            string path = "../../Imports/HighScores.txt";

            if (File.Exists(path))
            {
                string[] HighScores = File.ReadAllLines(path);

                if (HighScores.Length < 3)
                {
                    while (HighScores.Length != 3)
                    {
                        File.AppendAllLines(path, new string[] { "0 dummy" });
                        HighScores = File.ReadAllLines(path);
                    }

                }

                int score = int.Parse(HighScores[2].Split()[0]);

                if (score < totalScore)
                {
                    return true;
                }
            }
            else
            {
                File.AppendAllLines(path, new string[] { "0 dummy", "0 dummy", "0 dummy" });
                return true;

            }
            return false;
        }

        public static void IsInTheTop(int totalScore)
        {
            string path = "../../Imports/HighScores.txt";
            int score = totalScore;
            string name = ReadNameCharLimit();
            string[] highScores = File.ReadAllLines(path);
            string[] newHighScores = new string[]
           {
               highScores[0],
               highScores[1],
               highScores[2],
               $"{score} {name}",
           };
            
            Array.Sort(newHighScores);
            Array.Reverse(newHighScores);
            File.WriteAllLines(path, newHighScores.Take(3));
        }

        private static string ReadNameCharLimit()
        {
            StringBuilder input = new StringBuilder();
            int i, count = 0;

            while ((i = Reader.Read()) != 13)   // 13 = enter key (or other breaking condition)
            {
                if (++count > 20) break;
               input.Append((char)i);
            }

            return input.ToString();
        }

        public static void CheckHighScores()
        {
            string path = "../../Imports/HighScores.txt";

            if (File.Exists(path))
            {
                string[] HighScores = File.ReadAllLines(path);

                if (HighScores.Length < 3)
                {
                    while (HighScores.Length != 3)
                    {
                        File.AppendAllLines(path, new string[] { "0 dummy" });
                        HighScores = File.ReadAllLines(path);
                    }

                }
                for (int i = 0; i < HighScores.Length; i++)
                {
                    var player = HighScores[i].Split();
                   
                    Writer.WriteMessageOnNewLine($"|{i+1,5}|{player[0],5}|{player[1],-20}|");
                }
                            
            }
            else
            {
                File.AppendAllLines(path, new string[] { "0 dummy", "0 dummy", "0 dummy" });
                string[] HighScores = File.ReadAllLines(path);

                for (int i = 0; i < HighScores.Length; i++)
                {
                    var player = HighScores[i].Split();

                    Writer.WriteMessageOnNewLine($"|{i + 1,5}|{player[0],5}|{player[1],-20}|");
                }

            }
        }
    }
}
