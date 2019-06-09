﻿// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

namespace BowlingGame
{
    public class Game
    {
        int[] itsThrows = new int[21];
        int itsCurrentThrow = 0;

        public int Score
        {
            get;
            private set;
        } = 0;
        public int CurrentFrame
        {
            get { return 1 + (itsCurrentThrow - 1) / 2; }
        }

        public void Add(int pins)
        {
            itsThrows[itsCurrentThrow++] = pins;
            Score += pins;
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
                int secondThrow = itsThrows[ball++];
                int frameScore = firstThrow + secondThrow;
                if (frameScore == 10) score += frameScore + itsThrows[ball];
                else score += frameScore;
            }

            return score;
        }
    }
}
