using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScoreKeeper
{
    class UserInterface
    {
        const int outputLine = 4;
        const int inputLine = 5;
        const int scoreStart = 6;

        public static void Write(string message)
        {
            ClearLine(outputLine);
            Console.WriteLine(message);
        }

        public static int InputInt(string message)
        {
            Write(message);
            string input = "";
            int output;
            while (!Int32.TryParse(input,out output) || output < 0)
            {
                ClearLine(inputLine);
                input = Console.ReadLine();
            }
            return output;
        }

        public static string InputString(string message)
        {
            Write(message);
            string input = "";
            while (String.IsNullOrWhiteSpace(input))
            {
                ClearLine(inputLine);
                input = Console.ReadLine();
            }
            return input;
        }  
        
        internal static void ClearLine(int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, line);
        }

        public void Title()
        {
            Console.Clear();
            string titleText = "Bowling Score Keeper";

            Console.Write(new String('*', Console.BufferWidth));
            Console.Write(new String('*', (Console.BufferWidth/2)-titleText.Length/2));
            Console.Write(titleText);
            Console.Write(new String('*', (Console.BufferWidth/2)-titleText.Length/2));
            Console.Write(new String('*', Console.BufferWidth));
        }



        public void DisplayScores(List<Player> players, int frame)
        {
            Title();                
            ClearLine(scoreStart);
            foreach (var player in players)
            {
                new DisplayScore(frame ,player);
                Console.WriteLine("");
            }
        }
    }
}
