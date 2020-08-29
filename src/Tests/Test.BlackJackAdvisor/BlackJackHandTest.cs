using IntrepidProducts.DeckOfCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrepidProducts.BlackJackAdvisor.Tests
{
    [TestClass]
    public class BlackJackHandTest
    {
        [TestMethod]
        public void ShouldDetectBlackJack()
        {
            var hand = new BlackJackHand();

            Assert.IsFalse(hand.IsBlackJack);

            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            hand.Add(new Card(Rank.King, Suit.Clubs));
            Assert.IsTrue(hand.IsBlackJack);
        }

        [TestMethod]
        public void ShouldConsiderAceAndTenBlackJack()
        {
            var hand = new BlackJackHand();

            Assert.IsFalse(hand.IsBlackJack);

            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            Assert.IsTrue(hand.IsBlackJack);
        }

        [TestMethod]
        public void ShouldDetect21()
        {
            var hand1 = new BlackJackHand();

            Assert.IsFalse(hand1.Is21);

            hand1.Add(new Card(Rank.Ace, Suit.Clubs));
            hand1.Add(new Card(Rank.King, Suit.Clubs));
            Assert.IsTrue(hand1.Is21);

            var hand2 = new BlackJackHand();
            hand2.Add(new Card(Rank.Two, Suit.Clubs));
            hand2.Add(new Card(Rank.Three, Suit.Clubs));
            hand2.Add(new Card(Rank.Four, Suit.Clubs));
            hand2.Add(new Card(Rank.Five, Suit.Clubs));
            hand2.Add(new Card(Rank.Five, Suit.Clubs));
            Assert.IsFalse(hand2.Is21);

            hand2.Add(new Card(Rank.Two, Suit.Clubs));
            Assert.IsTrue(hand2.Is21);
        }

        [TestMethod]
        public void ShouldDetectWhenBusted()
        {
            var hand = new BlackJackHand();

            Assert.IsFalse(hand.IsBusted);

            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            Assert.IsTrue(hand.IsBusted);
        }

        [TestMethod]
        public void ShouldNotBustWhenSoftCountAvailable()
        {
            var hand = new BlackJackHand();

            Assert.IsFalse(hand.IsBusted);

            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            Assert.IsFalse(hand.IsBusted);

            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            Assert.IsTrue(hand.IsBusted);
        }

        [TestMethod]
        public void ShouldDetectMultipleAces()
        {
            var hand = new BlackJackHand();

            Assert.IsFalse(hand.HasJustTwoAces);

            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            Assert.IsFalse(hand.HasJustTwoAces);

            hand.Add(new Card(Rank.Ace, Suit.Hearts));
            Assert.IsTrue(hand.HasJustTwoAces);

            hand.Add(new Card(Rank.Ace, Suit.Diamonds));
            Assert.IsFalse(hand.HasJustTwoAces);
        }

        [TestMethod]
        public void ShouldDetectSoftCount()
        {
            var hand = new BlackJackHand();

            Assert.IsFalse(hand.HasSoftCount);

            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            Assert.IsTrue(hand.HasSoftCount);
        }

        [TestMethod]
        public void ShouldCalculateSoftCount()
        {
            var hand = new BlackJackHand();

            Assert.AreEqual(0, hand.SoftCount);

            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            Assert.AreEqual(1, hand.SoftCount);

            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            Assert.AreEqual(11, hand.SoftCount);
        }

        [TestMethod]
        public void ShouldCalculateHardCount()
        {
            var hand = new BlackJackHand();

            Assert.AreEqual(0, hand.SoftCount);

            hand.Add(new Card(Rank.Ace, Suit.Clubs));
            Assert.AreEqual(11, hand.Count);

            hand.Add(new Card(Rank.Ten, Suit.Clubs));
            Assert.AreEqual(21, hand.Count);
        }
    }
}