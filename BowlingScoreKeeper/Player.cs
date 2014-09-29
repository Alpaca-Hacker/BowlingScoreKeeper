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
            int i = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (_balls[i] == 10)
                {
                    score += 10 + _balls[i + 1] + _balls[i + 2];
                    i--;
                }
                else if  (_balls[i]+_balls[i+1] == 10)
                {
                    score += 10 + _balls[i + 2];
                }
                else
                {
                    score += _balls[i] + _balls[i + 1];
                }
                
                i += 2;
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
