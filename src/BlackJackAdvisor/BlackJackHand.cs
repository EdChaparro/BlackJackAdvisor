using System.Collections.Generic;
using System.Linq;
using IntrepidProducts.DeckOfCards;

namespace IntrepidProducts.BlackJackAdvisor
{
    public class BlackJackHand
    {
        public BlackJackHand(params Card[] cards)
        {
            foreach (var card in cards)
            {
                Add(card);
            }
        }

        private readonly IList<Card> _cards = new List<Card>();

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public bool IsBusted => SoftCount > 21;

        public bool Is21 => Count == 21;

        public bool HasJustTwoAces => _cards.Count == 2 && _cards.Count(x => x.IsAce) > 1;

        public bool IsBlackJack
        {
            get
            {
                return _cards.Count == 2 && (_cards.Any(x => x.IsAce) &&
                                             (_cards.Any(x => x.IsRoyalty) ||
                                              _cards.Any(x => x.CardRank == Rank.Ten)));
            }
        }

        public bool HasSoftCount => _cards.Any(x => x.IsAce);

        public int SoftCount => CalculateCount(aceValue: 1);
        public int Count => CalculateCount(aceValue: 11);

        private int CalculateCount(int aceValue)
        {
            var aceCount = _cards.Count(x => x.IsAce) * aceValue;

            var royaltyCount = _cards.Count(x => x.IsRoyalty) * 10;

            var standardCount = _cards.Where(x => x.IsNumber)
                .Sum(x => (int)x.CardRank);

            return aceCount + royaltyCount + standardCount;
        }
    }
}