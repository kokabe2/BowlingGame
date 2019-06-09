// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;
using Xunit;
using BowlingGame;

namespace BowlingGameTest
{
    public class GameTest
    {
        Game g;

        public GameTest()
        {
            g = new Game();
        }

        [Fact]
        public void TestOneThrow()
        {
            g.Add(5);

            Assert.Equal(5, g.Score);
        }

        [Fact]
        public void TestTwoThrowsNoMark()
        {
            g.Add(5);
            g.Add(4);

            Assert.Equal(9, g.Score);
        }

        [Fact]
        public void TestFourThrowsNoMark()
        {
            g.Add(5);
            g.Add(4);
            g.Add(7);
            g.Add(2);

            Assert.Equal(18, g.Score);
            Assert.Equal(9, g.ScoreForFrame(1));
            Assert.Equal(18, g.ScoreForFrame(2));
        }
    }
}
