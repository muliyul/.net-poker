using Blackjack.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Collections.Specialized;

namespace Blackjack
{
    [DataContract]
    public class Table
    {
        #region Client fields, properties
        //These are transferred over the service to the client so they must be decalred as [DataMember] - means Serializeable
        [DataMember]
        public IEnumerable<Player> Players
        {
            get
            {
                return players.Select(t => t.Item1);
            }
        }

        [DataMember]
        public int Id { get; internal set; }

        [DataMember]
        public int Pot { get; internal set; }

        #endregion

        #region Server fields, properties
        Deck deck = new Deck();
        //player id -> player
        IList<Tuple<Player, IGameCallback>> players = new List<Tuple<Player, IGameCallback>>();
        IEnumerator<Tuple<Player, IGameCallback>> turns;

        Player CurrentPlayer
        {
            get
            {
                return turns.Current.Item1;
            }
        }
        #endregion

        #region Game Events
        delegate void GameUpdate(object sender, object arg);
        event GameUpdate JoinEvent;
        event GameUpdate LeaveEvent;
        event GameUpdate RoundStartEvent;
        event GameUpdate BetEvent;
        event GameUpdate HitEvent;
        event GameUpdate FoldEvent;
        event GameUpdate RoundEndEvent;
        #endregion

        public Table() { }

        public Table(Player p)
        {
            Join(p);
            turns = players.GetEnumerator();
            InitializeRound();
        }

        private void InitializeRound()
        {
            //Sleep here for few seconds to let clients see the actual results?

            Pot = 0;
            deck.Shuffle();
            RoundStartEvent(this, null);
        }

        internal void Join(Player p)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            players.Add(new Tuple<Player, IGameCallback>(p, cb));

            //Register all events
            JoinEvent += cb.OnJoin;
            LeaveEvent += cb.OnLeave;
            RoundStartEvent += cb.OnRoundStarted;
            BetEvent += cb.OnBet;
            HitEvent += cb.OnHit;
            FoldEvent += cb.OnFold;
            RoundEndEvent += cb.OnRoundEnded;
            JoinEvent(p, null);
        }

        internal void Leave(Player p)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            players.Remove(players.First(t => t.Item1 == p));

            //Remove all events
            JoinEvent -= cb.OnJoin;
            LeaveEvent -= cb.OnLeave;
            RoundStartEvent -= cb.OnRoundStarted;
            BetEvent -= cb.OnBet;
            HitEvent -= cb.OnHit;
            FoldEvent -= cb.OnFold;
            RoundEndEvent -= cb.OnRoundEnded;

            LeaveEvent(p, null);
        }

        internal void Bet(Player p, int amount)
        {
            BetEvent(p, amount);
        }

        internal Card Hit(Player p)
        {
            var c = deck.Pop();
            HitEvent(p, c);
            RoundEndEvent(this, null);
            if (!turns.MoveNext())
            {
                turns = players.GetEnumerator();
                InitializeRound();
            }
            return c;
        }

        internal void Fold(Player p)
        {
            FoldEvent(p, null);
            RoundEndEvent(this, null);
            if (!turns.MoveNext())
            {
                turns = players.GetEnumerator();
                InitializeRound();
            }
        }
    }
}