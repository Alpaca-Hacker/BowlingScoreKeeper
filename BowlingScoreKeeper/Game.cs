using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScoreKeeper
{
    public class Game
    {
        List<Player> players = new List<Player>();
        UserInterface ui = new UserInterface();

        public void Run()
        {
            ui.Title();
            int input = 0;
            while (input < 1)
            {
                input = UserInterface.InputInt("How many players?");
            }

            for (int i = 1; i <= input; i++)
            {
                string name = UserInterface.InputString("Player " + i + " Name?");
                var player = new Player();
                player.Name = name;
                players.Add(player);
            }

            for (int frame = 1; frame < 11; frame++)
            {
                foreach (var player in players)
                {
                    ui.DisplayScores(players,frame);
                    if (frame < 10)
                    {
                        input = InputScore(frame, player, 10, 1);
                        if (input != 10)
                        {
                            input = InputScore(frame, player, 10 - input, 2);
                        }
                    }
                    else
                    {
                        int tenthFrameScore = 0;
                        bool twoMoreBalls = false;
                        input = InputScore(10, player,10, 1);
                        if (input == 10)
                        {
                            twoMoreBalls = true;
                        }
                        else
                        {
                            tenthFrameScore = input;
                        }
                        input = InputScore(10, player, 10-tenthFrameScore, 2);
                        if (input+tenthFrameScore == 10 || twoMoreBalls)
                        {
                            input = InputScore(10, player, 10, 3);
                        }

                    }
                }

            }
            var sortedPlayers = players.OrderByDescending(p => p.Score(10)).ToList();
            ui.DisplayScores(sortedPlayers, 10);
            UserInterface.Write(sortedPlayers[0].Name+" Wins! Press Enter to End");
            Console.Read();
        }

        private static int InputScore(int frame, Player player, int maxScore, int ball)
        {
            int input = 0;
            bool isInputValid = false;
            while (!isInputValid)
            {
                input = UserInterface.InputInt(
                    player.Name + ", please enter your score for bowl "
                    + ball + " of frame " + frame);
                if (input <= maxScore)
                {
                    isInputValid = true;
                }
            }
            player.Ball(input);
            return input;
        }
    }
}
