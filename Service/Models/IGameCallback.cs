using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IGameCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnJoin(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnLeave(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnHit(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnBet(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnRoundResult(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnDeal(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnTableListUpdate(object sender, IList<Table> tableList);
        [OperationContract(IsOneWay = true)]
        void OnMyTurn(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnStand(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnDealerPlay(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnResetTable(object sender, GameArgs e);

    }
}
