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

            topDisplay = "Frame ";
            for (int i = 1; i < 11; i++)
            {
                topDisplay += " " + i + "  ";
            }
            midDisplay =    "      ";
            bottomDisplay = "Score ";
        
            for (int frame = 0; frame < maxFrame; frame++)
            {
                if (score.Frames[frame,0] == null)
                {
                    break;
                }
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
                    midDisplay += score.Frames[frame, 0].ToString() + "|";
                    if (score.IsSpare(frame))
                    {
                        midDisplay += "/";
                    }
                    else
                    {
                        if (score.Frames[frame,1] != null)
                        {
                        midDisplay += score.Frames[frame, 1].ToString();
                        }
                    }
                }
                if (frame <9)
                {
                    midDisplay += " ";
                }
                string text = score.ScoreToFrame(frame+1).ToString();
                if (text != "-1")
                {
                    if (text.Length == 1)
                    {
                        text = " " + text+" ";
                    }
                    if (text.Length == 2)
                    {
                        text += " ";
                    }
                    bottomDisplay += text + " ";

                }
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
                        midDisplay += score.Frames[10, 0] 
                            + (score.IsSpare(10) ? "/" : score.Frames[10, 1].ToString());
                    }
                }
                else if (score.IsSpare(9))
                {
                    midDisplay += (score.IsStrike(10) ? "X" :score.Frames[10,0].ToString());
                }
            }
            int cursorPos = Console.BufferWidth / 2 - topDisplay.Length / 2;
            Console.SetCursorPosition(cursorPos, Console.CursorTop);
            Console.WriteLine(topDisplay);
            Console.SetCursorPosition(cursorPos, Console.CursorTop);
            Console.WriteLine(midDisplay);
            Console.SetCursorPosition(cursorPos, Console.CursorTop);
            Console.WriteLine(bottomDisplay);
        }


    }
}
