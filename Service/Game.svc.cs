using Service.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Web;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Game : IGame
    {
        static void Main()
        {
            var bindings = new Uri[] { new Uri("http://localhost:51845/Game.svc"), new Uri("net.tcp://localhost:2305") };
            using (var host = new ServiceHost(typeof(Game), bindings))
            {
                host.Open();
                foreach(var b in bindings)
                {
                    Console.WriteLine("Service listening on {0}", b);
                }
                Console.WriteLine("Press ENTER to stop the service");
                Console.ReadLine();
                host.Close();
            }
        }

        IDictionary<string, PlayerData> sessions = new Dictionary<string, PlayerData>();
        List<Table> Tables = new List<Table>();

        event EventHandler<IList<Table>> TableListUpdatedHandler;

        object locker = new object();

        PlayerData CurrentPlayer
        {
            get
            {
                return sessions[OperationContext.Current.SessionId];
            }
            set
            {
                lock (locker)
                {
                    sessions[OperationContext.Current.SessionId] = value;
                }
            }
        }

        Table CurrentTable
        {
            get
            {
                return Tables.SingleOrDefault(t => t.Players.Contains(CurrentPlayer));
            }
        }

        public void Bet(decimal amount, bool doubleBet = false)
        {
            CurrentPlayer.Bet = amount;
            CurrentTable?.Bet(CurrentPlayer, doubleBet);
        }

        public void CreateTable()
        {
            var t = new Table(this);
            Tables.Add(t);
            UpdateClientTablesLists();
        }

        public void UpdateClientTablesLists()
        {
            var deadSessions = new List<string>();
            foreach (var pair in sessions)
            {
                try
                {
                    pair.Value.Callback.OnTableListUpdate(null, Tables);
                }
                catch (Exception)
                {
                    deadSessions.Add(pair.Key);
                }
            }

            deadSessions.ForEach(s =>
            {
                TableListUpdatedHandler -= sessions[s].Callback.OnTableListUpdate;
                sessions.Remove(s);
            });
        }

        public void Hit()
        {
            CurrentTable?.Hit(CurrentPlayer);
        }

        public Table JoinTable(int tableIndex)
        {
            ///////////////////////////////////////////////////TODO Is table full or already playing
            if (tableIndex < 0 || tableIndex > Tables.Count)
                return null;

            var table = Tables[tableIndex];
            if (table.InGame)
                return null;

            table?.Join(CurrentPlayer);
            TableListUpdatedHandler(null, Tables);
            return table;
        }

        public void Leave()
        {
            var t = CurrentTable;
            t?.Leave(CurrentPlayer);
            if (t?.Players.Count == 0)
                Tables.Remove(t);
            TableListUpdatedHandler(null, Tables);
        }

        public IList<Table> ListTables()
        {
            return Tables;
        }

        public PlayerData Login(string username, string pass)
        {
            using (var db = new DBContainer())
            {
                try
                {
                    var player = db.Players.SingleOrDefault(p => p.Username.Equals(username) && p.Password.Equals(pass));

                    if (player == null)
                        return null;
                    var cb = OperationContext.Current.GetCallbackChannel<IGameCallback>();

                    var retPlayer = new PlayerData()
                    {
                        Bank = player.Bank,
                        MemberSince = player.MemberSince,
                        Username = player.Username,
                        Callback = cb
                    };

                    TableListUpdatedHandler += cb.OnTableListUpdate;
                    CurrentPlayer = retPlayer;

                    return retPlayer;
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                }
            }
            return null;
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

        public void Deal()
        {
            CurrentPlayer.IsReady = true;
            CurrentTable?.CheckReady();
        }

        public void Stand()
        {
            CurrentTable?.Stand(CurrentPlayer);
        }
    }
}
