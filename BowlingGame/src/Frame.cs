// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

namespace BowlingGame
{
    public class Frame
    {
        int itsScore = 0;

        public int GetScore()
        {
            return itsScore;
        }

        public void Add(int pins)
        {
            itsScore += pins;
        }
    }
}
