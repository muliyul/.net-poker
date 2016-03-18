using Service.Models;
using System;
using System.Collections.Generic;
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
        IDictionary<string, PlayerData> sessions = new Dictionary<string, PlayerData>();
        private static Dictionary<string, IGameCallback> clients =
                new Dictionary<string, IGameCallback>();
        static IList<Table> Tables = new List<Table>();
  
        PlayerData CurrentPlayer
        {
            get
            {
                return sessions[OperationContext.Current.SessionId];
            }
            set
            {
                sessions[OperationContext.Current.SessionId] = value;
            }
        }

        Table CurrentTable
        {
            get
            {
                return Tables.SingleOrDefault(t => t.Players.Contains(CurrentPlayer));
            }
        }

        public void Bet( decimal amount, bool doubleBet = false)
        {
            CurrentTable?.Bet(CurrentPlayer, amount, doubleBet);
        }

        public void CreateTable()
        {
            var t = new Table();
            t.MyGameServer = this;
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
                    pair.Value.Callback.OnNewTableCreated(null, Tables);
                }
                catch (Exception)
                {
                    deadSessions.Add(pair.Key);
                }
            }
            deadSessions.ForEach(s => sessions.Remove(s));
        }
        public void Fold()
        {
            CurrentTable?.Fold(CurrentPlayer);
        }

        public Models.PlayerData GetPlayerInfo(string username)
        {
            using (var db = new DBContainer())
            {
                var player = db.Players.SingleOrDefault(p => p.Username == username);
                 if (player == null) return null;
                return new PlayerData()
                {
                    Bank = player.Bank,
                    Id = player.Id,
                    //Hand = player.Hand,
                    MemberSince = player.MemberSince,
                    Username = player.Username,
                    Callback = OperationContext.Current.GetCallbackChannel<IGameCallback>()

                 };

            }
            
        }
        

        public void Hit()
        {
            CurrentTable?.Hit(CurrentPlayer);
        }

        public Table JoinTable( int tableIndex)
        {
            ///////////////////////////////////////////////////TODO Is table full or already playing
            if (tableIndex < 0 || tableIndex > Tables.Count)
                return null;

            var table = Tables[tableIndex];
            if (table.InGame)
                return null;

            table?.Join(CurrentPlayer);
            CurrentPlayer.CurrentTable = table;
            UpdateClientTablesLists();
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

        public PlayerData Login(string username, string pass)
        {
            using (var db = new DBContainer())
            {
                try
                {
                    var player = db.Players.SingleOrDefault(p => p.Username == username && p.Password == pass);
                    var newGuid = Guid.NewGuid();

                    var retPlayer = new PlayerData()
                    {
                        Bank = player.Bank,
                        Id = player.Id,
                        // Hand =// player.Hand,
                        // MemberSince = player.MemberSince,
                        Username = player.Username,
                        
                        Callback = OperationContext.Current.GetCallbackChannel<IGameCallback>()
                    };
                    CurrentPlayer = retPlayer;
                 
                    return retPlayer;
                } catch (InvalidOperationException)
                {
                    
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                }
            }
            return null;
        }

        public Table PlayerReady(string tableId)
        {
            throw new NotImplementedException();
        }

        public void Register(string username, string pass)
        {
            using (var db = new DBContainer())
            {
                if (GetPlayerInfo(username) == null)
                {
                    try
                    {
                        db.Players.Add(new Player()
                        {
                            Username = username,
                            Password = pass,
                            Bank = 4000,
                            Guid ="",
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

        public void Deal()
        {
            CurrentPlayer.IsReady = true;
            CurrentTable.CheckReady();
        }

        public void Stand()
        {
            CurrentTable?.Stand(CurrentPlayer);
        }
    }
}
