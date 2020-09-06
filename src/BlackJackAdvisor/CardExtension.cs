using IntrepidProducts.DeckOfCards;

namespace IntrepidProducts.BlackJackAdvisor
{
    public static class CardExtension
    {
        public static bool IsBetween2And6Inclusive(this Card card)
        {
            return card.IsNumber && (card.CardRank == Rank.Two   ||
                                     card.CardRank == Rank.Three ||
                                     card.CardRank == Rank.Four  ||
                                     card.CardRank == Rank.Five  ||
                                     card.CardRank == Rank.Six);
        }
    }
}