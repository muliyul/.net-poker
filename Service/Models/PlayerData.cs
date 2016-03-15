using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Web;

namespace Service.Models
{
    [DataContract]
    public class PlayerData
    {
        
        private decimal _balance;
        private decimal _bet;

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public double Bank { get; set; }
        [DataMember]
        public DateTime MemberSince { get; set; }
        [DataMember]
        public BlackJackHand Hand { get; set; }
        [DataMember]
        public decimal Bet
        {
            get
            {
                return _bet;
            }
            set
            {
                _bet = value;
            }
        }

        public bool IsReady { get; set; }
        public Deck CurrentDeck { get; set; }


        public IGameCallback Callback { get; set; }

        public Table CurrentTable { get; set; }
        public BlackJackHand NewHand()
        {
            this.Hand = new BlackJackHand();
            return this.Hand;
        }

        /// <summary>
        /// Set the bet value back to 0
        /// </summary>
        public void ClearBet()
        {
            _bet = 0;
        }

        /// <summary>
        /// Check if the current player has BlackJack
        /// </summary>
        /// <returns>Returns true if the current player has BlackJack</returns>
        public bool HasBlackJack()
        {
            if (Hand.GetSumOfHand == 21)
                return true;
            else return false;
        }

        /// <summary>
        /// Check if the current player has bust
        /// </summary>
        /// <returns>returns true if the current player has bust</returns>
        public bool HasBust()
        {
            if (Hand.GetSumOfHand > 21)
                return true;
            else return false;
        }

        /// <summary>
        /// Player has hit, draw a card from the deck and add it to the player's hand
        /// </summary>
        public void Hit()
        {
            Card c = CurrentDeck.Draw();
            Hand.Cards.Add(c);
        }

        public void DoubleDown()
        {
            IncreaseBet(_bet);
            // Only decrease the balance by half of the current bet
            _balance = _balance - (_bet / 2);
            Hit();
        }

        /// <summary>
        /// Increases the bet amount each time a bet is added to the hand.  Invoked through the betting coins in the BlackJackForm.cs UI
        /// </summary>
        /// <param name="amt"></param>
        public void IncreaseBet(decimal amt)
        {
            // Check to see if the user has enough money to make this bet
            if ((_balance - (_bet + amt)) >= 0)
            {
                // Add money to the bet
                _bet += amt;
            }
            else
            {
                throw new Exception("You do not have enough money to make this bet.");
            }
        }
    }
}