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
        [OperationContract]
        void OnJoin(object sender, GameArgs e);
        [OperationContract]
        void OnLeave(object sender, GameArgs e);
        [OperationContract]
        void OnHit(object sender, GameArgs e);
        [OperationContract]
        void OnBet(object sender, GameArgs e);
        [OperationContract]
        void OnStatus(object sender, GameArgs e);
        [OperationContract]
        void OnDeal(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnTableListUpdate(object sender, IList<Table> tableList);
        [OperationContract]
        void OnMyTurn(object sender, GameArgs e);
        [OperationContract]
        void OnStand(object sender, GameArgs e);
        [OperationContract]
        void OnDealerPlay(object sender, GameArgs e);
        [OperationContract]
        void OnResetTable(object sender, GameArgs e);

    }
}
