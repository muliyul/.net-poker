using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service.Models
{
    [DataContract]
    public class Deck : Stack<Card>
    {
        static readonly IList<Card> _cards = new List<Card>();

        static Deck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
                foreach (Face f in Enum.GetValues(typeof(Face)))
                    _cards.Add(new Card { Suit = s, Face = f });
        }

        public Deck() : base(_cards.OrderBy(a => Guid.NewGuid().ToString())) { }

        public void Shuffle()
        {
            Clear();
            foreach (Card c in _cards.OrderBy(a => Guid.NewGuid().ToString()))
                Push(c);
        }

        public Card Draw()
        {
            if (_cards.Count > 0)
            {
                Card card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }
            return null;
        }
    }
}