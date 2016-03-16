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
        public PlayerData Dealer { get; set; }
        [DataMember]
        public bool InGame
        {
            get
            { return _inGame; }
        }


        private bool _inGame;
        private Deck _deck;

        private IEnumerator<PlayerData> _turn;
        #region Game Events


        event EventHandler<GameArgs> JoinHandler;
        event EventHandler<GameArgs> LeaveHandler;
        event EventHandler<GameArgs> HitHandler;
        event EventHandler<GameArgs> StandHandler;
        event EventHandler<GameArgs> BetHandler;
        event EventHandler<GameArgs> FoldHandler;
        event EventHandler<GameArgs> PlayerTurnHandler;
        #endregion

        [DataMember]
        Deck d = new Deck();

        public Table()
        {
            Id = Guid.NewGuid().ToString();
            Players = new List<PlayerData>();
            Dealer = new PlayerData();
            _inGame = false;
            // Players.Add(Dealer); // Is the dealer one of the players?
        }


        internal void Join(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            RegisterEvents(cb);
            Players.Add(player);
            JoinHandler(null, new GameArgs() { Table = this });
        }

        void RegisterEvents(IGameCallback callback)
        {
            JoinHandler += callback.OnJoin;
            LeaveHandler += callback.OnLeave;
            HitHandler += callback.OnHit;
            StandHandler += callback.OnStand;
            BetHandler += callback.OnBet;
            FoldHandler += callback.OnFold;
            PlayerTurnHandler += callback.OnMyTurn;
        }

        void RemoveEvents(IGameCallback callback)
        {
            JoinHandler -= callback.OnJoin;
            LeaveHandler -= callback.OnLeave;
            HitHandler -= callback.OnHit;
            StandHandler -= callback.OnStand;
            BetHandler -= callback.OnBet;
            FoldHandler -= callback.OnFold;
            PlayerTurnHandler -= callback.OnMyTurn;
        }

        public void DealNewGame()
        {
            _turn = Players.GetEnumerator();
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

            Dealer.Hand.Cards.Add(d);

            // Give the player and the dealer a handle to the current deck
            foreach (var player in Players)
            {
                player.CurrentDeck = _deck;
            }
            Dealer.CurrentDeck = _deck;

            PlayerTurnHandler(null, new GameArgs() { Player = _turn.Current });
        }

        internal void Hit(PlayerData player)
        {
            var c = d.Pop();
            //Players.Add(player);
            //player.Hand.Add(c);

            // check for black jack / bust


            HitHandler(this, new GameArgs() { Player = player, Card = c });
        }

        internal void Leave(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            var _ref = Players.SingleOrDefault(p => p.Username.Equals(player.Username));
            Players.Remove(_ref);
            RemoveEvents(cb);

            var currentPlayer = _turn.Current;
            if (player.Username == currentPlayer.Username)
            {
                _turn.MoveNext();
                currentPlayer = _turn.Current;
            }

            _turn = Players.GetEnumerator();
            while (_turn.Current != currentPlayer) _turn.MoveNext();
            

            LeaveHandler(null, new GameArgs() { Player = player });
        }

        internal void Bet(PlayerData player, decimal amount, bool doubleBet)
        {
            CheckLastTurn();
            BetHandler(null, new GameArgs() { Player = player, Amount = amount });
        }


        internal void Fold(PlayerData player)
        {
            FoldHandler(null, new GameArgs() { Player = player });
        }

        /// <summary>
        /// Check if all players are ready to play
        /// </summary>
        internal void CheckReady()
        {
            if(Players.FirstOrDefault(p => !p.IsReady) != null)
                return;

            // Start The Game
            _inGame = true;
            DealNewGame();

        }

        internal void Stand(PlayerData currentPlayer)
        {
            CheckLastTurn();
            StandHandler(null, new GameArgs() { Player = currentPlayer });
        }

        void CheckLastTurn()
        {
            if (_turn.MoveNext())
            {
                PlayerTurnHandler(null, new GameArgs() { Player = _turn.Current });
            }
            else {
                DealerPlay();
                EndGame();
            }
        }

        void DealerPlay()
        {
            while (Dealer.Hand.Value < 17)
                Dealer.Hand.Cards.Add(_deck.Draw());
        }

        void EndGame()
        {
            foreach(var p in Players)
            {
                if (p.Hand.Value == Dealer.Hand.Value)      // player tie
                { 
                    p.Bank += decimal.ToDouble(p.Bet); 
                }
                else if(p.Hand.Value < Dealer.Hand.Value)   // player lose
                {
                    p.Bank -= decimal.ToDouble(p.Bet);
                }
                else if(p.Hand.Value > Dealer.Hand.Value)   // player win
                {
                    if (p.Hand.Value == 21) // player blackjack
                        p.Bank += decimal.ToDouble(2.4m * p.Bet);
                    else        // normal win
                    {                                       
                        p.Bank += decimal.ToDouble(2 * p.Bet);
                    }
                }
            }

            DealNewGame();
        }
    }
}