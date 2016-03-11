
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
    [ServiceContract(CallbackContract = typeof(IGameCallback))]
    public interface IGame
    {
        [OperationContract]
        void Register(string username, string pass);

        [OperationContract]
        PlayerData Login(string username, string pass);

        [OperationContract]
        PlayerData GetPlayerInfo(string username);

        [OperationContract]
        Models.Table GetTable();

        [OperationContract]
        IEnumerable<Models.Table> ListTables();

        [OperationContract]
        Models.Table CreateTable();

        [OperationContract]
        Models.Table JoinTable(string playerGuid, string tableId);
        
        [OperationContract(IsOneWay = true)]
        void Leave();

        [OperationContract(IsOneWay = true)]
        void Bet(string guid, int amount);

        [OperationContract(IsOneWay = true)]
        void Hit();

        [OperationContract(IsOneWay = true)]
        void Fold();
    }
}
