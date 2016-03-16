using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service.Models
{
    [DataContract]
    public class Hand
    {
        // Creates a list of cards
        protected List<Card> cards = new List<Card>();
        

        [DataMember]
        public List<Card> Cards { get { return cards; } }

        [DataMember]
        public int Value
        {
            get
            {
                int sum = cards.Sum(card => card.Value);
                int aces = cards.Count(card => card.Face == Face.Ace);

                while (sum > 21 && aces-- > 0) sum -= 10;
                return sum;
            }
        }
        /// <summary>
        /// Gets the total value of a hand from BlackJack values
        /// </summary>
        /// <returns>int</returns>
        [DataMember]
        public int GetSumOfHand
        {
            get
            {

                int val = 0;
                int numAces = 0;

                foreach (Card c in cards)
                {
                    if (c.Face == Face.Ace)
                    {
                        numAces++;
                        val += 11;
                    }
                    else if (c.Face == Face.Jack || c.Face == Face.Queen || c.Face == Face.King)
                    {
                        val += 10;
                    }
                    else
                    {
                        val += (int)c.Face;
                    }
                }

                while (val > 21 && numAces > 0)
                {
                    val -= 10;
                    numAces--;
                }

                return val;
            }
        }

        /////*** copied from client 

    
        /// <summary>
        /// Checks to see if the hand contains a card of a certain face value
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool ContainsCard(Face item)
        {
            foreach (Card c in cards)
            {
                if (c.Face == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class BlackJackHand : Hand
    {
        /// <summary>
        /// This method compares two BlackJack hands
        /// </summary>
        /// <param name="otherHand"></param>
        /// <returns></returns>
        public int CompareFaceValue(object otherHand)
        {
            BlackJackHand aHand = otherHand as BlackJackHand;
            if (aHand != null)
            {
                return this.GetSumOfHand.CompareTo(aHand.GetSumOfHand);
            }
            else
            {
                throw new ArgumentException("Argument is not a Hand");
            }
        }

       
    }
}