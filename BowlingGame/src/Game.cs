// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

namespace BowlingGame
{
    public class Game
    {
        int[] itsThrows = new int[21];
        int itsCurrentThrow = 0;
        bool firstThrow = true;

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
            if (firstThrow)
            {
                if (pins == 10) CurrentFrame++;
                else firstThrow = false;
            }
            else
            {
                firstThrow = true;
                CurrentFrame++;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            int ball = 0;
            int score = 0;
            for (int currentFrame = 0;
                 currentFrame < theFrame;
                 ++currentFrame)
            {
                int firstThrow = itsThrows[ball++];
                if (firstThrow == 10)
                {
                    score += 10 + itsThrows[ball] + itsThrows[ball + 1];
                }
                else
                {
                    int secondThrow = itsThrows[ball++];
                    int frameScore = firstThrow + secondThrow;
                    if (frameScore == 10) score += frameScore + itsThrows[ball];
                    else score += frameScore;
                }
            }

            return score;
        }
    }
}
