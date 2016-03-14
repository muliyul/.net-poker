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
        IList<Player> players = new List<Player>();

        [DataMember]
        public IList<PlayerData> Players { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int Pot { get; set; }

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

        public Table() { Id = Guid.NewGuid().ToString(); }


        internal void Join(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            RegisterEvents(cb);
            JoinHandler(this, new GameArgs() { Player = player });
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

        internal void Hit(PlayerData player)
        {
            var c = d.Pop();
            Players.Add(player);
            //player.Hand.Add(c);
            HitHandler(this, new GameArgs() { Player = player, Card = c });
        }

        internal void Leave(PlayerData player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            RemoveEvents(cb);
            LeaveHandler(this, new GameArgs() { Player = player });
        }

        internal void Bet(PlayerData player, int amount)
        {
            BetHandler(this, new GameArgs() { Player = player, Amount = amount });
        }


        internal void Fold(PlayerData player)
        {
            FoldHandler(this, new GameArgs() { Player = player });
        }
    }
}