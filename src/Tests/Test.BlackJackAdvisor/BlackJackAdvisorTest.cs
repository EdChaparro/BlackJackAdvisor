using IntrepidProducts.DeckOfCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrepidProducts.BlackJackAdvisor.Tests
{
    [TestClass]
    public class BlackJackAdvisorTest
    {
        [TestMethod]
        public void ShouldHoldWhenGamblerHasBlackJack()
        {
            var gamblerHand = new BlackJackHand(
                new Card(Rank.Ace, Suit.Diamonds),
                            new Card(Rank.Jack, Suit.Hearts));

            Assert.AreEqual(BlackJackAction.Hold, 
                BlackJackAdvisor.RecommendAction
                    (new Card(Rank.Ace, Suit.Spades), gamblerHand));
        }

        [TestMethod]
        public void ShouldHoldWhenGamblerHas21()
        {
            var gamblerHand = new BlackJackHand(
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Three, Suit.Clubs));

            Assert.AreEqual(BlackJackAction.Hold, BlackJackAdvisor.RecommendAction
                (new Card(Rank.Ace, Suit.Spades), gamblerHand));
        }

        [TestMethod]
        public void ShouldHoldWhenGamblerHas12OrMoreAndDealerHasLessThan7()
        {
            var gamblerHand = new BlackJackHand(
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts));

            Assert.AreEqual(BlackJackAction.Hold, BlackJackAdvisor.RecommendAction
                (new Card(Rank.Six, Suit.Spades), gamblerHand));

            Assert.AreEqual(BlackJackAction.Hit, BlackJackAdvisor.RecommendAction
                (new Card(Rank.Seven, Suit.Spades), gamblerHand));

        }

        [TestMethod]
        public void ShouldHitWhenGamblerHasLessThan17AndDealerHasMoreThan6()
        {
            var gamblerHand = new BlackJackHand(
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts));

            Assert.AreEqual(BlackJackAction.Hit, BlackJackAdvisor.RecommendAction
                (new Card(Rank.Seven, Suit.Spades), gamblerHand));

            Assert.AreEqual(BlackJackAction.Hold, BlackJackAdvisor.RecommendAction
                (new Card(Rank.Six, Suit.Spades), gamblerHand));
        }

        [TestMethod]
        public void ShouldAlwaysSplitWhenGamblerHasTwoAces()
        {
            var gamblerHand = new BlackJackHand(
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts));

            Assert.AreEqual(BlackJackAction.Split, 
                BlackJackAdvisor.RecommendAction
                (new Card(Rank.Seven, Suit.Spades), gamblerHand));
        }

        [TestMethod]
        public void ShouldDoubleDownWhenDealerHasLessThan7AndGamblerHas10Or11()
        {
            var gamblerHand10 = new BlackJackHand(
                new Card(Rank.Eight, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts));

            var gamblerHand11 = new BlackJackHand(
                new Card(Rank.Eight, Suit.Diamonds),
                new Card(Rank.Three, Suit.Hearts));

            Assert.AreEqual(BlackJackAction.DoubleDown,
                BlackJackAdvisor.RecommendAction
                    (new Card(Rank.Six, Suit.Spades), gamblerHand10));

            Assert.AreEqual(BlackJackAction.DoubleDown,
                BlackJackAdvisor.RecommendAction
                    (new Card(Rank.Six, Suit.Spades), gamblerHand11));

            Assert.AreEqual(BlackJackAction.Hit,
                BlackJackAdvisor.RecommendAction
                    (new Card(Rank.Seven, Suit.Spades), gamblerHand10));

            Assert.AreEqual(BlackJackAction.Hit,
                BlackJackAdvisor.RecommendAction
                    (new Card(Rank.Seven, Suit.Spades), gamblerHand11));
        }
    }
}