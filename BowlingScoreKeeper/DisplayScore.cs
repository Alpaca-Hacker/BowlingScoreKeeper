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
                if (score.Frames[frame, 0] == 10)
                {
                    midDisplay += " X \t";
                }
                else
                {
                    midDisplay += score.Frames[frame, 0].ToString() + "¦";
                    if (score.Frames[frame, 0] + score.Frames[frame, 1] == 10)
                    {
                        midDisplay += "/\t";
                    }
                    else
                    {
                        midDisplay += score.Frames[frame, 1].ToString() + "\t";
                    }
                }
                string text = score.ScoreToFrame(frame+1).ToString();
                if (text.Length<3)
                {
                    text = " "+text;
                }
                bottomDisplay += text + "\t";
            }
            Console.WriteLine("[NAME]");
            Console.WriteLine(topDisplay);
            Console.WriteLine(midDisplay);
            Console.WriteLine(bottomDisplay);
        }
    }
}
