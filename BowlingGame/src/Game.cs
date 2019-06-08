// Copyright(c) 2019 Ken Okabe
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

        public void Add(int pins)
        {
            itsThrows[itsCurrentThrow++] = pins;
            Score += pins;
        }

        public int ScoreForFrame(int frame)
        {
            int score = 0;
            for (int ball = 0;
                 (frame > 0) && (ball < itsCurrentThrow);
                 ball += 2, frame--)
                score += itsThrows[ball] + itsThrows[ball + 1];

            return score;
        }
    }
}
