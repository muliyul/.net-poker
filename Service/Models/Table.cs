using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Collections.Specialized;

namespace Service.Models
{

    public class Table
    {

        [DataMember]
        public IList<PlayerData> Players { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int Pot { get; set; }

        [DataMember]
        public PlayerData Dealer { get { return _dealer; }  }

        private Deck _deck;

        [DataMember]
        private PlayerData _dealer;
        #region Game Events


        event EventHandler<GameArgs> JoinHandler;
        event EventHandler<GameArgs> LeaveHandler;
        event EventHandler<GameArgs> HitHandler;
        event EventHandler<GameArgs> BetHandler;
        event EventHandler<GameArgs> FoldHandler;
        event EventHandler<GameArgs> NextTurnHandler;
        #endregion

        [DataMember]
        Deck d = new Deck();

        public Table()
        {
            Id = Guid.NewGuid().ToString();
            Players = new List<PlayerData>();
            _dealer = new PlayerData();
           // Players.Add(_dealer); // Is the dealer one of the players?
        }


        internal void Join(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            RegisterEvents(cb);
            Players.Add(player);
            JoinHandler(null, new GameArgs() { Player = player });
        }

        void RegisterEvents(IGameCallback callback)
        {
            JoinHandler += callback.OnJoin;
            LeaveHandler += callback.OnLeave;
            HitHandler += callback.OnHit;
            BetHandler += callback.OnBet;
            FoldHandler += callback.OnFold;
            NextTurnHandler += callback.OnNextTurn;
        }

        void RemoveEvents(IGameCallback callback)
        {
            JoinHandler -= callback.OnJoin;
            LeaveHandler -= callback.OnLeave;
            HitHandler -= callback.OnHit;
            BetHandler -= callback.OnBet;
            FoldHandler -= callback.OnFold;
            NextTurnHandler -= callback.OnNextTurn;
        }

        void NextRound()
        {

        }
        public void DealNewGame()
        {
            // Create a new deck and then shuffle the deck
            _deck = new Deck();
            _deck.Shuffle();

            // Reset the player and the dealer's hands in case this is not the first game
            foreach (var player in Players)
            {
                player.NewHand();
            }

            // Deal two cards to each person's hand
            foreach (var player in Players)
            {
                for (int i = 0; i < 2; i++)
                {
                    Card c = _deck.Draw();
                    player.Hand.Cards.Add(c);
                }
            }
            
            Card d = _deck.Draw();
            // Set the dealer's second card to be facing down
            d.IsCardUp = false;

            _dealer.Hand.Cards.Add(d);

            // Give the player and the dealer a handle to the current deck
            foreach (var player in Players)
            {
                player.CurrentDeck = _deck;
            }
            _dealer.CurrentDeck = _deck;

        }

        internal void Hit(PlayerData player)
        {
            var c = d.Pop();
            //Players.Add(player);
            //player.Hand.Add(c);
            HitHandler(this, new GameArgs() { Player = player, Card = c });
        }

        internal void Leave(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            RemoveEvents(cb);
            LeaveHandler(null, new GameArgs() { Player = player });
        }

        internal void Bet(PlayerData player, decimal amount)
        {
            BetHandler(null, new GameArgs() { Player = player, Amount = amount });
        }


        internal void Fold(PlayerData player)
        {
            FoldHandler(null, new GameArgs() { Player = player });
        }
    }
}