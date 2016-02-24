using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blackjack
{
    public class Deck : Stack<Card>
    {
        static readonly List<Card> CARDS = new List<Card>();

        static Deck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
                foreach (Face f in Enum.GetValues(typeof(Face)))
                    CARDS.Add(new Card { Suit = s, Face = f });
        }

        public Deck() : base(CARDS.OrderBy(a => Guid.NewGuid())) { }

        public void Shuffle()
        {
            Clear();
            foreach (Card c in CARDS.OrderBy(a => Guid.NewGuid()))
                Push(c);
        }
    }
}