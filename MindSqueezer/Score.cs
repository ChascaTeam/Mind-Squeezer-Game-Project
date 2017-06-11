using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            string path ="../../Imports/HighScores.txt";

            if (File.Exists(path))
            {
                string[] HighScores = File.ReadAllLines(path);
                
                if (HighScores.Length < 3)
                {
                    while (HighScores.Length != 3)
                    {                       
                        File.AppendAllLines(path, new string[] { "0 dummy"});
                        HighScores = File.ReadAllLines(path);
                    }
                    
                }               
               
                for (int line = HighScores.Length - 1; line >= 0; line--)
                {
                    var input = HighScores[line].Split();
                    
                        int score = int.Parse(input[0]);
                        if (score < totalScore)
                        {
                            return true;
                        }                    
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
            string name = Reader.ReadLine();
            string[] highScores = File.ReadAllLines(path);
            string[] newHighScores= new string[]
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
    }
}
