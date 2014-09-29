using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreKeeper
{
    class Score
    { 
        public int[,] Frames { get; set; }

        public Score()
        {
            this.Frames = new int[12, 2]; 
        }

       

        public int ScoreToFrame(int maxFrame)
        {
            int score = 0;

            for (int frame = 0; frame < maxFrame; frame++)
            {
                if (Frames[frame, 0] == 10)
                {
                    if (Frames[frame + 1, 0] == 10)
                    {
                        score += 20 + Frames[frame + 2, 0];
                    }
                    else
                    {
                        score += 10 + Frames[frame + 1, 0] + Frames[frame + 1, 1];
                    }
                }
                else if (Frames[frame, 0] + Frames[frame, 1] == 10)
                {
                    score += 10 + Frames[frame + 1, 0];
                }
                else
                {
                    score += Frames[frame, 0] + Frames[frame, 1];
                }

            }
            return score;
        }

    }
}
