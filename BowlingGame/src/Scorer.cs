// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

namespace BowlingGame
{
    public class Scorer
    {
        int[] itsThrows = new int[21];
        int itsCurrentThrow = 0;
        int ball;

        public void AddThrow(int pins)
        {
            itsThrows[itsCurrentThrow++] = pins;
        }

        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0;
                 currentFrame < theFrame;
                 ++currentFrame)
            {
                if (Strike())
                {
                    score += 10 + NextTwoBallsForStrike();
                    ball++;
                }
                else if (Spare())
                {
                    score += 10 + NextBallForSpare();
                    ball += 2;
                }
                else
                {
                    score += TwoBallsInFrame();
                    ball += 2;
                }
            }

            return score;
        }

        bool Strike()
        {
            return itsThrows[ball] == 10;
        }

        int NextTwoBallsForStrike()
        {
            return itsThrows[ball + 1] + itsThrows[ball + 2];
        }

        bool Spare()
        {
            return (itsThrows[ball] + itsThrows[ball + 1]) == 10;
        }

        int NextBallForSpare()
        {
            return itsThrows[ball + 2];
        }

        int TwoBallsInFrame()
        {
            return itsThrows[ball] + itsThrows[ball + 1];
        }
    }
}
