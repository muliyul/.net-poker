using System;
using System.Collections.Generic;
using System.Configuration;
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
        }

        public void OnDeal(object sender, GameArgs e)
        {
        }

        public void OnDealerPlay(object sender, GameArgs e)
        {
        }

        public void OnHit(object sender, GameArgs e)
        {
        }

        public void OnJoin(object sender, GameArgs e)
        {
        }

        public void OnLeave(object sender, GameArgs e)
        {
        }

        public void OnMyTurn(object sender, GameArgs e)
        {
        }

        public void OnResetTable(object sender, GameArgs e)
        {
        }

        public void OnRoundResult(object sender, GameArgs e)
        {
        }

        public void OnStand(object sender, GameArgs e)
        {
        }

        public void OnTableListUpdate(object sender, List<GameReference.Table> tableList)
        {
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["GameClient"] == null)
            {
                var bindings = ConfigurationManager.GetSection("system.serviceModel/bindings") as
                        System.ServiceModel.Configuration.BindingsSection;
                InstanceContext ctx = new InstanceContext(this);
                Session["GameClient"] = new GameClient(ctx, bindings.WSDualHttpBinding.Bindings[0].Name);
            }
            var player = (Session["User"] as PlayerData)?.Username;
            if (!string.IsNullOrEmpty(player))
            {
                loginProfileBtn.HRef = "profile.aspx";
                loginProfileBtn.InnerText = "Profile (" + player + ")";
            }
        }
    }
}