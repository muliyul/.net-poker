
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
    [ServiceContract(CallbackContract = typeof(IGameCallback),SessionMode = SessionMode.Required)]
    public interface IGame
    {
        [OperationContract]
        void Register(string username, string pass);

        [OperationContract]
        PlayerData Login(string username, string pass);

        [OperationContract]
        PlayerData GetPlayerInfo(string username);

        [OperationContract]
        IEnumerable<Models.Table> ListTables();

        [OperationContract(IsOneWay = true)]
        void CreateTable();

        [OperationContract]
        Table JoinTable(int tableIndex);

        [OperationContract]
        Table PlayerReady(string tableId);

        [OperationContract(IsOneWay = true)]
        void Leave();

        [OperationContract(IsOneWay = true)]
        void Bet(decimal amount,bool doubleBet = false);

        [OperationContract(IsOneWay = true)]
        void Stand();

        [OperationContract(IsOneWay = true)]
        void Deal();

        [OperationContract(IsOneWay = true)]
        void Hit();

        [OperationContract(IsOneWay = true)]
        void Fold();
  
    }
}
