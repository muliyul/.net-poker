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
        IList<Table> Tables = new List<Table>();
  
        private static object locker = new object();
        PlayerData CurrentPlayer
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

        public void Bet(string guid, int amount)
        {
            var CurrentPlayer = sessions[guid];
            CurrentTable.Bet(CurrentPlayer, amount);
        }

        public void CreateTable(string playerGuid)
        {
            var t = new Table();
            Tables.Add(t);

            foreach (var client in sessions.Values /*.Where(p => !p.Guid.Equals(playerGuid))*/)
            {
               sessions[playerGuid].myCallbacks.OnNewTableCreated("8", new GameArgs());
               // sessions[playerGuid].myCallbacks.OnBet(null, null);
            }
            
           // return t;
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
                    myCallbacks = OperationContext.Current.GetCallbackChannel<IGameCallback>()

                    };

            }
            
        }

        public Table GetTable()
        {
            throw new NotImplementedException();
        }

        public void Hit()
        {
            CurrentTable?.Hit(CurrentPlayer);
        }

        public Table JoinTable(string playerGuid, string tableId)
        {
            var currentPlayer = sessions[playerGuid];
            if (currentPlayer == null) return null;
       
            var table = Tables.SingleOrDefault(t => t.Id == tableId);
         //   table?.Join(currentPlayer);

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
                        Guid = newGuid.ToString(),
                        myCallbacks = OperationContext.Current.GetCallbackChannel<IGameCallback>()
                    };
                    sessions[newGuid.ToString()] = retPlayer;
                 
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

        public Table PlayerReady(string playerGuid, string tableId)
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


 
    }
}
