using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Collections.Specialized;
using System.Threading;

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
            {
                return _inGame;
            }
            set
            {
                
                _inGame = value;
                MyGameServer.UpdateClientTablesLists();
            }
        }


        private bool _inGame;
        private Deck _deck;

        private IEnumerator<PlayerData> _turn;


        public Service.Game MyGameServer { set; get; }

        #region Game Events


        event EventHandler<GameArgs> JoinHandler;
        event EventHandler<GameArgs> LeaveHandler;
        event EventHandler<GameArgs> HitHandler;
        event EventHandler<GameArgs> StandHandler;
        event EventHandler<GameArgs> BetHandler;
        event EventHandler<GameArgs> StatusHandler;
        event EventHandler<GameArgs> PlayerTurnHandler;
        event EventHandler<GameArgs> DealHandler;
        event EventHandler<GameArgs> DealerPlayHandler;
        event EventHandler<GameArgs> ResetTableHandler;
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
            bool isFirst = Players.Count == 0;
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            RegisterEvents(cb);
            Players.Add(player);
            if (isFirst)
            {
                _turn = Players.GetEnumerator();
                _turn.MoveNext();
            }

            JoinHandler(null, new GameArgs() { Table = this });
            MyGameServer.UpdateClientTablesLists();
        }

        void RegisterEvents(IGameCallback callback)
        {
            JoinHandler += callback.OnJoin;
            LeaveHandler += callback.OnLeave;
            HitHandler += callback.OnHit;
            StandHandler += callback.OnStand;
            BetHandler += callback.OnBet;
            StatusHandler += callback.OnStatus;
            PlayerTurnHandler += callback.OnMyTurn;
            DealHandler += callback.OnDeal;
            DealerPlayHandler += callback.OnDealerPlay;
            ResetTableHandler += callback.OnResetTable;
        }

        void RemoveEvents(IGameCallback callback)
        {
            JoinHandler -= callback.OnJoin;
            LeaveHandler -= callback.OnLeave;
            HitHandler -= callback.OnHit;
            StandHandler -= callback.OnStand;
            BetHandler -= callback.OnBet;
            StatusHandler -= callback.OnStatus;
            PlayerTurnHandler -= callback.OnMyTurn;
            ResetTableHandler -= callback.OnResetTable;
        }

        public void DealNewGame()
        {
            _turn = Players.GetEnumerator();
            _turn.MoveNext();
            // Create a new deck and then shuffle the deck
            _deck = new Deck();
            _deck.Shuffle();

            Dealer.NewHand();

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


            Dealer.Hand.Cards.Add(_deck.Draw());
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

            DealHandler(null, new GameArgs() { Table = this });

            PlayerTurnHandler(null, new GameArgs() { Table = this });
        }

        internal void Hit(PlayerData player)
        {
            var pl = this.Players.Single(p => p == player);
            var c = d.Pop();
            //Players.Add(player);

            pl.Hand.Cards.Add(c);

            // check for black jack / bust

           

            HitHandler(null, new GameArgs() { Player = pl, Card = c });
            checkBlackJack(pl);
        }

        private void checkBlackJack(PlayerData pl)
        {
            if(pl.Hand.Value == 21)
            {
                StatusHandler("BlackJack!", new GameArgs() {Player = pl });
                CheckLastTurn();
            } else if ( pl.Hand.Value > 21 )
            {
                StatusHandler("Bust!",  new GameArgs() { Player = pl });
                CheckLastTurn();
            }
        }

        internal void Leave(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            var _ref = Players.SingleOrDefault(p => p.Username.Equals(player.Username));
            Players.Remove(_ref);
            
            var currentPlayer = _turn.Current;
            //if (player.Username == currentPlayer.Username)
            //{
            //    try
            //    {
            //        _turn.MoveNext();
            //    } catch (InvalidOperationException)
            //    {
            //        _turn = Players.GetEnumerator();
            //    }
            //    currentPlayer = _turn.Current;
            //}

            _turn = Players.GetEnumerator();
            while (_turn.Current != currentPlayer) _turn.MoveNext();
            

            LeaveHandler(null, new GameArgs() { Player = player });
            RemoveEvents(cb);

        }

        internal void Bet(PlayerData player, decimal amount, bool doubleBet)
        {
            var pl = this.Players.Single(p => p == player);
            pl.Bet = amount;
            BetHandler(null, new GameArgs() { Player = player, Amount = amount });
        }


        internal void Fold(PlayerData player)
        {
            StatusHandler(null, new GameArgs() { Player = player });
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
                PlayerTurnHandler(null, new GameArgs() { Player = _turn.Current, Table = this });
            }
            else {
                Dealer.Hand.Cards[1].IsCardUp = true;
                DealerPlayHandler(null, new GameArgs() { Player = this.Dealer });
                DealerPlay();
                EndGame();
            }
        }

        void DealerPlay()
        {
            
            while (Dealer.Hand.Value < 17)
            {
                Dealer.Hand.Cards.Add(_deck.Draw());
                DealerPlayHandler(null, new GameArgs() { Player = this.Dealer });
            }

        }

        void EndGame()
        {
            foreach(var p in Players)
            {
                if (Dealer.Hand.Value <= 21)
                {
                    if (p.Hand.Value == Dealer.Hand.Value)      // player tie
                    {
                        p.Bank += decimal.ToDouble(p.Bet);
                        StatusHandler("Tie!", new GameArgs() { Player = p });
                    }
                    else if (p.Hand.Value < Dealer.Hand.Value)   // player lose
                    {
                        p.Bank -= decimal.ToDouble(p.Bet);
                        StatusHandler("Lose!", new GameArgs() { Player = p });
                    }
                    else if (p.Hand.Value > Dealer.Hand.Value)   // player win
                    {
                        if (p.Hand.Value == 21) // player blackjack
                            p.Bank += decimal.ToDouble(2.4m * p.Bet);
                        else        // normal win
                        {
                            p.Bank += decimal.ToDouble(2 * p.Bet);
                            StatusHandler("Win!", new GameArgs() { Player = p });
                        }
                    }
                } else
                {
                    if (p.Hand.Value <= 21)
                    {
                        p.Bank += decimal.ToDouble(2 * p.Bet);
                        StatusHandler("Win!", new GameArgs() { Player = p });
                    }
                }
                p.Bet = 0; 
            }

            _inGame = false;

            Thread.Sleep(10000);
            ResetTableHandler(null, new GameArgs() { Table = this });
            //
            //DealNewGame();
        }
    }
}