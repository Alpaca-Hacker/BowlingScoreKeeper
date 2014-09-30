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
            new DisplayScore(10, player);

            Assert.AreEqual(131,result);
        }
        [TestMethod]
        public void GameWithSparesAndStrikes()
        {
            var player = new Player();
            var testScore = new int[] { 10,3,7,6,1,10,10,10,2,8,9,0,7,3,10,10,10 };

            for (int i = 0; i <testScore.Length; i++)
            {
                player.Ball(testScore[i]);
            }

            var result = player.Score();

            Assert.AreEqual(193, result);
        }
        [TestMethod]
        public void PerfectScoreGame()
        {
            var player = new Player();
            for (int i = 1; i < 13; i++)
            {
                player.Ball(10);
            }

            var result = player.Score();

            Assert.AreEqual(300, result);
        }
        [TestMethod]
        public void GameNotCompleteScore()
        {
            var player = new Player();
            var testScore = new int[] { 9, 0, 3, 5, 6, 1 };

            for (int i = 0; i < testScore.Length; i++)
            {
                player.Ball(testScore[i]);
            }

            var result = player.Score(3);

            Assert.AreEqual(24, result);

        }
        [TestMethod]
        public void GameNotCompleteWithStrikes()
        {
            var player = new Player();
            var testScore = new int[] { 9, 1, 3, 5, 10, 10,10, 10 };

            for (int i = 0; i < testScore.Length; i++)
            {
                player.Ball(testScore[i]);
            }
            new DisplayScore(6, player);
        }

        [TestMethod]
        public void GameNotCompleteWithSparesAndStrikes()
        {
            var player = new Player();
            var testScore = new int[] { 9, 1, 3, 5, 10, 5, 5};

            for (int i = 0; i < testScore.Length; i++)
            {
                player.Ball(testScore[i]);
            }

             new DisplayScore(4, player);

           

        }
        [TestMethod]
        public void GameWithSparesAndStrikesInTenth()
        {
            var player = new Player();

            for (int i = 0; i < 18; i++)
            {
                player.Ball(0);
            }

            player.Ball(10);
            player.Ball(8);
            player.Ball(2);

            var result = player.Score(10);

            Assert.AreEqual(20, result);
            new DisplayScore(10, player);
        }

    }
}
