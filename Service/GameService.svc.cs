using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.ServiceModel;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GameService : IGameService
    {
        IDictionary<string, Models.Player> sessions = new Dictionary<string, Models.Player>();
        IList<Table> Tables = new List<Table>();

        Models.Player CurrentPlayer
        {
            get
            {
                return sessions[OperationContext.Current.SessionId];
            }
        }

        Table CurrentTable
        {
            get
            {
                return Tables.SingleOrDefault(t => t.Players.Contains(CurrentPlayer));
            }
        }

        public void Bet(int amount)
        {
            var CurrentPlayer = sessions[OperationContext.Current.SessionId];
            CurrentTable?.Bet(CurrentPlayer, amount);
        }

        public void CreateTable()
        {
            var t = new Table();
            Tables.Add(t);
            foreach (var s in sessions.Values)
            {
                try
                {
                    s.Callback.OnNewTableCreated(t, null);
                }
                catch (Exception e) { sessions.Remove(sessions.Keys.First(k => sessions[k] == s)); }
            }
        }

        public void Fold()
        {
            CurrentTable?.Fold(CurrentPlayer);
        }

        public Models.Player GetPlayerInfo(string username)
        {
            using (var db = new DBContainer())
            {
                var player = db.Players.SingleOrDefault(p => p.Username == username);
                return new Models.Player(player);
            }
        }

        public void Hit()
        {
            CurrentTable?.Hit(CurrentPlayer);
        }

        public Table JoinTable(string tableId)
        {
            var table = Tables.SingleOrDefault(t => t.Id == tableId);
            table?.Join(CurrentPlayer);

            return table;
        }

        public void Leave()
        {
            CurrentTable?.Leave(CurrentPlayer);
        }

        public IEnumerable<Table> ListTables()
        {
            return Tables.AsEnumerable();
        }

        public Models.Player Login(string username, string pass)
        {
            using (var db = new DBContainer())
            {
                var player = db.Players.SingleOrDefault(p => p.Username == username && p.Password == pass);
                return new Models.Player(player, true);
            }
        }

        public Table PlayerReady(string tableId)
        {
            throw new NotImplementedException();
        }

        public void Register(string username, string pass)
        {
            using (var db = new DBContainer())
            {
                try
                {
                    db.Players.Add(new Player()
                    {
                        Username = username,
                        Password = pass,
                        Bank = 4000,
                        MemberSince = DateTime.Now
                    });
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }
        }
    }
}
