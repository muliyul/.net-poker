using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Blackjack
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IGameCallback))]
    public interface IGame
    {
        [OperationContract]
        void Register(string username, string pass);

        [OperationContract]
        Player Login(string username, string pass);

        [OperationContract]
        Player GetPlayerInfo(string username);

        [OperationContract]
        IEnumerable<Table> ListTables();

        //IsInitiating decides whenever the call to this method deletes the session
        [OperationContract(IsTerminating = true)]
        void Logout();

        //IsInitiating decides whenever the call to this method creates session
        [OperationContract(IsInitiating = false)]
        Table CreateTable();

        [OperationContract(IsInitiating = false)]
        Table JoinTable(string tableId);

        //IsOneWay - Launch & Forget
        [OperationContract(IsOneWay = true, IsInitiating = false)]
        void Leave();

        [OperationContract(IsOneWay = true, IsInitiating = false)]
        void Bet(int amount);

        [OperationContract(IsInitiating = false)]
        Card Hit();

        [OperationContract(IsOneWay = true, IsInitiating = false)]
        void Fold();
    }
}
