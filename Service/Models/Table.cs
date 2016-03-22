using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Collections.Specialized;
using System.Timers;

namespace Service.Models
{
    [DataContract]
    public class Table
    {
        [DataMember]
        public IList<PlayerData> Players { get; set; }

        [DataMember]
        public Guid Id { get; set; }

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
                Server.UpdateClientTablesLists();
            }
        }


        private bool _inGame;
        private Deck _deck;

        private IEnumerator<PlayerData> _turn;


        private Service.Game Server { set; get; }

        #region Game Events


        internal event EventHandler<GameArgs> JoinHandler;
        internal event EventHandler<GameArgs> LeaveHandler;
        event EventHandler<GameArgs> HitHandler;
        event EventHandler<GameArgs> StandHandler;
        event EventHandler<GameArgs> BetHandler;
        event EventHandler<GameArgs> RoundResultHandler;
        event EventHandler<GameArgs> PlayerTurnHandler;
        event EventHandler<GameArgs> DealHandler;
        event EventHandler<GameArgs> DealerPlayHandler;
        event EventHandler<GameArgs> ResetTableHandler;
        #endregion

        [DataMember]
        Deck d = new Deck();

        public Table(Service.Game service)
        {
            Server = service;
            Id = Guid.NewGuid();
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
        }

        void RegisterEvents(IGameCallback callback)
        {
            JoinHandler += callback.OnJoin;
            JoinHandler += (sender, args) => Server.UpdateClientTablesLists();
            LeaveHandler += callback.OnLeave;
            HitHandler += callback.OnHit;
            StandHandler += callback.OnStand;
            BetHandler += callback.OnBet;
            RoundResultHandler += callback.OnRoundResult;
            PlayerTurnHandler += callback.OnMyTurn; //Improve
            DealHandler += callback.OnDeal;
            DealerPlayHandler += callback.OnDealerPlay;
            ResetTableHandler += callback.OnResetTable;
        }

        void RemoveEvents(IGameCallback callback)
        {
            JoinHandler -= callback.OnJoin;
            JoinHandler -= (sender, args) => Server.UpdateClientTablesLists();
            LeaveHandler -= callback.OnLeave;
            HitHandler -= callback.OnHit;
            StandHandler -= callback.OnStand;
            BetHandler -= callback.OnBet;
            RoundResultHandler -= callback.OnRoundResult;
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



            if (Players.Any(p => p.Hand.Value < 21))
            {

                using (var db = new DBContainer())
                {
                    while (_turn.Current.Hand.Value >= 21)
                    {
                        SendResult(_turn.Current, db);
                        _turn.MoveNext();
                    }
                    db.SaveChanges();
                }
                PlayerTurnHandler(null, new GameArgs() { Table = this, Player = _turn.Current });
            }
            else
            {
                while (_turn.Current != null) _turn.MoveNext();
                CheckLastTurn();
            }
        }

        internal void Hit(PlayerData player)
        {
            if (!_turn.Current.Username.Equals(player.Username))
                return;

            var pl = Players.First(p => p.Username.Equals(player.Username));

            var c = d.Pop();
            //Players.Add(player);

            pl.Hand.Cards.Add(c);

            // check for black jack / bust
            var args = new GameArgs();
            args.Table = this;
            args.Card = c;
            args.Player = pl;

            if (pl.Hand.Value == 21)
            {
                //StatusHandler("BlackJack!", new GameArgs() { Player = pl });
                args.Message = "Blackjack!";
            }
            else if (pl.Hand.Value > 21)
            {
                //StatusHandler("Bust!", new GameArgs() { Player = pl });
                args.Message = "Bust!";
            }

            HitHandler(null, args);
            if (pl.Hand.Value >= 21)
                CheckLastTurn();
        }

        internal PlayerData Leave(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            var _ref = Players.SingleOrDefault(p => p.Username.Equals(player.Username));
            Players.Remove(_ref);

            var currentPlayer = _turn.Current;

            _turn = Players.GetEnumerator();
            do
            {
                _turn.MoveNext();
            }
            while (Players.Count > 0 && _turn.Current != currentPlayer);

            player.Winnings = 0;
            player.LostHands = 0;
            player.WonHands = 0;
            player.IsReady = false;
            LeaveHandler(null, new GameArgs() { Player = player, Table = this });
            RemoveEvents(cb);
            return player;
        }

        internal void Bet(PlayerData player, bool doubleBet)
        {
            var pl = Players.Single(p => p.Username.Equals(player.Username));
            pl.Bet = doubleBet ? 2 * player.Bet : player.Bet;
            pl = player;
            BetHandler(null, new GameArgs() { Player = player, Amount = player.Bet, Table = this });
        }

        /// <summary>
        /// Check if all players are ready to play
        /// </summary>
        internal void CheckReady()
        {
            if (Players.Any(p => !p.IsReady))
                return;

            // Start The Game
            _inGame = true;

            DealNewGame();

        }

        internal void Stand(PlayerData currentPlayer)
        {
            CheckLastTurn();
            StandHandler(null, new GameArgs() { Player = currentPlayer, Table = this });
        }

        void CheckLastTurn()
        {
            if (_turn.MoveNext())
            {
                PlayerTurnHandler(null, new GameArgs() { Player = _turn.Current, Table = this });
            }
            else {
                if (Players.Any(p => p.Hand.Value < 21))
                    DealerPlay();
                else
                    EndGame();
            }
        }

        void DealerPlay()
        {
            Dealer.Hand.Cards[1].IsCardUp = true;
            DealerPlayHandler(null, new GameArgs() { Player = Dealer });
            /*while (Dealer.Hand.Value < 17)
            {
                Dealer.Hand.Cards.Add(_deck.Draw());
                DealerPlayHandler(null, new GameArgs() { Player = Dealer });
            }

            int handToBeat = Players.Max(p => p.Hand.Value);
            int potentialWins = Players.Count(p => p.Hand.Value > 21 || p.Hand.Value < Dealer.Hand.Value);
            while (Dealer.Hand.Value < handToBeat && potentialWins <= Players.Count / 2 && Dealer.Hand.Value < 21)
            {
                Dealer.Hand.Cards.Add(_deck.Draw());
                DealerPlayHandler(null, new GameArgs() { Player = Dealer });
                potentialWins = Players.Count(p => p.Hand.Value > 21 || p.Hand.Value < Dealer.Hand.Value);
            }*/
            
            //Smart dealer
            int handToBeat = Players.Max(p => p.Hand.Value);
            int potentialWins = Players.Count(p => p.Hand.Value > 21 || p.Hand.Value <= Dealer.Hand.Value);
            Timer t = new Timer(500);
            t.AutoReset = true;
            t.Elapsed += (sender, args) =>
            {
                if (Dealer.Hand.Value > handToBeat || potentialWins >= Math.Ceiling(Players.Count / 2f) || Dealer.Hand.Value >= 21)
                {
                    t.Stop();
                    EndGame();
                    return;
                }
                Dealer.Hand.Cards.Add(_deck.Draw());
                DealerPlayHandler(null, new GameArgs() { Player = Dealer });
                potentialWins = Players.Count(p => p.Hand.Value > 21 || p.Hand.Value <= Dealer.Hand.Value);
            };
            t.Start();
        }

        internal async void EndGame()
        {
            using (var db = new DBContainer())
            {
                foreach (var p in Players.AsParallel())
                    SendResult(p, db);

                //Batch save DAL
                await db.SaveChangesAsync();
            }

            foreach (var p in Players)
            {
                p.IsReady = false;
                p.Bet = 0;
            }

            _inGame = false;

            //Let see the end results without blocking other tables
            Timer t = new Timer(7000);
            t.AutoReset = false;
            t.Elapsed += (sender, e) =>
            {
                ResetTableHandler(null, new GameArgs() { Table = this });
                t.Stop();
            };
            t.Start();
        }

        private void SendResult(PlayerData p, DBContainer db, string customMessage = null)
        {
            var args = new GameArgs();
            args.Player = p;
            args.Table = this;
            if (p.Hand.Value <= 21)
            {
                if (Dealer.Hand.Value <= 21)
                {
                    if (p.Hand.Value == Dealer.Hand.Value)      // player tie
                    {
                        args.Message = "Tie!";
                        p.Bank += p.Bet;
                    }
                    else if (p.Hand.Value < Dealer.Hand.Value)   // player lose
                    {

                        args.Message = "Lose!";
                        p.LostHands++;
                        p.Bank -= p.Bet;
                        p.Winnings -= p.Bet;
                    }
                    else if (p.Hand.Value > Dealer.Hand.Value)   // player win
                    {
                        if (p.Hand.Value == 21)
                            args.Message = "Blackjack!";
                        else
                            args.Message = "Win!";
                        p.WonHands++;
                        p.Bank += p.Bet;

                        if (p.Hand.Value == 21)
                        { // player blackjack
                            p.Blackjacks++;
                            p.Bank += 2.4m * p.Bet;
                            p.Winnings += 1.4m * p.Bet;
                        }
                        else        // normal win
                        {
                            p.Bank += 2 * p.Bet;
                            p.Winnings += p.Bet;
                        }
                    }
                }
                else
                {
                    p.WonHands++;
                    if (p.Hand.Value == 21)
                    { // player blackjack
                        args.Message = "Blackjack!";
                        p.Blackjacks++;
                        p.Bank += 2.4m * p.Bet;
                        p.Winnings += 1.4m * p.Bet;
                    }
                    else      // normal win
                    {
                        args.Message = "Win!";
                        p.Bank += p.Bet;
                        p.Winnings += p.Bet;
                    }
                }
            }
            else
            {
                args.Message = "Bust!";
                p.LostHands++;
                p.Bank -= p.Bet;
                p.Winnings -= p.Bet;
            }
            args.Message += " " + customMessage;
            RoundResultHandler(null, args);
            p.Bet = 0;
            p.IsReady = false;

            //Update DAL
            UpdateDALPlayer(db, p);
        }

        internal void UpdateDALPlayer(DBContainer db, PlayerData p)
        {
            var dalPlayer = db.Players.Single(player => player.Username.Equals(p.Username));
            //Update bank
            dalPlayer.Bank = p.Bank;

            var dalGame = dalPlayer.Games.SingleOrDefault(entry => entry.GameId == Id);
            //Update table stats
            if (dalGame == null)
            {
                dalGame = new Game();
                db.Games.Add(dalGame);
            }
            dalGame.Player = dalPlayer;
            dalGame.GameId = Id;
            dalGame.Winnings = p.Winnings;
            dalGame.Blackjacks = p.Blackjacks;
            dalGame.PlayedOn = DateTime.UtcNow;
            dalGame.LostHands = p.LostHands;
            dalGame.WonHands = p.WonHands;
            dalGame.TotalHands++;
        }
    }
}