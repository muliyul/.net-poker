using Blackjack.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Blackjack
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Game : IGame
    {
        DataClassesDataContext db = new DataClassesDataContext();
        IList<Player> sessions = new List<Player>();
        IDictionary<Player, Table> playersToTablesMap = new Dictionary<Player, Table>();
        IEnumerable<Table> Tables
        {
            get
            {
                return playersToTablesMap.Values.AsEnumerable();
            }
        }
        Tuple<Player, Table> CurrentPlayer
        {
            get
            {
                var identity = ServiceSecurityContext.Current.PrimaryIdentity;
                var player = sessions.First(p => p.Identity == identity);
                var table = playersToTablesMap[player];
                return new Tuple<Player, Table>(player, table);
            }
        }

        public void Bet(int amount)
        {
            CurrentPlayer.Item2?.Bet(CurrentPlayer.Item1, amount);
        }

        public Table CreateTable()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerInfo(string username)
        {
            return db.Players.FirstOrDefault(p => p.Username.Equals(username));
        }

        public Card Hit()
        {
            return CurrentPlayer.Item2?.Hit(CurrentPlayer.Item1);
        }

        public Table JoinTable(int tableId)
        {
            var table = Tables.FirstOrDefault(t => t.Id == tableId);
            table?.Join(CurrentPlayer.Item1);
            return table;
        }

        public void Leave()
        {
            CurrentPlayer.Item2?.Leave(CurrentPlayer.Item1);
        }

        public IEnumerable<Table> ListTables()
        {
            return Tables;
        }

        public Player Login(string username, string pass)
        {
            //Hash password and verify?
            var player = db.Players.First(p => p.Username.Equals(username) && p.Password.Equals(pass));
            player.Identity = ServiceSecurityContext.Current.PrimaryIdentity;
            sessions.Add(player);
            return player;
        }

        public void Logout()
        {
            CurrentPlayer.Item1.Identity = null;
            sessions.Remove(CurrentPlayer.Item1);
        }

        public void Register(string user, string pass)
        {
            try
            {
                db.Players.InsertOnSubmit(new Player { Username = user, Password = pass });
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new FaultException("Username already exists!");
            }
        }

        public void Fold()
        {
            CurrentPlayer.Item2.Fold(CurrentPlayer.Item1);
        }
    }
}
