
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    [ServiceContract(CallbackContract = typeof(IGameCallback), SessionMode = SessionMode.Required)]
    public interface IGameService
    {
        [OperationContract]
        void Register(string username, string pass);

        [OperationContract]
        Models.Player Login(string username, string pass);

        [OperationContract]
        Models.Player GetPlayerInfo(string username);

        [OperationContract]
        IEnumerable<Table> ListTables();

        [OperationContract(IsOneWay = true)]
        void CreateTable();

        [OperationContract]
        Table JoinTable(string tableId);
        [OperationContract]
        Table PlayerReady(string tableId);

        [OperationContract(IsOneWay = true)]
        void Leave();

        [OperationContract(IsOneWay = true)]
        void Bet(int amount);

        [OperationContract(IsOneWay = true)]
        void Hit();

        [OperationContract(IsOneWay = true)]
        void Fold();
    }
}
