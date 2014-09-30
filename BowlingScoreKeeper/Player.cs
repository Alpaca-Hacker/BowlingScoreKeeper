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

        int currentBall = 0;
        int currentFrame = 0;
        Score score = new Score();

        public int Score(int maxFrame = 10)
        {
            var scored = score.ScoreToFrame(maxFrame);
            new DisplayScore(maxFrame, score, Name);
            return scored;
        }

        public void Ball(int pins)
        {
            score.Frames[currentFrame,currentBall] = pins;

            if (pins == 10 && currentBall == 0)
            {
                currentFrame++;
            }
            else if (currentBall == 1)
            {
                currentBall = 0;
                currentFrame++;
            }
            else
                currentBall = 1;
        }
    }
}
