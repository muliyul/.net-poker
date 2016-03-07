using Blackjack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Collections.Specialized;

namespace Blackjack.Models
{
    [DataContract]
    public class Table : SharedModels.Table
    {
       

        #region Game Events
        event EventHandler<GameArgs> JoinHandler;
        event EventHandler<GameArgs> LeaveHandler;
        event EventHandler<GameArgs> HitHandler;
        event EventHandler<GameArgs> BetHandler;
        event EventHandler<GameArgs> FoldHandler;
        event EventHandler<GameArgs> NextTurnHandler;
        #endregion

        public Table() { Id = Guid.NewGuid().ToString(); }
        

        internal void Join(Player player)
        {
            var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();

        }

        private void NextRound()
        {

        
        }

        internal Card Hit(Player player)
        {
            throw new NotImplementedException();
        }

        internal void Leave(Player player)
        {
            throw new NotImplementedException();
        }

        internal void Bet(Player currentPlayer, int amount)
        {
            throw new NotImplementedException();
        }

        internal void Fold(Player player)
        {
            throw new NotImplementedException();
        }

        internal class PlayerContainer
        {
            public PlayerContainer(Player p, IGameCallback cb)
            {
                Player = p;
                Callback = cb;
            }

            public Player Player { get; set; }
            public IGameCallback Callback { get; set; }
        }
    }

    public class GameArgs : EventArgs
    {
        public Player Player { get; set; }
        public int Amount { get; set; }
        public Card Card { get; set; }
    }
}