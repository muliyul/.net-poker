using Blackjack.Objects;
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
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("No username provided");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("No password proveded");

            using (var db = new DataClassesDataContext())
            {
                var player = db.Players.FirstOrDefault(p => p.Username.Equals(userName) && p.Password.Equals(password));
                if (player == null)
                    throw new FaultException("Wrong username or password");
            }
        }
    }
}