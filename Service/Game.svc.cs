using Service.Models;
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

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Game : IGame
    {
        IDictionary<string, Player> sessions = new Dictionary<string, Player>();
        IList<Table> Tables = new List<Table>();

        Player CurrentPlayer
        {
            get
            {
                
                return null;
            }
        }

        Table CurrentTable
        {
            get
            {
                return null;
            }
        }

        public void Bet(int amount)
        {
            CurrentTable.Bet(CurrentPlayer, amount);
        }

        public Shared.Table CreateTable()
        {
            var t = new Table();
            Tables.Add(t);
            t.Join(CurrentPlayer);
            return t;
        }

        public void Fold()
        {
            CurrentTable?.Fold(CurrentPlayer);
        }

        public Player GetPlayerInfo(string username)
        {
            using (var db = new DBContainer())
            {
                var player = db.Players.SingleOrDefault(p => p.Username == username);
                return player;
            }
        }

        public void Hit()
        {
            CurrentTable?.Hit(CurrentPlayer);
        }

        public Shared.Table JoinTable(string tableId)
        {
            var table = Tables.SingleOrDefault(t => t.Id == tableId);
            table?.Join(CurrentPlayer);
            return table;
        }

        public void Leave()
        {
            CurrentTable?.Leave(CurrentPlayer);
        }

        public IEnumerable<Shared.Table> ListTables()
        {
            return Tables.AsEnumerable();
        }

        public Player Login(string username, string pass)
        {
            using (var db = new DBContainer())
            {
                var player = db.Players.SingleOrDefault(p => p.Username == username && p.Password == pass);
                var newGuid = Guid.NewGuid();
                // sessions[newGuid] = player;
                var px = ServiceSecurityContext.Current;

                return player;
            }
        }

        public void Register(string username, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
