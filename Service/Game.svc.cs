using Blackjack.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Blackjack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior]
    public class Game : IGame
    {
        DataClassesDataContext db = new DataClassesDataContext();
        IDictionary<string, Player> sessions = new Dictionary<string, Player>();

        public Player GetPlayerInfo(string username)
        {
            return db.Players.FirstOrDefault(p => p.Username.Equals(username));
        }

        public Player Login(string username, string pass)
        {
            var user = db.Players.FirstOrDefault(p => p.Username.Equals(username) && p.Password.Equals(pass));
            sessions[ServiceSecurityContext.Current.PrimaryIdentity.Name] = user;
            return user;
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
    }
}
