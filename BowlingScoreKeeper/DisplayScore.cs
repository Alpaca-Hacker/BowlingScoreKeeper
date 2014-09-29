using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreKeeper
{
    class DisplayScore
    {

        public DisplayScore(int maxFrame, Score score)
        {
            string topDisplay;
            string midDisplay;
            string bottomDisplay;

            topDisplay =    "Frame\t 1\t 2\t 3\t 4\t 5\t 6\t 7\t 8\t 9\t 10";
            midDisplay =    "\t";
            bottomDisplay = "Score\t";
        
            for (int frame = 0; frame < maxFrame; frame++)
            {
                if (score.IsStrike(frame))
                {
                    if (frame < 9)
                    {
                        midDisplay += " X ";
                    }
                    else
                    {
                        midDisplay += "X";
                    }
                }
                else
                {
                    midDisplay += score.Frames[frame, 0].ToString() + "¦";
                    if (score.Frames[frame, 0] + score.Frames[frame, 1] == 10)
                    {
                        midDisplay += "/";
                    }
                    else
                    {
                        midDisplay += score.Frames[frame, 1].ToString();
                    }
                }
                if (frame <9)
                {
                    midDisplay += "\t";
                }
                string text = score.ScoreToFrame(frame+1).ToString();
                if (text.Length<3)
                {
                    text = " "+text;
                }
                   bottomDisplay += text + "\t";
            }
            if (maxFrame == 10)
            {
                if (score.IsStrike(9))
                {
                    if (score.IsStrike(10))
                    {
                        midDisplay += "X" + (score.IsStrike(11) ? "X" : score.Frames[11, 0].ToString());
                    }
                    else
                    {
                        midDisplay += score.Frames[10, 0] + (score.IsSpare(10) ? score.Frames[10, 0].ToString() : "/");
                    }
                }
                else if (score.IsSpare(9))
                {
                    midDisplay += score.Frames[10,0];
                }
            }

            Console.WriteLine("[NAME]");
            Console.WriteLine(topDisplay);
            Console.WriteLine(midDisplay);
            Console.WriteLine(bottomDisplay);
        }
    }
}
