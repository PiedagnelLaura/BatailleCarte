using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCarte
{
    using Models;
    class Dealer
    {
        private List<Card> _deck;
        public bool CanDeal => _deck.Count > 1;

        public Dealer()
        {
            _deck = EnumerateAllCards().ToList();
        }

        private IEnumerable<Card> EnumerateAllCards()
        {
            for (Suits suits = Suits.clubs; suits <= Suits.spade; suits++)
            {
                for (Values values = Values.As; values <= Values.Two; values++)
                {
                    yield return new Card(values, suits);
                }
            }
        }

        public Card RandomCardFromDeck()
        {
            if (_deck.Count <=0)
            {
                return null;
            }

            var randGen = new Random();
            int randIndex = randGen.Next(_deck.Count);
            var ret = _deck[randIndex];
            _deck.Remove(ret);

            return ret;
        }

        public List<Card> RandomCardFromDeck(int cardNumber)
        {
            var ret = new List<Card>();

            for (int i = 0; i < cardNumber; i++)
            {
                ret.Add(RandomCardFromDeck());
            }

            return ret;
        }
    }
}
