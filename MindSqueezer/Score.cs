using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace MindSqueezer
{
    public static class Score
    {
        public static int Add(int totalScore)
        {
            return totalScore +1;
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
                string[] HighScores = File.ReadAllLines(path);

                int score = int.Parse(HighScores[2].Split()[0]);
                if (score < totalScore)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }
       
        public static void IsInTheTop(int totalScore)
        {
            string path = "../../Imports/HighScores.txt";
            int score = totalScore;
            string name = Reader.ReadNameCharLimit(20);
            string[] highScores = File.ReadAllLines(path);

            PlayerScores[] arr = new PlayerScores[4];
            PlayerScores holder = new PlayerScores();
            holder.Name = name;
            holder.Score = score;
            arr[3] = holder;

            for (int i = 0; i < highScores.Length; i++)
            {
                    holder = new PlayerScores();
                    var result = highScores[i].Split().ToArray();                   
                    holder.Name = result[1];
                    holder.Score = int.Parse(result[0]);
                    arr[i]=holder;
            }

           arr = arr.OrderByDescending(x => x.Score).ToArray();

            string[] newHighScores = new string[]
           {
               arr[0].Score+" "+arr[0].Name,
               arr[1].Score+" "+arr[1].Name,
               arr[2].Score+" "+arr[2].Name,
               arr[3].Score+" "+arr[3].Name
           };
                        
            File.WriteAllLines(path, newHighScores.Take(3));
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
                   
                    Writer.WriteMessageOnNewLine($"|{i+1,3}  |{player[0],4} | {player[1],-20}|");
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

        public class PlayerScores
        {
            public int Score { get; set; }
            public string Name { get; set; }
        }
    }
}
