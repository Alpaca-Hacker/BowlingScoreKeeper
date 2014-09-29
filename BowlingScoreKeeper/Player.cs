using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreKeeper
{
    public class Player
    {
        private int[] _balls = new int [21];
        private int _currentBall = 0;

        public int Score()
        {
            int score = 0;
            for (int i = 0; i < _balls.Length; i++)
            {
                score += _balls[i];
            }
            return score;
        }

        public void Ball(int pins)
        {
            _balls[_currentBall] = pins;
            _currentBall++;
        }
    }
}
