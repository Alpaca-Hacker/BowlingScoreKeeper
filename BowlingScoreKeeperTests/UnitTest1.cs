using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingScoreKeeper;

namespace BowlingScoreKeeperTests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void CheckScoreStartsZero()
        {
            var player = new Player();

            var result = player.Score();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ZeroScoreGame()
        {
            var player = new Player();
            for (int i = 1; i < 21; i++)
            {
                player.Ball(0);
            }

            var result = player.Score();

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void AllOneScoreGame()
        {
            var player = new Player();
            for (int i = 1; i < 21; i++)
            {
                player.Ball(1);
            }

            var result = player.Score();

            Assert.AreEqual(20, result);
        }
        [TestMethod]
        public void NoSpareOrStrikes()
        {
            var player = new Player();
            var testScore = new int[] { 9, 0, 3, 5, 6, 1, 3, 6, 8, 1, 5, 3, 2, 5, 8, 0, 7, 1, 8, 1 };
            
            for (int i = 0; i < 20; i++)
            {
                player.Ball(testScore[i]);
            }

            var result = player.Score();

            Assert.AreEqual(82, result);
        }
        [TestMethod]
        public void GameWithSpares()
        {
            var player = new Player();
            var testScore = new int[] { 9,0,3,7,6,1,3,7,8,1,5,5,0,10,8,0,7,3,8,2,8 };

            for (int i = 0; i < 21; i++)
            {
                player.Ball(testScore[i]);
            }

            var result = player.Score();

            Assert.AreEqual(131,result);
        }

    }
}
