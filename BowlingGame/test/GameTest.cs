// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;
using Xunit;
using BowlingGame;

namespace BowlingGameTest
{
    public class GameTest
    {
        [Fact]
        public void TestOneThrow()
        {
            Game g = new Game();

            g.Add(5);

            Assert.Equal(5, g.Score);
        }
    }
}
