﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Blackjack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IGame
    {
        [OperationContract]
        void Register(string user, string pass);

        [OperationContract]
        Player GetPlayerInfo(string user);

        [OperationContract]
        Player GetMyInfo();
    }
}
