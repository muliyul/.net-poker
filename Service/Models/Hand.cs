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

        
        public int Value {
            get
            {

                int sum = cards.Sum(card => card.Value);
                int aces = cards.Count(card => card.Face == Face.Ace);

                while (sum > 21 && aces-- > 0) sum -= 10;
                return sum;
            }
            private set { }
        }


    
        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {

            int sum = cards.Sum(card => card.Value);
            int aces = cards.Count(card => card.Face == Face.Ace);

            while (sum > 21 && aces-- > 0) sum -= 10;
            Value = sum;
           
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
    [DataContract]
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
                return this.Value.CompareTo(aHand.Value);
            }
            else
            {
                throw new ArgumentException("Argument is not a Hand");
            }
        }

       
    }
}