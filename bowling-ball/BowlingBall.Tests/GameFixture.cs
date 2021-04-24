using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {            
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.Score);
        }

        private void Roll(Game game, int pins, int times)
        {            
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
       
        [TestMethod]
        public void TestTwoThrowsNoMark()
        {
           
            game.Roll(5);
            game.Roll(4);
            Assert.AreEqual(9, game.Score);
        }
        [TestMethod]
        public void TestFourThrowsNoMark()
        {
            
            game.Roll(5);
            game.Roll(4);
            game.Roll(7);
            game.Roll(2);
            Assert.AreEqual(18, game.Score);
            Assert.AreEqual(9, game.GetScoreForFrame(1));
            Assert.AreEqual(18, game.GetScoreForFrame(2));
        }
        [TestMethod]
        public void TestSimpleSpare()
        {
           
            game.Roll(3);
            game.Roll(7);
            game.Roll(3);
            Assert.AreEqual(13, game.GetScoreForFrame(1));
        }
        [TestMethod]
        public void TestSimpleFrameAfterSpare()
        {
           
            game.Roll(3);
            game.Roll(7);
            game.Roll(3);
            game.Roll(2);
            Assert.AreEqual(13, game.GetScoreForFrame(1));
            Assert.AreEqual(18, game.GetScoreForFrame(2));
            Assert.AreEqual(18, game.Score);
        }
        [TestMethod]
        public void TestSimpleStrike()
        {
            
            game.Roll(10);
            game.Roll(3);
            game.Roll(6);
            Assert.AreEqual(19, game.GetScoreForFrame(1));
            Assert.AreEqual(28, game.Score);
        }
        [TestMethod]
        public void TestPerfectGame()
        {
           
            for (int i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(300, game.Score);
        }

        [TestMethod]
        public void TestEndOfArray()
        {
           
            for (int i = 0; i < 9; i++)
            {
                game.Roll(0); 
                game.Roll(0);
            }
            game.Roll(2); 
            game.Roll(8);
            // 10th frame spare   
            game.Roll(10); // Strike in last position of array.   
            //game.Roll(10);
            Assert.AreEqual(20, game.Score);
        }
        [TestMethod]
        public void TestSampleGame()
        {
            
            game.Roll(1);
            game.Roll(4);
            game.Roll(4);
            game.Roll(5);
            game.Roll(6);
            game.Roll(4);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(0);
            game.Roll(1);
            game.Roll(7);
            game.Roll(3);
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);
            game.Roll(2);
            game.Roll(8);
            game.Roll(6);
            Assert.AreEqual(133, game.Score);
        }
        [TestMethod]
        public void TestHeartBreak()
        {
            game = new Game();
            for (int i = 0; i < 11; i++)
                game.Roll(10);
            game.Roll(9);
            Assert.AreEqual(299, game.Score);
        }
        [TestMethod]
        public void TestTenthFrameSpare()
        {
            
            for (int i = 0; i < 9; i++)
                game.Roll(10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(1);
            Assert.AreEqual(270, game.Score);
        }
    }    
}
