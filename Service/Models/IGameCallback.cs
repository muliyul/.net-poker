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
        void OnFold(object sender, GameArgs e);
        [OperationContract]
        void OnNextTurn(object sender, GameArgs e);
        [OperationContract]
        void OnDeal(object sender, GameArgs e);
        [OperationContract(IsOneWay = true)]
        void OnNewTableCreated(object sender, GameArgs e);
    }
}
