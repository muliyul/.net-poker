using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Blackjack
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            using (var db = new DataClassesDataContext())
            {
                var player = db.Players.First(p => p.Username.Equals(userName) && p.Password.Equals(password));
                if (player == null)
                    throw new FaultException("Wrong username or password");
            }
        }
    }
}