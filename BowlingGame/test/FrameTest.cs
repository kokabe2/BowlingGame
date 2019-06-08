// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;
using Xunit;
using BowlingGame;

namespace BowlingGameTest
{
    public class FrameTest
    {
        [Fact]
        public void TestScoreNoThrows()
        {
            Frame f = new Frame();

            Assert.Equal(0, f.GetScore());
        }

        [Fact]
        public void TestAddOneThrow()
        {
            Frame f = new Frame();

            f.Add(5);

            Assert.Equal(5, f.GetScore());
        }
    }
}
