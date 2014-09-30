using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScoreKeeper
{
    class UserInterface
    {
        const int scoreStart = 4;

        public static void Write(string message)
        {
            ClearLine(Console.WindowHeight-3);
            Console.WriteLine(message);
        }

        public static int InputInt(string message)
        {
            Write(message);
            string input = "";
            int output;
            while (!Int32.TryParse(input,out output) || output < 0)
            {
                ClearLine(Console.WindowHeight-2);
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
                ClearLine(Console.WindowHeight-2);
                input = Console.ReadLine();
            }
            return input;
        }  
        
        private static void ClearLine(int line)
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
            int height = 8+(players.Count*5);
            Console.WindowHeight = height;
            Title();                
            ClearLine(scoreStart);
            foreach (var player in players)
            {
                Console.SetCursorPosition(Console.BufferWidth / 2 - player.Name.Length / 2, Console.CursorTop);
                Console.WriteLine(player.Name);
                new DisplayScore(frame ,player);
                Console.WriteLine("");
            }
        }
    }
}
