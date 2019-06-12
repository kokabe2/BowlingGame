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
        public void TestTwoThrowsNoMark()
        {
            g.Add(5);
            g.Add(4);

            Assert.Equal(9, g.Score);
            Assert.Equal(2, g.CurrentFrame);
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
            Assert.Equal(3, g.CurrentFrame);
        }

        [Fact]
        public void TestSimpleSpare()
        {
            g.Add(3);
            g.Add(7);
            g.Add(3);

            Assert.Equal(13, g.ScoreForFrame(1));
            Assert.Equal(2, g.CurrentFrame);
        }

        [Fact]
        public void TestSimpleFrameAfterSpare()
        {
            g.Add(3);
            g.Add(7);
            g.Add(3);
            g.Add(2);

            Assert.Equal(13, g.ScoreForFrame(1));
            Assert.Equal(18, g.ScoreForFrame(2));
            Assert.Equal(18, g.Score);
            Assert.Equal(3, g.CurrentFrame);
        }

        [Fact]
        public void TestSimpleStrike()
        {
            g.Add(10);
            g.Add(3);
            g.Add(6);

            Assert.Equal(19, g.ScoreForFrame(1));
            Assert.Equal(28, g.Score);
            Assert.Equal(3, g.CurrentFrame);
        }

        [Fact]
        public void TestPerfectGame()
        {
            for (int i = 0; i < 12; ++i)
            {
                g.Add(10);
            }

            Assert.Equal(300, g.Score);
            Assert.Equal(11, g.CurrentFrame);
        }

        [Fact]
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; ++i)
            {
                g.Add(0);
                g.Add(0);
            }
            g.Add(2);
            g.Add(8);
            g.Add(10);

            Assert.Equal(20, g.Score);
        }

        [Fact]
        public void TestSampleGame()
        {
            g.Add(1);
            g.Add(4);
            g.Add(4);
            g.Add(5);
            g.Add(6);
            g.Add(4);
            g.Add(5);
            g.Add(5);
            g.Add(10);
            g.Add(0);
            g.Add(1);
            g.Add(7);
            g.Add(3);
            g.Add(6);
            g.Add(4);
            g.Add(10);
            g.Add(2);
            g.Add(8);
            g.Add(6);

            Assert.Equal(133, g.Score);
        }
    }
}
