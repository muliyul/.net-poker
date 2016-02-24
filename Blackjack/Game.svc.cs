using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Blackjack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior]
    public class Game : IGame
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public Player GetMyInfo()
        {
            string authenticatedUser = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
            if (authenticatedUser == null)
                return null;

            return db.Players.First(p => authenticatedUser.Equals(p.Username));
        }

        public Player GetPlayerInfo(string user)
        {
            return db.Players.First(p => p.Username.Equals(user));
        }

        public void Register(string user, string pass)
        {
            try
            {
                db.Players.InsertOnSubmit(new Player { Username = user, Password = pass, Bank = 4000 });
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new FaultException("Username already exists!");
            }
        }
    }
}
