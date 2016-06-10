using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace kata0610_BowlingGame
{
    class BowlingGameTest
    {
        private BowlingGame _game;

        [SetUp]
        public void SetUp()
        {
            _game = new BowlingGame();
        }

        [Test]
        public void Roll_0_pins()
        {
            GetRolls(_game, 20, 0);

            Assert.AreEqual(0, _game.Score());
        }

        [Test]
        public void Roll_1_pins()
        {
            GetRolls(_game, 20, 1);

            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void Have_1_spare()
        {
            _game.Roll(4);
            _game.Roll(6);
            _game.Roll(2);

            Assert.AreEqual(14, _game.Score());
        }

        [Test]
        public void Have_1_strike()
        {
            _game.Roll(10);
            _game.Roll(3);
            _game.Roll(1);

            Assert.AreEqual(18, _game.Score());
        }

        [Test]
        public void PerfectGame()
        {
            GetRolls(_game, 12, 10);

            Assert.AreEqual(300, _game.Score());
        }

        private void GetRolls(BowlingGame game, int rollCount, int pins)
        {
            for (int i = 1; i <= rollCount; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
