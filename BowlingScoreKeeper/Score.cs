
namespace BowlingScoreKeeper
{
    public class Score
    {
        public int?[,] Frames { get; set; }

        public Score()
        {
            this.Frames = new int?[12, 2];
        }


// ScoreToFrame returns score upto the frame or returns -1 if inconclusive 
        public int ScoreToFrame(int maxFrame)
        {
            int score = 0;

            for (int frame = 0; frame < maxFrame; frame++)
            {
                if (Frames[frame,0] == null)
                {
                    return score;
                }

                if (IsStrike(frame))
                {
                    if (Frames[frame + 1, 0] == null)
                    {
                        return -1;
                    }

                    if (IsStrike(frame + 1))
                    {
                        if (Frames[frame + 2, 0] == null)
                        {
                            return -1;
                        }
                        else
                        {
                            score += 20 + (int)Frames[frame + 2, 0];
                        }
                    }
                    else
                    {
                        score += 10 + (int)Frames[frame + 1, 0] + (int)Frames[frame + 1, 1];
                    }
                }
                else if (IsSpare(frame))
                {
                    if (Frames[frame+1,0] == null)
                    {
                        return -1;
                    }
                    score += 10 + (int)Frames[frame + 1, 0];
                }
                else
                {
                    score += (int)Frames[frame, 0] + (int)Frames[frame, 1];
                }

            }
            return score;
        }

        public bool IsStrike(int frame)
        {
            if (Frames[frame, 0] == 10)
            {
                return true;
            }
            return false;
        }

        public bool IsSpare(int frame)
        {
            if (Frames[frame, 0] + Frames[frame, 1] == 10)
            {
                return true;
            }
            return false;
        }
    }

}

