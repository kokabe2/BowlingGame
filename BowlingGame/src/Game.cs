// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

namespace BowlingGame
{
    public class Game
    {
        public int Score
        {
            get;
            private set;
        } = 0;

        public void Add(int pins)
        {
            Score += pins;
        }
    }
}
