using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScoreKeeper
{
    public class Game
    {
        List<Player> players = new List<Player>();
        Display display = new Display();

        public void Run()
        {
            display.Title();
            int input = 0;
            while (input < 1)
            {
                input = Display.InputInt("How many players?");
            }

            for (int i = 1; i <= input; i++)
            {
                string name = Display.InputString("Player " + i + " Name?");
                var player = new Player();
                player.Name = name;
                players.Add(player);
            }
        }
    }
}
