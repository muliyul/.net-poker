using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IGameCallback
    {
        void OnJoin(object sender, GameArgs e);
        void OnLeave(object sender, GameArgs e);
        void OnHit(object sender, GameArgs e);
        void OnBet(object sender, GameArgs e);
        void OnFold(object sender, GameArgs e);
        void OnNextTurn(object sender, GameArgs e);
    }
}
