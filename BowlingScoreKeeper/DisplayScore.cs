using System;

namespace BowlingScoreKeeper
{
    public class DisplayScore
    {
        public DisplayScore(int maxFrame, Player player)
        {
            Score score = player.score;
            string topDisplay;
            string midDisplay;
            string bottomDisplay;
            string topFrame;
            string midFrame;
            string botFrame;
            string sepLine;

            topDisplay = "│Frame │";
            topFrame = "┌──────";
            sepLine  = "│      ├";
            midFrame = "│      │";
            botFrame = "└──────";
            for (int i = 1; i < 10; i++)
            {
                topDisplay += " " + i + " │";
                topFrame += "┬───";
                sepLine += "─┬─┼";
                midFrame += " └─┤";
                botFrame +="┴───";
            }
            topFrame +=  "┬─────┐";
            topDisplay += "  10 │";
            sepLine +=    "─┬─┬─┤";
            midFrame +=   " └─┴─┤";
            botFrame +=  "┴─────┘";

            midDisplay =    "│      │";
            bottomDisplay = "│Score │";

            for (int frame = 0; frame < 10; frame++)
            {

                if (score.IsStrike(frame))
                {
                    if (frame < 9)
                    {
                        midDisplay += "X│ ";
                    }
                    else
                    {
                        midDisplay += "X";
                    }
                }
                else
                {
                    midDisplay += BowlScoreString(score, frame, 0) + "│";
                    if (score.IsSpare(frame))
                    {
                        midDisplay += "/";
                    }
                    else
                    {
                        midDisplay += BowlScoreString(score, frame, 1);
                    }
                }       
                    midDisplay += "│";
                

                string text = score.ScoreToFrame(frame+1).ToString();
                if (score.Frames[frame,0] == null)
                {
                    text = "-1";
                }

                if (text == "-1")
                {
                    text = "   ";
                }

                if (text.Length == 1)
                {
                    text = " " + text + " ";
                }
                if (text.Length == 2)
                {
                    text += " ";
                }
                if (frame == 9)
                {
                    bottomDisplay += "  ";
                }
                bottomDisplay += text + "│";


            }

            if (maxFrame == 10)
            {
                if (score.IsStrike(9))
                {
                    if (score.IsStrike(10))
                    {
                        midDisplay += "X" + (score.IsStrike(11) ? "│X" : "│" + score.Frames[11, 0].ToString());
                        midDisplay += "│";
                    }
                    else
                    {
                        midDisplay += BowlScoreString(score, 10, 0) + "│"
                            + (score.IsSpare(10) ? "/" : BowlScoreString(score, 10, 1));
                        midDisplay += "│";
                    }
                }
                else if (score.IsSpare(9))
                {
                    midDisplay += (score.IsStrike(10) ? "X" : BowlScoreString(score, 10, 0));
                    midDisplay += "│";
                }
                else
                {
                    midDisplay += " │";
                }
            }
            else
            {

                midDisplay += " │";

            }

            int cursorPos = Console.BufferWidth / 2 - topDisplay.Length / 2;
            CentreWrite(topFrame, cursorPos);
            CentreWrite(topDisplay,cursorPos);
            CentreWrite(sepLine, cursorPos);
            CentreWrite(midDisplay, cursorPos);
            CentreWrite(midFrame,cursorPos);
            CentreWrite(bottomDisplay, cursorPos);
            CentreWrite(botFrame,cursorPos);
        }

        private static string BowlScoreString(Score score, int frame, int ball)
        {
            var value = score.Frames[frame, ball].ToString();
            if (String.IsNullOrEmpty(value))
            {
                return " ";
            }
            return value;
        }

        private static void CentreWrite(string message, int cursorPos)
        {
            Console.SetCursorPosition(cursorPos, Console.CursorTop);
            Console.WriteLine(message);
        }


    }
}
