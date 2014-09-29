using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreKeeper
{
    public class Player
    {
        public String Name { get; set; }
        private int _currentBall = 0;
        private int _currentFrame = 0;
        Score score = new Score();

        public int Score(int maxFrame = 10)
        {
            var scored = score.ScoreToFrame(maxFrame);
            new DisplayScore(maxFrame, score);
            return scored;
        }

        public void Ball(int pins)
        {
            score.Frames[_currentFrame,_currentBall] = pins;

            if (pins == 10 && _currentBall == 0)
            {
                _currentFrame++;
            }
            else if (_currentBall == 1)
            {
                _currentBall = 0;
                _currentFrame++;
            }
            else
                _currentBall = 1;
        }
    }
}
