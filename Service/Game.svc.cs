using Blackjack.Models;
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
                var key = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                return sessions[key];
            }
        }
        Table CurrentPlayerTable
        {
            get
            {
                return Tables.FirstOrDefault(t => t.Players.FirstOrDefault(p => p!=null) != null);
            }
        }

        public void Bet(int amount)
        {
            CurrentPlayerTable?.Bet(CurrentPlayer, amount);
        }

        public SharedModels.Table CreateTable()
        {
            var t = new Table();
            Tables.Add(t);
            return JoinTable(t.Id) as SharedModels.Table;
        }

        public void Fold()
        {
            CurrentPlayerTable?.Fold(CurrentPlayer);
        }

        public SharedModels.Player GetPlayerInfo(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;
            using (var db = new DBContainer())
            {
                var player = db.Players.FirstOrDefault(p => p.Username.Equals(username));
                if(player != null)
                    return new SharedModels.Player()
                    {
                        Id = player.Id,
                        Bank = player.Bank,
                        MemberSince = player.MemberSince,
                        Username = player.Username
                    };
                
            }
            return null;
        }

        public SharedModels.Card Hit()
        {
            return CurrentPlayerTable?.Hit(CurrentPlayer);
        }

        public SharedModels.Table JoinTable(string tableId)
        {
            var table = Tables.FirstOrDefault(t => t.Id == tableId);
            //table.Join(CurrentPlayer);
            return table as SharedModels.Table;
        }

        public void Leave()
        {
            CurrentPlayerTable?.Leave(CurrentPlayer);
        }

        public IEnumerable<SharedModels.Table> ListTables()
        {
            return Tables;
        }

        public SharedModels.Player Login(string username, string pass)
        {
            //Hash password and verify?
            Player player;
            using (var db = new DBContainer())
            {
                player = db.Players.FirstOrDefault(p =>
                p.Username.Equals(username) && p.Password.Equals(pass));
                sessions[ServiceSecurityContext.Current.PrimaryIdentity.Name] = player;

                return new SharedModels.Player()
                {
                    Id = player.Id,
                    Bank = player.Bank,
                    MemberSince = player.MemberSince,
                    Username = player.Username
                };
            }
        }

        public void Logout()
        {
            CurrentPlayerTable?.Leave(CurrentPlayer);
            sessions[ServiceSecurityContext.Current.PrimaryIdentity.Name] = null;
        }

        public void Register(string user, string pass)
        {
            try
            {
                using (var db = new DBContainer())
                {
                    db.Players.Add(new Player { Username = user, Password = pass, MemberSince = DateTime.Now, Bank = 4000 });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new FaultException("Username already exists!");
            }
        }
    }
}
