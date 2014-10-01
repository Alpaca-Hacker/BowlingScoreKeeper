using System;

namespace BowlingScoreKeeper
{
    public class Player
    {
        public String Name { get; set; }
        public bool IsActive { get; set; }

        int currentBall = 0;
        int currentFrame = 0;
        public Score score = new Score();

        public int Score(int maxFrame = 10)
        {
            var scored = score.ScoreToFrame(maxFrame);

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
