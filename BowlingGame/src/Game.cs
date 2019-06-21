// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

namespace BowlingGame
{
    public class Game
    {
        int[] itsThrows = new int[21];
        int itsCurrentThrow = 0;
        bool firstThrowInFrame = true;
        int ball;

        public int Score
        {
            get { return ScoreForFrame(CurrentFrame - 1); }
        }
        public int CurrentFrame
        {
            get;
            private set;
        } = 1;

        public void Add(int pins)
        {
            itsThrows[itsCurrentThrow++] = pins;
            AdjustCurrentFrame(pins);
        }

        void AdjustCurrentFrame(int pins)
        {
            if (firstThrowInFrame)
            {
                if (pins == 10) CurrentFrame++;
                else firstThrowInFrame = false;
            }
            else
            {
                firstThrowInFrame = true;
                CurrentFrame++;
            }

            CurrentFrame = Math.Min(11, CurrentFrame);
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
                    ball++;
                    score += 10 + NextTwoBalls();
                }
                else if (Spare())
                {
                    ball += 2;
                    score += 10 + NextBall();
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

        int NextTwoBalls()
        {
            return itsThrows[ball] + itsThrows[ball + 1];
        }

        int HandleSecondThrow()
        {
            int score = 0;
            if (Spare())
            {
                ball += 2;
                score += 10 + NextBall();
            }
            else
            {
                score += TwoBallsInFrame();
                ball += 2;
            }

            return score;
        }

        bool Spare()
        {
            return (itsThrows[ball] + itsThrows[ball + 1]) == 10;
        }

        int NextBall()
        {
            return itsThrows[ball];
        }

        int TwoBallsInFrame()
        {
            return itsThrows[ball] + itsThrows[ball + 1];
        }
    }
}
