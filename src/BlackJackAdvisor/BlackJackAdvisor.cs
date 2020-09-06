using IntrepidProducts.DeckOfCards;

namespace IntrepidProducts.BlackJackAdvisor
{
    public enum BlackJackAction
    {
        Hit = 1,
        Hold = 2,
        DoubleDown = 3,
        Split = 4
    }

    public class BlackJackAdvisor
    {
        public static BlackJackAction RecommendAction(Card dealerCard, BlackJackHand gamblerHand)
        {
            if ((gamblerHand.IsBlackJack) || (gamblerHand.Is21) || (gamblerHand.SoftCount > 16))
            {
                return BlackJackAction.Hold;
            }

            if ((gamblerHand.HasJustTwoAces) || (gamblerHand.HasJustTwoEights))
            {
                return BlackJackAction.Split;
            }

            if (dealerCard.IsNumber)
            {
                var dealerCardCardRank = (int) dealerCard.CardRank;
                if (dealerCardCardRank < 7)
                {
                    if ((gamblerHand.Count > 9) && (gamblerHand.Count < 12))
                    {
                        return BlackJackAction.DoubleDown;
                    }

                    return (gamblerHand.Count < 12) ? BlackJackAction.Hit : BlackJackAction.Hold;
                }
            }

            return (gamblerHand.Count < 17) ? BlackJackAction.Hit : BlackJackAction.Hold;
        }
    }
}