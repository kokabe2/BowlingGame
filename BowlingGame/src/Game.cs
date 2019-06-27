// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

namespace BowlingGame
{
    public class Game
    {
        bool firstThrowInFrame = true;
        Scorer itsScorer = new Scorer();

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
            itsScorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        void AdjustCurrentFrame(int pins)
        {
            if (firstThrowInFrame)
            {
                if (pins == 10) AdvanceFrame();
                else firstThrowInFrame = false;
            }
            else
            {
                firstThrowInFrame = true;
                AdvanceFrame();
            }
        }

        void AdvanceFrame()
        {
            CurrentFrame = Math.Min(11, CurrentFrame + 1);
        }

        public int ScoreForFrame(int theFrame)
        {
            return itsScorer.ScoreForFrame(theFrame);
        }
    }
}
