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
        private static Random rng = new Random();

        static Deck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
                foreach (Face f in Enum.GetValues(typeof(Face)))
                    _cards.Add(new Card { Suit = s, Face = f });
        }

        public Deck()
        {
            Shuffle();
        }


        public void Shuffle()
        {
            Clear();

            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }

            foreach (Card c in _cards)
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