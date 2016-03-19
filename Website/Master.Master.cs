using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.GameReference;

namespace Website
{
    public partial class Master : System.Web.UI.MasterPage, IGameCallback
    {
        #region Callbacks
        public void OnBet(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnDeal(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnDealerPlay(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnHit(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnJoin(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnLeave(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnMyTurn(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNewTableCreated(object sender, List<GameReference.Table> tableList)
        {
            throw new NotImplementedException();
        }

        public void OnResetTable(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnStand(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnStatus(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InstanceContext ctx = new InstanceContext(this);
            Session["GameClient"] = new GameClient(ctx);
            if (Session["User"] != null)
            {
                loginProfileBtn.HRef = "profile.aspx";
                loginProfileBtn.InnerText = "Profile";
            }
        }
    }
}