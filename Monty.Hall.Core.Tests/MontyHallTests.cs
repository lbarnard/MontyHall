using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Monty.Hall.Core.Tests
{
    [TestFixture]
    public class MontyHallTests
    {
        [TestCase(3, 1000)]
        public void SwapWins(int numberOfDoors, int gamesToPlay)
        {
            Game game = new Game(numberOfDoors);

            var wins = 0;
            var losses = 0;
            for (int i = 0; i < gamesToPlay; i++)
            {
                if (game.Swap())
                    wins++;
                else
                {
                    losses++;
                }
            }
            Assert.That(losses != 0, "You didn't lose the game at all");
            Assert.AreEqual(0.6m, (decimal)wins / (decimal)losses, "The percentage of wins isn't correct");
        }

        [TestCase(3, 100000)]
        public void StayWins(int numberOfDoors, int gamesToPlay)
        {
            Game game = new Game(numberOfDoors);

            var wins = 0;
            var losses = 0;
            for (int i = 0; i < gamesToPlay; i++)
            {
                if (game.Stay())
                    wins++;
                else
                {
                    losses++;
                }
            }
            Assert.That(losses != 0, "You didn't lose the game at all");
            Assert.AreEqual(0.6m, (decimal)wins / (decimal)losses, "The percentage of wins isn't correct");
        }

    }




}
